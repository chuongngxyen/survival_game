using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] private Player playerHoldWeapon;
    [SerializeField] private float damage;


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
                mobAI.AnimationTakeDamage();
                mobAI.mobHealthBar.takeDamage(damage);
            }
        }
    }
}
