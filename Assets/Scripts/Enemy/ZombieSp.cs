using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This Script determines the Spawning of the zombies
public class ZombieSp : MonoBehaviour
{

    //Objects it will spawn randomly
    public GameObject[] spawnObjectPrefabs;

    //a float that that controls the speed of the spawner over time
    public float timer = 0.01f;

    //the amount of time it spawns objects
    public float spawnTime;

    //Sets position on where to be spawned
    public Transform spawnPosition;

    // Use this for initialization
    void Start()
    {

        //InvokeRepeating repeats the code such as functions
        //you  need 2 parameters, 1: what function you will code. 2: the amount of time it will repeat
        //Then once every second is called: it will run spawnTime every 2 secs for this Invoke to be called again
        InvokeRepeating("InstantiateObject", 1, spawnTime);
    

    }
   // private void Update()
  /*  {
        // Sets the Timer to be the timer with delta time
        timer = timer = Time.deltaTime;
        //runs the timer. If it it reaches spawn time.It instantiates the enemy, then sets the time back to 0 but not the spawntime
        if(timer >= spawnTime)
        {
            InstantiateObject();
            timer = 0;
        }
        //if spawnTime reachs 20. IT will not change
        if (spawnTime >= 20f)
        {

        }
        //However if not Spawn is not 20, it will continue reducing
        else
        {
            spawnTime += 0.01f;

        }

    }
    */
    // Like in the Shoot Projectile script, we are loading the gameObject from the variable above and converting it.We then instantiate as a game object

    void InstantiateObject()
    {

        //This variable a will get random vales in the array into Variable a and return a value in the boxes below
        //e.g 2 = a = spawned
        //The length propertie will count down all the elements you added or removed in the array you refering too (spawnObjectPrefabs)  

        //Instantiates random zombies in any order as Game Objects
        int a = Random.Range(0, spawnObjectPrefabs.Length);
        GameObject spawnObjectInstance;        //if you put any element number in the brackets, in will only spawn that element
        spawnObjectInstance = Instantiate(spawnObjectPrefabs[a], spawnPosition.position, spawnPosition.rotation) as GameObject;
        //We are using the spawnPostion to assign its position and rotation parameters
    }
}
