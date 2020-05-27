using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This Script controls what power ups to spawn and fall from the sky, 
//the time it spawns, and the areas it spawns  

public class PowerUpSpawner : MonoBehaviour
{
    //Lists the powerups and weapons the script will spawn
    public GameObject[] powerUps;
  


    //the delay of spawning objects
    private float counter = 0.0f;

    //the amount of time it spawns
    public float spawnTimer = 5.0f;
    

    //referance to the box collider
    private BoxCollider bc;

    //These floats use X and Z axis points to spawn powerups
    public float tempX;
    public float tempZ;

    //Sets the referance of the box collider so it can spawn within the collider
    //spawns the bowie once in a certain amount of time 

    


    public void Start()
    {
        bc = GetComponent<BoxCollider>();
        ///spawns the powerups in certain time
    }
        void Update()
            {
                //count downs smoothly with delta wim of when to spawn... 
                counter += Time.deltaTime;

                if (counter >= spawnTimer)
                {
                    //Then divides what range when to spawn within the collider
                    tempX = Random.Range(-(bc.extents.x / 2), (bc.extents.x / 2));
                    tempZ = Random.Range(-(bc.extents.x / 2), (bc.extents.x / 2));

                    //then instantiates high above the Player randomly with powerups
                    Vector3 tempVector = new Vector3(tempX, 82.2f, tempZ);
                    int p = Random.Range(0, powerUps.Length);
                    Instantiate(powerUps[p], tempVector, Quaternion.identity);
                    counter = 0.0f;
                }
            }
        }
    
