using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//This Script contorls how much damge the this bullet deals to enemys and other expected behaviours

public class Projectile : MonoBehaviour
{
    //Controls how mcuh damage deals to the enemys
    public int damage = 10;

    // Gets a refeance to the enemys health
    public EnemyHealth enemyHealth;
   

    void Awake()
    {    // Gets a refeance to the enemys health
        enemyHealth = GetComponent<EnemyHealth>();
    }
    //The Projectile will destroy itself if it dosent hit any enemy colliders
    void Start()
    {
        Destroy(this.gameObject, 2f);
    }

    //if the Projectile hits a game object of a Enemy tag and collider...
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            // it finds its Enemy Health script  runs the function TakeDamage on the enemyhealth script 
            //and minus's that enemys health points by 10 damege default or any given value
            other.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
            Debug.Log(" OUCH!");
        }
        //once it hits the enemys health collider and tage, the projectile will destroy itself
        Destroy(this.gameObject);
        Debug.Log("I got a bogie!");
    }
}