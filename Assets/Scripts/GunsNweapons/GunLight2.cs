using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//This script controls the gun light when fired
namespace UnityStandardAssets.Characters.FirstPerson
{ 
public class GunLight2 : MonoBehaviour
{

    //timer of when to fire
    float timer;

    //stores referances of ammo text and clipText to diplay to show the player how much ammo he/she has

    public Text clipText;
        //Referance to Bowie shooting
    BowieShooting playerShooting;

    //displays gun light when fired
    public Light gunLight;

    //Shows the starting  clip that the player is ready to shoot
    public int clipCount = 50;

    //shows effects in certain amount of time
    public float effectsDisplayTime = 0.2f;

    //controls how quickly the gun can fire
    public float timeBetweenlights = 0.15f;

    //Controls when to shoot
    private bool canShoot = true;

    //Sets up Referances
    void Awake()
    {
        playerShooting = GetComponent<BowieShooting>();
        gunLight = GetComponentInChildren<Light>();

    }

    // updates the text ready to be displayed to the player

    //Resets the shooting ready for the next fire
    private void ResetShooting()
    {

        canShoot = true;
    }

        //Allows the light to display when the gun is firing in a matter of seconds
        void Update()
    {
        timer += Time.deltaTime;

        if (Input.GetMouseButton(0) && timer >= timeBetweenlights)
        {
            Shoot();

        }

        if (timer >= timeBetweenlights * effectsDisplayTime)
        {
            gunLight.enabled = false;
        }

    }
    public void Shoot()
    {
        if (playerShooting.clipCount != 0)
            timer = 0f;
        gunLight.enabled = true;
       
    }
}
}
