using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowManMob : MobAI
{
    private AudioGameSceneManager AudioGameSceneManager;
    protected override void Awake()
    {
        base.Awake();
    }

    protected void Start()
    {
        AudioGameSceneManager = GameObject.Find("AudioManager").GetComponent<AudioGameSceneManager>();
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void AttackingPlayer()
    {
        base.AttackingPlayer();

        agent.SetDestination(transform.position);
        animator.SetBool(IS_WALKING, false);

        //attack handle
        if (!alreadyAttack)
        {
            AudioGameSceneManager.PlaySFX(AudioGameSceneManager.mobPunch);
            alreadyAttack = true;
            playerHealthBar.takeDamage(attackDamage);
            Invoke(nameof(ResetAttack), timeBetweenAttack);
        }
    }
}
