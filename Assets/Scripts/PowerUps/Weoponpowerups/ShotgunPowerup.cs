using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunPowerup : MonoBehaviour
{
    //Referance to the shotgun script
    Shotgun shotgun;

    //referance to the player
    // public GameObject player;


    //The speed that the powerup rotates until picked up
    public float speed;

    public int ammogiven = 50;

    public int ammoreceived = 20;


    //Referance to players shotgun (temporaliry unactive)
    public GameObject playersShotgun;

    //referance to the players flames
    public ParticleSystem fireeffect;

    //game object that instantiates firworks when shot
    public GameObject fireworks;

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
        GameObject playersShotgun = GameObject.FindGameObjectWithTag("Pshotgun");
        //playersShotgun.SetActive(true);
        playersShotgun.GetComponent<Shotgun>().AmmoPickup(ammogiven);
        Instantiate(fireworks, gameObject.transform.position, transform.rotation);
        Destroy(gameObject);
    }
    public void GetMoreAmmo()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        GameObject playersShotgun = GameObject.FindGameObjectWithTag("Pshotgun");
        playersShotgun.GetComponent<Shotgun>().AmmoPickup(ammoreceived);
        Instantiate(fireworks, gameObject.transform.position, transform.rotation);
        Destroy(gameObject);
    }
    //this void is only for the minigun to fix a bug
    public void Destroyonfire()
    {
        Destroy(gameObject);
    }
    /*
        public void OnParticleCollision(GameObject other)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        GameObject playersShotgun = GameObject.FindGameObjectWithTag("Pshotgun");
        playersShotgun.GetComponent<Shotgun>().AmmoPickup(ammoreceived);
        GameObject playersflamer = GameObject.FindGameObjectWithTag("PFlamer");
        playersflamer.GetComponent<FlameThrower2>().Getshotgun();
        Destroy(gameObject);
        Debug.Log("I burned the shells with fire!");

    }
    */
}


