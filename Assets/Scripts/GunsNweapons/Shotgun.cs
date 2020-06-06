using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//namespace UnityStandardAssets.Characters.FirstPerson
//{
    public class Shotgun : MonoBehaviour
    {
        //number of damage to deal to enemy
        public int damage = 10;

        public Text ammoText;
        //Gun barrel to shoot pellets
        public Transform spawnPoint;

        //Shows  the how much ammo that the player has ready to reload for the next fire 
        public int ammoCount = 500;

        //The distance of the raycast
        public float distance = 15f;

        public GameObject shotgunmesh;
        // muzzle flash
        public GameObject muzzle;

        AudioSource gunAudio;

        HealthPickUp2 healthpick;
        //Stores referance to the enemyhealth to hurt or kill the enemy
        EnemyHealth enemyHealth;

    public bool Shotgunready = false;
        // Impact of the game object shot
        public GameObject impact;

        public GameObject defaultMachinegun;

        public AudioSource shotgunstart;

    ShotgunPowerup shotgunPU;
        //referrance of camera to fire ray
        Camera cam;


        void Awake()
        {
        //  muzzleFlash = GetComponentInChildren<ParticleSystem>();
        shotgunstart = GetComponent<AudioSource>();
        enemyHealth = GetComponent<EnemyHealth>();
         gunAudio = GetComponent<AudioSource>();
        shotgunPU = GetComponent<ShotgunPowerup>();

            // gunFire = GetComponentInChildren<Animation>();

            // Start is called before the first frame update
        }
        void Start()
        {
           // ammoCount = 20;
            cam = Camera.main;
            UpdateText();
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
            if (Input.GetButtonDown("Fire1") && ammoCount >= 0 && Shotgunready == true)
            {
                UpdateText();
                Shoot();
            }
        if (ammoCount == 0)
        {
            // muzzleFlash.Stop();
            // clipempty.Play();
            Shotgunready = false;
            shotgunmesh.SetActive(false);
            // gameObject.SetActive(false);
             defaultMachinegun.SetActive(true);
            // return;
        }
        else if (ammoCount >= 0)
        {
            Shotgunready = true;


        }
        }
            
        
        

        
        //Method to shoot
        private void Shoot()
        {
            gunAudio.Play();
             ammoCount -= 1;
            RaycastHit hit;
            RaycastHit hit_1;
            RaycastHit hit_2;
            RaycastHit hit_3;

            GameObject muzzleInstance = Instantiate(muzzle, spawnPoint.position, spawnPoint.localRotation);
            muzzleInstance.transform.parent = spawnPoint;
            //Bullets that goes forward
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, distance))
            {
                Instantiate(impact, hit.point, Quaternion.LookRotation(hit.normal));
                if (hit.transform.gameObject.tag == "Enemy")
                {
                    hit.transform.GetComponent<EnemyHealth>().TakeDamage(damage);
                    Debug.Log("I shot an enemy with a shotgun!");
                }
                if (hit.transform.gameObject.tag == "Health")
                {
                    hit.transform.GetComponent<HealthPickUp2>().HealPlayer();
                    Debug.Log("I shot an Healthkit!");
                }
                if (hit.transform.gameObject.tag == "Shotgun")
                {
                hit.transform.GetComponent<ShotgunPowerup>().GetMoreAmmo();
                shotgunstart.Play();
                }
                else if (hit.transform.gameObject.tag != "Enemy")
                {
                    return;
                }

            }

            //Bullets that goes forward
            if (Physics.Raycast(cam.transform.position, cam.transform.forward + new Vector3(-8f, 0f, 0f), out hit_1, distance))
            {
                Instantiate(impact, hit_1.point, Quaternion.LookRotation(hit_1.normal));
                if (hit.transform.gameObject.tag == "Enemy")
                {
                    hit.transform.GetComponent<EnemyHealth>().TakeDamage(damage);
                    Debug.Log("I shot an enemy with a shotgun!");
                }
                else if (hit.transform.gameObject.tag != "Enemy")
                {
                    return;
                }

            }

            //Bullets that goes up
            if (Physics.Raycast(cam.transform.position, cam.transform.forward + new Vector3(0f, 10f, 0f), out hit_2, distance))
            {
                Instantiate(impact, hit_2.point, Quaternion.LookRotation(hit_2.normal));
                if (hit.transform.gameObject.tag == "Enemy")
                {
                    hit.transform.GetComponent<EnemyHealth>().TakeDamage(damage);
                    Debug.Log("I shot an enemy with a shotgun!");
                }
                else if (hit.transform.gameObject.tag != "Enemy")
                {
                    return;
                }
            }

            //Bullets that goes down
            if (Physics.Raycast(cam.transform.position, cam.transform.forward + new Vector3(0f, -12f, 0f), out hit_3, distance))
            {
                Instantiate(impact, hit_3.point, Quaternion.LookRotation(hit_3.normal));
                if (hit.transform.gameObject.tag == "Enemy")
                {
                    hit.transform.GetComponent<EnemyHealth>().TakeDamage(damage);
                    Debug.Log("I shot an enemy with a shotgun!");
                }
                else if (hit.transform.gameObject.tag != "Enemy")
                {
                    return;
                }
            }
        }

    public void AmmoPickup( int amount)
    {
        ammoCount += amount;
       // shotgunstart.Play();
        UpdateText();
        Debug.Log("I got shotgun ammo!");
    }
    }
//}
