using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using Debug = UnityEngine.Debug;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeedDefault = 7f;
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private float jumpHeight = 7f;
    [SerializeField] private Transform cam;
    private float moveSpeedCurrent;


    [SerializeField] private WeaponController weapon;
    [SerializeField] private float attackHitbox1;
    [SerializeField] private float attackHitbox4;
    [SerializeField] private Vector3  attackSpherePosition1;


    [SerializeField] private float pickUpExpRange;

    private bool isOnTheGround = true;
    private bool isWalking = false;
    private bool isJumping = false;
    string[] groundTags = { "Ground", "Rock" };


    private bool isAlreadyAttack01 = false;
    private bool isAlreadyAttack04 = false;
    public float attackDelay = 1f;

    private Animator animator;
    private Rigidbody rb;

    [SerializeField] private SkillController[] skill;
    private const string IS_WALKING = "IsWalking";
    private const string IS_ATTACKING = "IsAttacking";
    private const string IS_JUMPING = "IsJumping";
    private const string DEAD = "Dead";

    public HealthBar healthBar;
    public ExpBar expBar;

    private void OnDrawGizmos()
    {


    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        
    }

    private void Start()
    {
        //cho player đi xuyên mob, exp 6 là layer player, 7 là layer mob, 8 là exp
        Physics.IgnoreLayerCollision(6, 7);
        Physics.IgnoreLayerCollision(6, 8);

        moveSpeedCurrent = moveSpeedDefault;
    }

    private void Update()
    {
        if (healthBar.getHealth() <= 0)
        {
            Die();
        }
        else{
            if (!GameManager.instance.isPaused)
            {
                StartCoroutine(HandleAttacking());
                HandleAnimator();
                PickUpExp();
                HandleMovement();
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (groundTags.Contains(collision.gameObject.tag))
        {
            isOnTheGround = true;
            isJumping = false;
        }
    }

    private IEnumerator HandleAttacking()
    {

        for (int i = 0; i < skill.Length; i++) {
            SkillController skillItem = skill[i];
            if (Input.GetKey(skillItem.keySkill) && !skillItem.getIsAlreadyAttack())
            {
                skillItem.imageCooldown.fillAmount = 1;
                skillItem.setIsAlreadyAttack(true);
                switch (skillItem.skillName)
                {
                    case "01":
                        HandleSkill(skillItem.skillName,
                        (transform.position + transform.forward) + attackSpherePosition1,
                        attackHitbox1);
                        break;
                    case "04":
                        HandleSkill(skillItem.skillName, transform.position, attackHitbox4);
                        break;
                }

                    yield return new WaitForSeconds(skillItem.cooldown);
                if (skillItem.getIsAlreadyAttack())
                {
                    skillItem.setIsAlreadyAttack(false);
                }
            }
        }

    }


    private void HandleSkill(string skillName, Vector3 position, float hitBoxRadius)
    {
        animator.SetTrigger(IS_ATTACKING + skillName);

        Collider[] collidersHit = Physics.OverlapSphere(position, hitBoxRadius);
        foreach (Collider collider in collidersHit)
        {
            weapon.Attack(collider);
        }

    }


    private void HandleMovement()
    {
        Vector3 movementVector = playerInput.GetMovementVectorNormalized();

        Vector3 moveDir = Quaternion.Euler(0f, cam.eulerAngles.y, 0f) * new Vector3(movementVector.x, 0f, movementVector.y);

        if (Input.GetKey(KeyCode.Space) && isOnTheGround)
        {
            rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
            isJumping = true;
            isOnTheGround = false;
        }
        isWalking = moveDir != Vector3.zero;

        transform.position += moveDir * Time.deltaTime * moveSpeedCurrent;
        //rotation
        float rotationSpeed = 10f;
        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotationSpeed);
    }

    private void HandleAnimator()
    {
        animator.SetBool(IS_WALKING, isWalking);
        animator.SetBool(IS_JUMPING, isJumping);
    }

    private void PickUpExp()
    {
        Collider[] collidersHit = Physics.OverlapSphere(transform.position, pickUpExpRange);
        foreach (Collider collider in collidersHit) {
            ExpPoint exp = collider.gameObject.GetComponent<ExpPoint>();
            if (exp != null && exp.gameObject.activeSelf)
            {
                exp.ClaimExp(transform, expBar);
            }

        }

    }

    public void LevelUp()
    {
        healthBar.SetMaxHealth();
    }

    public bool GetIsAlreadyAttack01()
    {
        return isAlreadyAttack01;
    }

    public bool GetIsAlreadyAttack04()
    {
        return isAlreadyAttack04;
    }

    public void Die()
    {
        animator.SetTrigger(DEAD);
        GameManager.instance.gameOverScreen.SetActive(true);
    }
}
