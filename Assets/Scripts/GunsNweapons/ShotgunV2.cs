using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunV2 : MonoBehaviour
{
    //the ammount of pellets fired
    public int PelletCount;

    //the amount of spread of the angle
    public float spreadAngle;

    public int damage;

   // public float LifeTime = 30f;

    //speed of pellets
   // public float pelletFireVel = 1;

    //Referance of what game Object the pellet would be
   // public GameObject pellet;

    //The transform that will shoot from
    public Transform BarrelExit;

    //lists the amount of pellets shot from a location
    List<Quaternion> pellets;

    //Bool to use Raycast instead of gameobjects
    public bool UseRayCast;
    public LayerMask LayerMaskToHit;

    //Stores referance to the enemyhealth to hurt or kill the enemy
    EnemyHealth enemyHealth;

    //Assigns the pellets ready to be shot
    void Awake()
    {
        pellets = new List<Quaternion>(new Quaternion[PelletCount]);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))

            Fire();
    }


    void Fire()
    {
        if (!UseRayCast)
        {
            /*   int i = 0;
               GameObject p = new GameObject();
               foreach (Quaternion quat= 0 < PelletCount, i++)
               {
                   pellets[i] = Random.rotation;
                   //Instantiates the pellets
                   GameObject p = Instantiate(pellet, BarrelExit.position, BarrelExit.rotation);
                   //This code makes sure the pellets are spread out
                   p.transform.rotation = Quaternion.RotateTowards(p.transform.rotation, pellets[i], spreadAngle);
                   //Adds force to the pellets
                   p.GetComponent<Rigidbody>().AddForce(p.transform.right * pelletFireVel);
               }
               i++;
           */
            Debug.Log(" Im using ray cast");
        }

        else
        {
            int y = 0;
            foreach (Quaternion quat in pellets)
            {
                pellets[y] = Random.rotation;
                Quaternion rot = Quaternion.RotateTowards(BarrelExit.transform.rotation, pellets[y], spreadAngle);
                RaycastHit hit;
                if (Physics.Raycast(BarrelExit.transform.position, rot * Vector3.forward, out hit, Mathf.Infinity, LayerMaskToHit))
                    if (hit.transform.gameObject.tag == "Enemy")
                    {
                        hit.transform.GetComponent<EnemyHealth>().TakeDamage(damage);
                        Debug.Log("I shot an enemy with a shotgun!");
                    }
                Debug.Log("BANG!");

            }
            y++;
        }
        
    }
}

