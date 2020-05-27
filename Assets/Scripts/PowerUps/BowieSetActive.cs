using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//This script controls when the Bowie gun will appear and explode and damging nearby zombies
public class BowieSetActive : MonoBehaviour
{
    //stores referance of the bowie gun
    public GameObject bowie;

    //stores referance of the explosion
    public GameObject explosion;

    //the delay of spawning objects
    private float counter = 0.0f;

    //the amount of time it spawns
    public float spawnTimer = 5.0f;

    //check to see if it is instantiated
    public bool instantiated = false;


    // Start is called before the first frame update
    void Start()
    {

    }

    //If the bool is false, then the gun will appear in a explosion and the bool will become true not appearing again
    void Update()
    {
        counter += Time.deltaTime;
        if (counter >= spawnTimer  &&  instantiated == false)
        {
            counter = 0.0f;
            Instantiate(explosion, gameObject.transform.position, transform.rotation);
            instantiated = true;
            bowie.SetActive(true);
        }
        
        }
    }

