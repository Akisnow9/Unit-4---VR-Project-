using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// This script allows the player to damage the player by colliding him/her
namespace UnityStandardAssets.Characters.FirstPerson
{
    public class EnemyAttack : MonoBehaviour
    {
        public float timeBetweenAttacks = 0.5f;     // The time in seconds between each attack.

        // The amount of health taken away per attack.
        public int attackDamage = 10;


        // Reference to the player GameObject.
        public GameObject player;

        // Reference to the player's health.
        public PlayerHealth playerHealth;

        // Reference to this enemy's health.
        // EnemyHealth enemyHealth;                    

        // Determins Whether player is within the trigger collider and can be attacked.
        bool playerInRange;

        // Timer for counting up to the next attack.
        float timer;


        void Awake()
        {
            // Setting up the references.
            player = GameObject.FindGameObjectWithTag("Player");
            playerHealth = player.GetComponent<PlayerHealth>();

        }

        //only attacks the player is in the collider
        void OnTriggerEnter(Collider other)
        {
            // If the entering collider is the player...
            if (other.gameObject == player)
            {
                // ... the player is in range.
                playerInRange = true;
                Debug.Log ("Baddie has found Player");
            }
        }


        void OnTriggerExit(Collider other)
        {
            // If the exiting collider is the player...
            if (other.gameObject == player)
            {
                // ... the player is no longer in range.
                playerInRange = false;
            }
        }


        void Update()
        {
            // Add the time since Update was last called to the timer.
            timer += Time.deltaTime;

            // If the timer exceeds the time between attacks, the player is in range and this enemy is alive...
            if (timer >= timeBetweenAttacks && playerInRange)
            {
                // ... attack.
                Attack();
            }

            // If the player has zero or less health...
            // if (playerHealth.currentHealth <= 0)
            //  {

            // }
        }

        //This function determins how the enemey attacks the Player
        void Attack()
        {
            // Reset the timer.
            timer = 0f;

            // If the player has health to lose...
            if (playerHealth.currentHealth > 0)
            {
                // ... damage the player.
                playerHealth.TakeDamage(attackDamage);

            }
        }
    }
}

