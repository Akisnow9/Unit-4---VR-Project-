using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    /*
	//countdowns when to destory
	public float DestroyDelay = 2f;

	//Controls the radius of the explosion
	public float radius = 5f;

	//amount of force that pushs enemys away
	public float force = 700f;

	//Amount of damage it deals to enemys
	public int damage = 1000;

	AudioSource splosion;

	public EnemyHealth enemyHealth;

	void Awake()
	{    // Gets a refeance to the enemys health
		splosion = GetComponent <AudioSource> ();
        enemyHealth = GetComponent<EnemyHealth>();
    }

    //Destroy is a function in unity that dsetroy the game object but can still leave a little bit of data behind
    //Destroy has 2 parameters: the game object will destroy and time delay (float or intage)
    //Some functions have parameters and values, some will return values
    // Use this for initialization
    void Start()
    {
        splosion.Play();
    }
        void OnTriggerEnter(Collider collider)
        //enemyHealth = GetComponent<EnemyHealth>();

        //Gathers information of nearby objects....
        //	Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        // Gahters information of an array to see which nearvy objects have rigidbodys
        //	foreach (Collider nearbyObject in colliders)
{
			//gathers and searchs referance of the other gameObjects rigidbody..
		//	Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
		//	if (rb != null)
		//	{        //We add force and damage of the explosion
			//	rb.AddExplosionForce(force, transform.position, radius);
				
			

			 if (gameObject.tag == "Enemy")
			{
				// it finds its Enemy Health script  runs the function TakeDamage on the enemyhealth script 
				//and minus's that enemys health points by 10 damege default or any given value
				gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
				Debug.Log ("Found this Zombie");			
			}

			Destroy (gameObject, DestroyDelay);
			
		}
	}
    */
}
