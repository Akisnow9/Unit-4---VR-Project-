﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigunPowerUp : MonoBehaviour
{
    Minigun minigun;
   // Shotgun shotgun;
   // FlameThrower2 flamer;

    //The speed that the powerup rotates until picked up
    public float speed;

    public int ammogiven = 50;

    public int ammoreceived = 20;

    //game object that instantiates firworks when shot
    public GameObject fireworks;

    // Start is called before the first frame update
    void Awake()
    {
        minigun = GetComponent<Minigun>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, speed, 0));
    }

    public void GiveMinigun()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        GameObject playersMinigun = GameObject.FindGameObjectWithTag("PMinigun");
        playersMinigun.GetComponent<Minigun>().AmmoEarned(ammogiven);
        Instantiate(fireworks, gameObject.transform.position, transform.rotation);
        Destroy(gameObject);
    }
    public void GetMoreAmmo()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
       GameObject playersMinigun = GameObject.FindGameObjectWithTag("PMinigun");
        playersMinigun.GetComponent<Minigun>().AmmoEarned(ammoreceived);
        Instantiate(fireworks, gameObject.transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
