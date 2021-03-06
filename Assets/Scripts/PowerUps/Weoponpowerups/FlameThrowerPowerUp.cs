﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameThrowerPowerUp : MonoBehaviour
{
    //the script we want to give ammo too
    FlameThrower2 flameThrower;


    //The scripts we want to reset the ammo to 0
    Shotgun shotgun;
    PlasmaGun plasmagun;

    public float speed;

    public int ammogiven = 50;

    public int ammoreceived = 20;

    public ParticleSystem fireeffect;
    // Start is called before the first frame update

    //game object that instantiates firworks when shot
    public GameObject fireworks;

    void Awake()
    {
        plasmagun = GetComponent<PlasmaGun>();
        shotgun = GetComponent<Shotgun>();
        flameThrower = GetComponent<FlameThrower2>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, speed, 0));
    }

    public void GiveFlamer()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        GameObject playersFlamer = GameObject.FindGameObjectWithTag("PFlamer");
        playersFlamer.GetComponent<FlameThrower2>().AmmoEarned(ammogiven);
      //  Debug.Log("I found a flamer");
        Instantiate(fireworks, gameObject.transform.position, transform.rotation);
        Destroy(gameObject);
    }
    //Gives Ammo to player if player burns with a flamer
   /* public void OnParticleCollision(GameObject other)
    {
    GameObject player = GameObject.FindGameObjectWithTag("Player");
    GameObject playersFlamer = GameObject.FindGameObjectWithTag("PFlamer");
    playersFlamer.GetComponent<FlameThrower2>().AmmoEarned(ammoreceived);
    Debug.Log("I found more flamer ammo");
    Destroy(gameObject);
}
*/
}
