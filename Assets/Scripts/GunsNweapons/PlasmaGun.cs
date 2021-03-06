﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


    public class PlasmaGun : MonoBehaviour
    {
        //number of damage to deal to enemy
        public int damage = 10;
        public float shootRate;
        private float m_shootRateTimeStamp;

        //Referances to the gun meshs
        public GameObject defaultMachinegun;
        public GameObject shotgunReady;
        public GameObject flamethrowerReady;
        public GameObject MinigunReady;
        
    //Sricpts and game Objects we want to prepare
        public GameObject PlasmagunMesh;
        //public bool PlasmagunReady = false;

    //Scripts and Game Objects we want to reset the ammo
    Shotgun shotgun;
    FlameThrower2 flamer;
    //Powerups we want to be to shoot
    ShotgunPowerup shotgunPU;
    FlameThrowerPowerUp flamerPU;

    public GameObject m_shotPrefab;
        RaycastHit hit;
        float range = 1000.0f;

        //stores referances of ammo text and clipText to diplay to show the player how much ammo he/she has
        public Text ammoText;

        AudioSource gunAudio;
        //Stores referance to the enemyhealth to hurt or kill the enemy
        EnemyHealth enemyHealth;

        //Shows  the how much ammo that the player has ready to reload for the next fire 
        public int ammoCount = 500;

    //Referance to gun animation
    public Animation gunFire;

    ZanicHealth zanicHealth;
    RingPowerup RingPU;

    ActivateZem zem;
    //Sets up Referances
    void Awake()
        {
            //  muzzleFlash = GetComponentInChildren<ParticleSystem>();
            enemyHealth = GetComponent<EnemyHealth>();
             gunAudio = GetComponent<AudioSource>();
        shotgun = GetComponent<Shotgun>();
        shotgunPU = GetComponent<ShotgunPowerup>();
        // gunFire = GetComponentInChildren<Animation>();

        gunFire = GetComponentInChildren<Animation>();
        zanicHealth = GetComponent<ZanicHealth>();
        RingPU = GetComponent<RingPowerup>();
        zem = GetComponent<ActivateZem>();
    }

    // updates the text ready to be displayed to the player
    void Start()
        {
            UpdateText();
        PlasmagunMesh.SetActive(false);
        }

        private void UpdateText()
        {
            //assigns the number of ammo and clips you have on the UI 
            ammoText.text = ammoCount.ToString();
            // clipText.text = clipCount.ToString();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButton(0) && ammoCount > 0)
            {
                //Checks to see if the shooter can shoot again with time. Time needs to pass before firing again
                if (Time.time > m_shootRateTimeStamp)
                {
                    //when time to shoot, shoot
                    UpdateText();
                    shootRay();
                gunFire.Play();
                ///then updates to the new time stamp
                m_shootRateTimeStamp = Time.time + shootRate;
                }
            if (ammoCount == 0)
            {
               // PlasmagunReady = false;
                //turns gameObject off when out of ammmo and switchs to default machine gun.
                PlasmagunMesh.SetActive(false);
               // defaultMachinegun.SetActive(true);
                // muzzleFlash.Stop();
                // clipempty.Play();
                //return;
            }
            else if (ammoCount >= 0)
            {
               
                // shotgun.ammoCount = 0;
                PlasmagunMesh.SetActive(true);

            }
         //   if (Combatadd == 1)
           // {
                //PlasmagunReady = true;
                
           // }
        }
        }

        void shootRay()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition) ;
            if (Physics.Raycast(ray, out hit, range))
            {
                gunAudio.Play();
                //returns info when we hit something
                //instantiates laser
                ammoCount -= 1;
                UpdateText();
                GameObject laser = GameObject.Instantiate(m_shotPrefab, transform.position, transform.rotation) as GameObject;
                laser.GetComponent<ShotBehavior>().setTarget(hit.point);
                if (hit.transform.gameObject.tag == "Enemy")
                {
                    hit.transform.GetComponent<EnemyHealth>().TakeDamage(damage);
                  //  Debug.Log("I shot an enemy with a plasma gun!");
                }

                if( hit.transform.gameObject.tag == "Plasmagun")
            {
                hit.transform.GetComponent<PlasmagunPowerup>().GetMoreAmmo();
            }
            
            if (hit.transform.gameObject.tag == "Health")
                {
                hit.transform.GetComponent<HealthPickUp2>().HealPlayer();
              //  Debug.Log("I shot the health kit with a plasma gun");
                }
            if (hit.transform.gameObject.tag == "Shotgun")
            {
                ammoCount = 0;
                hit.transform.GetComponent<ShotgunPowerup>().GiveShotgun();
                defaultMachinegun.SetActive(false);
                shotgunReady.SetActive(true);
            }

            if (hit.transform.gameObject.tag == "Flamer")
            {
                ammoCount = 0;
                hit.transform.GetComponent<FlameThrowerPowerUp>().GiveFlamer();
                defaultMachinegun.SetActive(false);
                flamethrowerReady.SetActive(true);
                shotgunReady.SetActive(false);
              //  Debug.Log("I blasted a flamer with a Plasmagun!");
            }

            if (hit.transform.gameObject.tag == "Minigun")
            {
                ammoCount = 0;
                hit.transform.GetComponent<MinigunPowerUp>().GiveMinigun();
                defaultMachinegun.SetActive(false);
                MinigunReady.SetActive(true);
                flamethrowerReady.SetActive(false);
                shotgunReady.SetActive(false);
              //  Debug.Log("I blasted a Minigun with a Plasmagun");
            }

            if (hit.transform.gameObject.tag == "Zanic")
            {
                hit.transform.GetComponent<ZanicHealth>().TakeDamage(damage);
            }

            if (hit.transform.gameObject.tag == "Ring")
            {
                hit.transform.GetComponent<RingPowerup>().GetPoints();
                Debug.Log("I shot a ring!");
            }

            if (hit.transform.gameObject.tag == "ZanicRing")
            {
                hit.transform.GetComponent<ActivateZem>().activiatezem();
            }



            //destroys laser if it dosent hit anything
            GameObject.Destroy(laser, 2f);
                //damages enemy when we shoot them
               
            }
        }
public void AmmoPickup (int amount)
{
    ammoCount += amount;
       // Debug.Log("I got Plasma ammo");
    UpdateText();
}
    }


