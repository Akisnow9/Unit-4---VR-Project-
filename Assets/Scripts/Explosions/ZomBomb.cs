using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script is similiar to zombSplosion, but it s for the Juggernaunts and deals bigger damage when explodes

public class ZomBomb : MonoBehaviour
{
    //damage dealt to enemy in a the collider
    public int damage = 600;

    //Stores referance to the enemyhealth to hurt or kill the enemy
    EnemyHealth enemyHealth;

    //referance of the sound of the explosion 
    AudioSource Bigsplosion;

    //controls when to destroy its self
    public float DestroyDelay = 2f;

    // Plays the sound then destorys its self in a set time
    void Start()
    {
        Bigsplosion.Play();
        Destroy(gameObject, DestroyDelay);
    }

    //Sets up Referances
    private void Awake()
    {
        Bigsplosion = GetComponent<AudioSource>();
        enemyHealth = GetComponent<EnemyHealth>();
    }

    //if the enemy is in the trigger, it will damage the enemy while the in the trigger
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
            other.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
        
    }
}