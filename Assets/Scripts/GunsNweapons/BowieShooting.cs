﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UnityStandardAssets.Characters.FirstPerson
{ 
public class BowieShooting : MonoBehaviour
{ 
    //public GameObject raycastMarker = null;

//number of damage to deal to enemy
public int damage = 10;

//timer of when to fire
float timer;

//stores referances of ammo text and clipText to diplay to show the player how much ammo he/she has
public Text ammoText;
public Text clipText;

//Stores referance to the enemyhealth to hurt or kill the enemy
EnemyHealth enemyHealth;

//stores referance of the gunshots
AudioSource gunAudio;

//stores referance of when the clip is empty
public AudioSource clipempty;

//stores referance of when the player reloads
public AudioSource ReloadSound;

//Shows  the how much ammo that the player has ready to reload for the next fire 
public int ammoCount = 500;



//Shows the current clip that the player is ready to shoot
public int clipSize = 100;

//Shows the starting  clip that the player is ready to shoot
public int clipCount = 50;

//shows effects in certain amount of time
public float effectsDisplayTime;

//controls how quickly the gun can fire
public float timeBetweenBullets = 5f;

//Controls when to shoot
private bool canShoot = true;

//shows gun particles when gun is fired
public ParticleSystem muzzleFlash;

public Animation gunFire;

//Sets up Referances
void Awake()
{
    muzzleFlash = GetComponentInChildren<ParticleSystem>();
    enemyHealth = GetComponent<EnemyHealth>();
    gunAudio = GetComponent<AudioSource>();
    gunFire = GetComponentInChildren<Animation>();
}

// updates the text ready to be displayed to the player
void Start()
{
    UpdateText();
}
//Resets the shooting ready for the next fire
private void ResetShooting()
{
    canShoot = true;
}
private void UpdateText()
{
    //assigns the number of ammo and clips you have on the UI 
    ammoText.text = ammoCount.ToString();
    clipText.text = clipCount.ToString();
}

//Reloads weopon whenever the ammo is greater than the clip count
void ReloadA()
{
    ammoCount += clipCount;

    if (ammoCount > clipSize)
    {
        clipCount = clipSize;
        ammoCount -= clipSize;
    }
    else
    {
        clipCount = ammoCount;
        ammoCount = 0;
    }
    //updates text whenever realoaded
    UpdateText();

}

// Update is called once per frame
void Update()
{
    RaycastHit hit;

    //The distance of the ray that we are using
    float distanceOfRay = 3000f;

    //Cast the ray and check if it hits anything
    if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, distanceOfRay))
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            //reloads weopon when called
            ReloadSound.Play();
            ReloadA();
        }
        //Controls the fire rate of the gun
        timer += Time.deltaTime;
        if (Input.GetMouseButton(0) && timer >= timeBetweenBullets)
        {
            timer = 0f;

            //if you are out of ammo in your clip, you cant fire and a sound will play
            if (clipCount <= 0)
            {
                muzzleFlash.Stop();
                clipempty.Play();
                return;
            }
            //Dectivates shooting if need too
            if (canShoot == false)
            {

                return;
            }
            //plays audio and displays light when fired
            gunAudio.Play();
            gunFire.Play();
           

            //Makes sure the muzzleFlash stops and starts again
            muzzleFlash.Stop();
            muzzleFlash.Play();
            canShoot = false;
            Invoke("ResetShooting", timeBetweenBullets);

            // - 1 everytime the player fires and updates text
            clipCount--;
            UpdateText();
            //  raycastMarker.transform.position = hit.point;


            //muzzleFlash.Play();
            // Debug.Log(hit.transform.name);

            //If you hit the enemy, you will damage the zombie and eventuallu kill it
            if (hit.transform.gameObject.tag == "Enemy")
            {
                hit.transform.GetComponent<EnemyHealth>().TakeDamage(damage);
            }

        }
        //If not firing, dont display the effects
        else if (Input.GetMouseButtonUp(0))
        {
            muzzleFlash.Stop();
   

        }
        //If not firing, dont display the effects
        if (timer >= timeBetweenBullets * effectsDisplayTime)
        {
            DisableEffects();
        }
    }
    //displays a ray showing you where you have shot
    Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * distanceOfRay);
}
//Disables gun light when not firing
public void DisableEffects()
{

}
//Disables muzzleflash when player is dead
public void StopMuzzleFlash()
{
    muzzleFlash.Stop();
}

//a function used to gain ammo when the player picks up ammo
public void AmmoEarned(int amount)
{
    ammoCount += amount;
    ReloadSound.Play();
    UpdateText();
}

    }
}
    
