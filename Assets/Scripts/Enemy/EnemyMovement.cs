﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// This script allows Enemys to navigate  through the navmesh agent to go to players position
public class EnemyMovement : MonoBehaviour
{

    // Reference to the player's position.
    Transform player;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;

    //Referance to colliders
    public Collider atkCol;
    public Collider shootCol;
   

    // Reference to the nav mesh agent.
    UnityEngine.AI.NavMeshAgent nav;

    void Awake()
    {
        // Set up the references.
        player = GameObject.FindGameObjectWithTag("Player").transform;
       
        playerHealth = player.GetComponent <PlayerHealth> ();
        enemyHealth = GetComponent<EnemyHealth>();
        //enemyHealth = GetComponent <EnemyHealth> ();
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }


    //This function is not yet ready
    void Start()
    {
        
    }

    // Update is called once per frame
    //The enemy will follow the player by the navmesh until either the players or enemys health is 0 
    void Update()
    {
        // If the enemy and the player have health left...

        if ( enemyHealth.Ehealth > 0 && playerHealth.currentHealth > 0)
        {
            // ... set the destination of the nav mesh agent to the player.
            nav.SetDestination(player.position);
        }
        else
        {
            // ... disable the nav mesh agent.
            nav.enabled = false;
            atkCol.enabled = false;
            shootCol.enabled = false;
            //Destroy(gameObject);
        }
        if (playerHealth.currentHealth == 0 )
        {
            Destroy(gameObject);
        }
        // }
        // Otherwise...
        //   else
        //  {
        // ... disable the nav mesh agent.
        //     nav.enabled = false;
    }
    }
