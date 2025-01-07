using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class WeaponController : MonoBehaviour
{
    [SerializeField] private Player playerHoldWeapon;
    [SerializeField] private float damage;
    [SerializeField] private Vector3 hitBox;
    private AudioGameSceneManager audioGameSceneManager;
    private void Start()
    {
        audioGameSceneManager = GameObject.Find("AudioManager").GetComponent<AudioGameSceneManager>();
    }

    public void Attack(Collider collider)
    {
        //Collider[] collidersHit = Physics.OverlapSphere(transform.position, hitBoxRadius);
        if (collider.gameObject.tag == "Mobs")
        {
            MobAI mobAI = collider.gameObject.GetComponent<MobAI>();
            if(mobAI != null && mobAI.gameObject.activeSelf)
            {
                audioGameSceneManager.PlaySFX(audioGameSceneManager.hitMob);
                mobAI.AnimationTakeDamage();
                mobAI.mobHealthBar.takeDamage(damage);
            }
        }
    }

}
