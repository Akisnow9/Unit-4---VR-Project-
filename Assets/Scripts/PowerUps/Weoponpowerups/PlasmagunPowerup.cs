using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasmagunPowerup : MonoBehaviour
{
    //the script we want to give ammo too
    PlasmaGun plasmagun;


    //The scripts we want to reset the ammo to 0
    Shotgun shotgun;
    FlameThrower2 flamer;
    public float speed;

    public int ammogiven = 20;

    public int ammoreceived = 10;

    //referance to the players flames
    public ParticleSystem fireeffect;

    // Start is called before the first frame update
    void Awake()
    {
        plasmagun = GetComponent<PlasmaGun>();
        shotgun = GetComponent<Shotgun>();
        flamer = GetComponent<FlameThrower2>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, speed, 0));
    }

    public void GivePlasmagun()
    {
        // shotgun.ammoCount = 0;
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        GameObject playersPlasmagun = GameObject.FindGameObjectWithTag("Pplasmagun");
        playersPlasmagun.GetComponent<PlasmaGun>().AmmoPickup(ammogiven);
     //   Debug.Log("I shot the Plasmagun!");

        Destroy(gameObject);
    }
    public void GetMoreAmmo()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        GameObject playersPlasmagun = GameObject.FindGameObjectWithTag("Pplasmagun");
        playersPlasmagun.GetComponent<PlasmaGun>().AmmoPickup(ammoreceived);
      //  Debug.Log("I got evan more plasma ammo!");
        Destroy(gameObject);
    }
   /* public void OnParticleCollision(GameObject other)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        GameObject playersPlasmagun = GameObject.FindGameObjectWithTag("Pplasmagun");
        playersPlasmagun.GetComponent<PlasmaGun>().AmmoPickup(ammogiven);
        GameObject playersflamer = GameObject.FindGameObjectWithTag("PFlamer");
        playersflamer.GetComponent<FlameThrower2>().GetPlasmagun();
        Destroy(gameObject);
        Debug.Log("I burned the plasma with fire!");
    }
    */
}
