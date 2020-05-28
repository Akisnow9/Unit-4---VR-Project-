﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script controls the Enemys health
public class EnemyHealth : MonoBehaviour
{
    //Referance to when the enmey is hurt
   // public AudioSource enemyhurt;
    
    //enemys starting Health 
    public int Ehealth = 100;
    //Sets how much points the player gets when this enemey is destroyed
    public int Scorevalue = 10;
    //This stores a prefab that when the enemey dies, it cause an explosion damaging the player and nearby zombies

   // public GameObject blood;
   //  public  ParticleSystem hitparticles;
   // bool HasExploded = false;
   // public GameObject Explosivo;

    //IF the enemy takes damage from a value from another script, it will take damage
     void Awake()
    {
       // enemyhurt = GetComponent<AudioSource>();
       // hitparticles = GetComponent<ParticleSystem>();
    }

    public void TakeDamage (int amount)
    {
       // Instantiate(blood, gameObject.transform.position, transform.rotation);
        Ehealth -= amount;
       // enemyhurt.Play();
        //If the enemys health is 0......
      //  if (Ehealth <= 0f && !HasExploded)
        if (Ehealth <= 0f)
            {

            Die();
          //  HasExploded = true;
        }
        
    }

    //The enemy will die by destroying its gameObject
    //This function also gives players points to the scoreValue
    void Die ()
    {
        ScoreManager.score += Scorevalue;
		//Instantiate(Explosivo, gameObject.transform.position, transform.rotation);
		Destroy(gameObject);
        
    }
}