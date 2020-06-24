﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZanicHealth : MonoBehaviour
{
    //Referance to when the enemey is hurt
    public AudioSource enemyhurt;


    // EnemyWarningZone enemyWarningZone;
    //enemys starting Health 
    public int Ehealth = 100;
    //Sets how much points the player gets when this enemey is destroyed
    public int Scorevalue = 10;
    //This stores a prefab that when the enemey dies, it cause an explosion damaging the player and nearby zombies
    public bool isburning = false;
    public int firedamage = 5;
    public int fireDOT = 1;
    public ParticleSystem fireeffect;
    //The number of points the the player is sighted
    public int Sightpoints;
    public GameObject blood;
    //  public  ParticleSystem hitparticles;
    // bool HasExploded = false;
    // public GameObject Explosivo;
    public Transform pickupPosition;
    public Transform pickupPosition2;
    public Transform pickupPosition3;
    public Transform pickupPosition4;

    public GameObject FireGO;

    public float launchforce = 350;

    // stores pickups so when thge enmey dies, it instantiates powerups
    public Rigidbody[] SpawnPickupPrefabs;
    public bool isdead = false;
    public bool readytodrop = false;

    void Update()
    {
        if (isburning == true)
        {
            enemyhurt.Play();
            Ehealth -= fireDOT;
            // Debug.Log("Im burning!");
        }
        if (Ehealth <= 0f)
        {
            isdead = true;
            Die();
            //  HasExploded = true;
        }
        if (Ehealth <= 0f && Sightpoints == 2)
        {
            //GameObject WarningZone = GameObject.FindGameObjectWithTag("Finish");

            Debug.Log("The enemy is no longer in sight");
            // warningZone.GetComponent<EnemyWarningZone>().RemoveCounterpoints(removeCpoints);
            Debug.Log("Points removed");
        }
    }

    //IF the enemy takes damage from a value from another script, it will take damage
    void Awake()
    {

        // enemyWarningZone = warningzone.GetComponent<EnemyWarningZone>();
        enemyhurt = GetComponent<AudioSource>();
        //  fireeffect = GetComponent<ParticleSystem>();
    }

    public void TakeDamage(int amount)
    {
        Instantiate(blood, gameObject.transform.position, transform.rotation);
        Ehealth -= amount;
        ScoringSystem.score += Scorevalue;
        enemyhurt.Play();
        //If the enemys health is 0......
        //  if (Ehealth <= 0f && !HasExploded)
        if (Ehealth <= 0f)
        {
            isdead = true;
            Die();
            //  HasExploded = true;
        }


    }
    public void OnParticleCollision(GameObject other)
    {
        isburning = true;
        //fireeffect.Play();
        FireGO.SetActive(true);
        Ehealth -= firedamage;
        enemyhurt.Play();
        //  Debug.Log("A particle hit me!");
        if (Ehealth <= 0f)
        {

            Die();

            //  HasExploded = true;
        }

    }


    //The enemy will die by destroying its gameObject
    //This function also gives players points to the scoreValue
    void Die()
    {
       
        // ScoreManager.score += Scorevalue;
        //Instantiate(Explosivo, gameObject.transform.position, transform.rotation);
        if (readytodrop != true)
        {
            
            int a = Random.Range(0, SpawnPickupPrefabs.Length);
            Rigidbody spawnPickupInstance;
            spawnPickupInstance = Instantiate(SpawnPickupPrefabs[a], pickupPosition.position, pickupPosition.rotation) as Rigidbody;
            spawnPickupInstance.AddForce(pickupPosition.up * launchforce);

            spawnPickupInstance = Instantiate(SpawnPickupPrefabs[a], pickupPosition.position, pickupPosition2.rotation) as Rigidbody;
            spawnPickupInstance.AddForce(pickupPosition.up * launchforce);

            spawnPickupInstance = Instantiate(SpawnPickupPrefabs[a], pickupPosition.position, pickupPosition3.rotation) as Rigidbody;
            spawnPickupInstance.AddForce(pickupPosition.up * launchforce);

            spawnPickupInstance = Instantiate(SpawnPickupPrefabs[a], pickupPosition.position, pickupPosition4.rotation) as Rigidbody;
            spawnPickupInstance.AddForce(pickupPosition.up * launchforce);
            //Destroy(gameObject);
            readytodrop = true;
            Debug.Log("I droped one!");
            Destroy(gameObject);
        }
    }

    public void Sighted(int amount)
    {
        Sightpoints += amount;
        Debug.Log("Enemy sighted");
    }
}