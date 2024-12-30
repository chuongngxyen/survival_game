using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ExpPoint : MonoBehaviour
{
    [SerializeField] private float expPoint;
    [SerializeField] private float magnetForce = 10f;
    [SerializeField] private float magnetDistance = 0.5f;

    private bool isClaimed = false;
    private void Update()
    {
        
    }
    public void Disappear()
    {
        this.gameObject.SetActive(false);
        isClaimed = true;
    }

    public void ClaimExp(Transform player, ExpBar expBar)
    {
        Vector3 direction = (player.position - this.transform.position).normalized;

        this.transform.position += direction * magnetForce * Time.deltaTime;
        if (Vector3.Distance(player.position, this.transform.position) < magnetDistance)
        {
            Disappear();
            expBar.SetExp(expPoint);
        }
    }

    public float GetExpPoint()
    {
        return expPoint;
    }

    public bool GetIsClaimed() {  return isClaimed; }
}
