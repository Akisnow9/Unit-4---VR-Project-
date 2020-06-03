using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//This script gives player health when collided
//namespace UnityStandardAssets.Characters.FirstPerson
//{
    public class HealthPickUp2 : MonoBehaviour
    {
        //public GameObject healthSFX;

        PlayerHealth playerHealth;

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
       public void HealPlayer()
        {
          //  if (other.gameObject.tag == "Player")
           // {
                //Instantiate(healthSFX, gameObject.transform.position, transform.rotation);
                GameObject player = GameObject.FindGameObjectWithTag("Player");
                player.GetComponent<PlayerHealth>().HealthEarned(healthSupply);
                Destroy(gameObject);
              
            }
        }
  //  }
//}