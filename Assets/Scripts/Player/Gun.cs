using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    // Projectile damage
    public int damage = 500;

    public GameObject raycastMarker = null;

    public int ammoCount = 100;
    public int clipSize = 15;
    public int clipCount = 5;

    //shows gun particles when gun is fired
    public ParticleSystem gunParticles;
    //When gun is fired, it will play this sound
    public AudioSource gunAudio;
    //displays gun light when fired
    public Light gunLight;
    //shows effects in certain amount of time
    float effectsDisplayTime = 0.2f;

    float gunTimer;

    public Text ammoText;

    public Text clipText;

    public Camera fpsCam;
    //Controls how was fast the gun can fire
    public float timeBetweenBullets = 0.2f;
    public bool canShoot = true;

    //Controls the distance of the ray
    float distanceOfRay = 100f;
    
    void Awake()
    {
        gunParticles = GetComponentInChildren<ParticleSystem>();
        gunAudio = GetComponentInChildren<AudioSource>();
        gunLight = GetComponentInChildren<Light>();
    }

    void Start()
    {
        UpdateText();
    }


    void ResetShooting()
    {
        canShoot = true;
    }

    void UpdateText()
    {
        //assigns the number of ammo and clips you have on the UI 
        ammoText.text = ammoCount.ToString();
        clipText.text = clipCount.ToString();
    }

    /*void Reload()
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

        UpdateText();
    }
    */
    //fires weopon whenever Left Mouse button is pressed 
    /* void Update()
     {
         if (Input.GetMouseButton(0) && gunTimer >= timeBetweenBullets)
         {
             Shoot();
         }

         if (gunTimer >= timeBetweenBullets * effectsDisplayTime)
         {
             DisableEffects();
         }
     }
     */

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }
    public void DisableEffects()
    {
        gunLight.enabled = false;
    }

    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position,fpsCam.transform.forward, out hit, distanceOfRay))
        {
            // gunTimer = 0f;

            //  gunAudio.Play();
            // gunLight.enabled = true;
            // gunParticles.Stop();
            // gunParticles.Play();
            Debug.Log(hit.transform.name);
            //Cast the ray and check if it hits anything
        }
    }
}
/*
       
        {


            raycastMarker.transform.position = hit.point;
            hit.transform.GetComponent<EnemyHealth>().TakeDamage(damage);
            Debug.Log(" I hate zombies!");

            if (Input.GetKeyDown(KeyCode.R))
            {
                Reload();
            }



            //if(gameObject.tag == "Enemy")
            // {
            // it finds its Enemy Health script  runs the function TakeDamage on the enemyhealth script 
            //and minus's that enemys health points by 10 damege default or any given value


            //  }
            //	Debug.Log (hit.transform.name);
            if (clipCount <= 0)
            {
                return;
            }

            if (canShoot == false)
            {
                return;
            }

            canShoot = false;
            Invoke("ResetShooting", timeBetweenBullets);

            clipCount--;
            UpdateText();

            //Moves the referance GameObject at a position where ever another game object you clicked on
            raycastMarker.transform.position = hit.point;
            raycastMarker.GetComponentInChildren<ParticleSystem>().Play();
            Debug.Log("Dusty");

            //when shot, it will show the transform positon vector 3 of where the object has been located 


        }
    }
}

//Draw a ray in the editor

//Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * distanceOfRay);
//}
//}
*/