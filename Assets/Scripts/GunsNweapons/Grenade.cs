using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//This script controls the Behaviours of the Drop Bear grenades
public class Grenade : MonoBehaviour
{
    //controls when the  drop Bear explodes
    public float timeToExplode = 2f;

   // stores the explosion inside the grenade
    public GameObject Explosive;

    //stores the referance to the enemy health
    EnemyHealth enemyHealth;
    
    //starts the countdown to explode
        void Start()
    {
        Invoke("Explode", timeToExplode);
    }
    //Instantiates the explosion damaging enemys and then destroying itself
    private void Explode()
    {
            Instantiate(Explosive, gameObject.transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
    }

