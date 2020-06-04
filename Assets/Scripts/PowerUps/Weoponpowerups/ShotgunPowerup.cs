using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunPowerup : MonoBehaviour
{
    //Referance to the shotgun script
    Shotgun shotgun;

    //referance to the player
    public GameObject player;

   
    //The speed that the powerup rotates until picked up
    public float speed;

    public int ammogiven = 50;
    //Referance to players shotgun (temporaliry unactive)
    public GameObject playersShotgun;

    // Gets a referances ready to use when called
    void Awake()
    {
        shotgun = GetComponent<Shotgun>();
    }

    //Rotates the object around until collided
    void Update()
    {
        transform.Rotate(new Vector3(0, speed, 0));
    }
    //When shot by the Player, it access's the players health script and gives the player health
    // and then destroys itself
    public void GiveShotgun()
    {
        //  if (other.gameObject.tag == "Player")
        // {
        //Instantiate(healthSFX, gameObject.transform.position, transform.rotation);
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        //playersShotgun.SetActive(true);
        playersShotgun.GetComponent<Shotgun>().AmmoPickup(ammogiven);
        Destroy(gameObject);

    }
}


