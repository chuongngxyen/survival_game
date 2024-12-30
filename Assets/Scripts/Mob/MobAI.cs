﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MobAI : MonoBehaviour
{
    // AI Variable
    private Transform player;
    private NavMeshAgent agent;

    [SerializeField] private LayerMask whatIsPlayer, whatIsGround;


    private bool alreadyAttack;
    [SerializeField] private float timeBetweenAttack;

    private bool isPlayerInSightRange, isPlayerInAttackRange;
    [SerializeField] private float attackRange, sightRange;
    [SerializeField] private float attackDamage;
    private bool isDie = false;

    //animation variable
    private Animator animator;
    private const string IS_WALKING = "IsWalking";
    private const string IS_DIE = "IsDie";
    private const string IS_HIT = "IsTakeDamage";

    //health bar
    [SerializeField] HealthBar playerHealthBar;
    public HealthBar mobHealthBar;

    //exp
    [SerializeField] private GameObject expObject;
    [SerializeField] private GameObject expFolder;
    [SerializeField] private int expAmount;
    protected virtual void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {

        //Animation
        if (!isDie && mobHealthBar.getHealth() <= 0 )
        {
            Die();
        }

        //AI handle
        isPlayerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        isPlayerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!isDie)
        {
            if (isPlayerInSightRange && !isPlayerInAttackRange) ChasingPlayer();
            if (isPlayerInSightRange && isPlayerInAttackRange) AttackingPlayer();
        }
        

        
    }

    private void ChasingPlayer()
    {
        agent.SetDestination(player.position);
        animator.SetBool(IS_WALKING, true);

        //calculate mob look to player
        float changeRotationSmooth = 8f;
        Vector3 direction = (player.position - transform.position).normalized;
        if (direction != Vector3.zero)
        {
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * changeRotationSmooth);
        }

    }

    private void AttackingPlayer()
    {
        agent.SetDestination(transform.position);
        animator.SetBool(IS_WALKING, false);

        //attack handle
        if (!alreadyAttack)
        {
            alreadyAttack = true;
            playerHealthBar.takeDamage(attackDamage);
            Invoke(nameof(ResetAttack), timeBetweenAttack);
        }
    }

    private void ResetAttack()
    {
        alreadyAttack = false;
    }

    public virtual void Die()
    {
        isDie = true;
        animator.SetTrigger(IS_DIE);
        for(int i = 0; i<expAmount; i++)
        {
            float xPos = UnityEngine.Random.Range(transform.position.x +0.5f, transform.position.x - 0.5f);
            float zPos = UnityEngine.Random.Range(transform.position.z +0.5f, transform.position.z - 0.5f);
            GameObject exp = Instantiate(expObject, new Vector3(xPos, transform.position.y, zPos), Quaternion.identity);
            exp.SetActive(true);
            exp.transform.parent = expFolder.transform;
        }
        

    }

    public void AnimationTakeDamage()
    {
        animator.SetTrigger(IS_HIT);
    }
}
