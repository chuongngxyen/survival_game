using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillController : MonoBehaviour
{
    public float cooldown;
    public KeyCode keySkill;
    public string skillName;
    private bool isAlreadyAttack = false;
    public Image imageCooldown;
    private void Update()
    {
        if (isAlreadyAttack)
        {
            imageCooldown.fillAmount -= 1 / cooldown * Time.deltaTime;
        }
       
    }

    public void setIsAlreadyAttack (bool isAlreadyAttack)
    {
        this.isAlreadyAttack = isAlreadyAttack;
    }

    public bool getIsAlreadyAttack()
    {
        return isAlreadyAttack;
    }
}
