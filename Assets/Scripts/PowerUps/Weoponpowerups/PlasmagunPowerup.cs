using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasmagunPowerup : MonoBehaviour
{
    //the script we want to give ammo too
    PlasmaGun plasmagun;


    //The scripts we want to reset the ammo to 0
    Shotgun shotgun;
    public float speed;

    public int ammogiven = 20;

    public int ammoreceived = 10;


    // Start is called before the first frame update
    void Awake()
    {
        plasmagun = GetComponent<PlasmaGun>();
        shotgun = GetComponent<Shotgun>();
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
        Debug.Log("I shot the Plasmagun!");

        Destroy(gameObject);
    }
    public void GetMoreAmmo()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        GameObject playersPlasmagun = GameObject.FindGameObjectWithTag("Pplasmagun");
        playersPlasmagun.GetComponent<PlasmaGun>().AmmoPickup(ammoreceived);
        Debug.Log("I got evan more plasma ammo!");
        Destroy(gameObject);
    }
}
