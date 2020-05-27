using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets.Characters.FirstPerson
{
    //This script is a power up to gain ammo for the players Yowie and Bowie Machine guns
    public class Ammpickup2 : MonoBehaviour
  {
        //Referance to the Bowieshooting script so we can add ammo
        public PlayerShooting playerShooting;
        public BowieShooting bowieShooting;

    //The speed that the powerup rotates until picked up
    public float speed;

    //The amount of ammo gained when the player picks it up
    public int ammoSupply;


    // Gets a referances ready to use when called
    void Awake()
    {
            playerShooting = GetComponent<PlayerShooting>();
            bowieShooting = GetComponent<BowieShooting>();
    }

    //Rotates the object around until collided
    void Update()
    {
        transform.Rotate(new Vector3(0, speed, 0));
    }
    //When collided with the Player, it access's the players shooting script and gives the player ammo 
    // and then destroys itself
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            GameObject SecGunPoint = GameObject.FindGameObjectWithTag("Ammo2");
            SecGunPoint.GetComponent<BowieShooting>().AmmoEarned(ammoSupply);
            GameObject GunPoint = GameObject.FindGameObjectWithTag("Ammo");
            GunPoint.GetComponent<PlayerShooting>().AmmoEarned(ammoSupply);
            Destroy(gameObject);


        }
    }
}
}