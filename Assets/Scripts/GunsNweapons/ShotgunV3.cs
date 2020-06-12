using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunV3 : MonoBehaviour
{
    //the ammount of pellets fired
    public int PelletCount;

    //the amount of spread of the angle
    public float spreadAngle;

    //speed of pellets
    public float pelletFireVel = 1;

    //Referance of what game Object the pellet would be
    public GameObject Bullet;

    public bool shotgun = true;

    public int NumOfPellets, angle;

    //The transform that will shoot from
    public Transform BarrelExit;

    //lists the amount of pellets shot from a location
    List<Quaternion> pellets;


    //Assigns the pellets ready to be shot
    void Awake()
    {
        pellets = new List<Quaternion>(PelletCount);
        for (int i = 0; i < PelletCount; i++)
        {
            pellets.Add(Quaternion.Euler(Vector3.zero));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))

            Fire();
    }


    void Fire()
    {
        if (shotgun)
        {
            for (int i = 0; i < NumOfPellets; i++)
            {
                Instantiate(Bullet, BarrelExit.position, Quaternion.Euler(0, 0, -(NumOfPellets / 2 * angle) + (Random.Range(0f, angle))));
                Bullet.transform.rotation = Quaternion.RotateTowards(transform.rotation, pellets[i], angle);
                Bullet.GetComponent<Rigidbody>().AddForce(Bullet.transform.right * pelletFireVel);
                i++;
            }
        }
    }
}

          //  for (int = 0 < PelletCount, i++)
           // {
        //     pellets[i] = Random.rotation;
                //Instantiates the pellets
          //   GameObject p = Instantiate(pellet, BarrelExit.position, BarrelExit.rotation);
                //This code makes sure the pellets are spread out
             //   p.transform.rotation = Quaternion.RotateTowards(p.transform.rotation, pellets[i], spreadAngle);
                //Adds force to the pellets
            //  p.GetComponent<Rigidbody>().AddForce(p.transform.right * pelletFireVel);
       //     }
           // i++;
   
