using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets.Characters.FirstPerson
{

    //This script is a power up to gain health for the player
    public class HealthPickUp : MonoBehaviour
    {
        //Referance to the playerhealth script so we can add health to the player
        public PlayerHealth playerHealth;

        public GameObject player;

        //The speed that the powerup rotates until picked up
        public float speed;

        //The amount of health gained when the player picks it up
        public int healthSupply;


        // Gets a referances ready to use when called
        void Awake()
        {
            playerHealth = GetComponent<PlayerHealth>();
        }

        //Rotates the object around until collided
        void Update()
        {
            transform.Rotate(new Vector3(0, speed, 0));
        }

        //When collided with the Player, it access's the players health script and gives the player health
        // and then destroys itself
        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
                // GameObject player = GameObject.FindGameObjectWithTag("Player");
                player.GetComponent<PlayerHealth>().HealthEarned(healthSupply);
            Destroy(gameObject);
          

        }
    }
}
