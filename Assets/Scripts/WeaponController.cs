using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] private Player playerHoldWeapon;
    [SerializeField] private float damage;
    private AudioGameSceneManager audioGameSceneManager;

    private void Start()
    {
        audioGameSceneManager = GameObject.Find("AudioManager").GetComponent<AudioGameSceneManager>();
    }
    private void Update()
    {
    }

    public void Attack(Collider collider)
    {
        if(collider.gameObject.tag == "Mobs")
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
