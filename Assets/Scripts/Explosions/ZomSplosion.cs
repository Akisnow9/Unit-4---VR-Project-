using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script controls Explosion, when the zombies or grenades explode


public class ZomSplosion : MonoBehaviour
{
    //damage dealt to enemy in a the collider
    public int damage = 600;

    //Stores referance to the enemyhealth to hurt or kill the enemy
    EnemyHealth enemyHealth;

    //referance of the sound of the explosion
    AudioSource splosion;

    //controls when to destroy its self
    public float DestroyDelay = 2f;

    // Plays the sound then destorys its self in a set time
    void Start()
    {
        splosion.Play();
        Destroy(gameObject, DestroyDelay);
    }

    //Sets up Referances
    void Awake()
    {
        splosion = GetComponent<AudioSource>();
        enemyHealth = GetComponent<EnemyHealth>();
    }

    //if the enemy is in the trigger, it will damage the enemy while the in the trigger
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
            other.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
            
    }
    
}
