using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UnityStandardAssets.Characters.FirstPerson
{
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

        // muzzle flash
        public GameObject muzzle;

        AudioSource gunAudio;

        HealthPickUp2 healthpick;
        //Stores referance to the enemyhealth to hurt or kill the enemy
        EnemyHealth enemyHealth;

        // Impact of the game object shot
        public GameObject impact;

        public GameObject defaultMachinegun;

        //referrance of camera to fire ray
        Camera cam;


        void Awake()
        {
            //  muzzleFlash = GetComponentInChildren<ParticleSystem>();
            enemyHealth = GetComponent<EnemyHealth>();
              gunAudio = GetComponent<AudioSource>();
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
            if (Input.GetButtonDown("Fire1") && ammoCount >= 0)
            {
                UpdateText();
                Shoot();
            }
            if (ammoCount <= 0)
            {
                // muzzleFlash.Stop();
                // clipempty.Play();
                gameObject.SetActive(false);
                defaultMachinegun.SetActive(true);
                return;
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
            }

            //Bullets that goes forward
            if (Physics.Raycast(cam.transform.position, cam.transform.forward + new Vector3(-2f, 0f, 0f), out hit_1, distance))
            {
                Instantiate(impact, hit_1.point, Quaternion.LookRotation(hit_1.normal));
                if (hit.transform.gameObject.tag == "Enemy")
                {
                    hit.transform.GetComponent<EnemyHealth>().TakeDamage(damage);
                    Debug.Log("I shot an enemy with a shotgun!");
                }
                else if (hit.transform.gameObject.tag == "untagged")
                {
                    return;
                }

            }

            //Bullets that goes up
            if (Physics.Raycast(cam.transform.position, cam.transform.forward + new Vector3(0f, 6f, 0f), out hit_2, distance))
            {
                Instantiate(impact, hit_2.point, Quaternion.LookRotation(hit_2.normal));
                if (hit.transform.gameObject.tag == "Enemy")
                {
                    hit.transform.GetComponent<EnemyHealth>().TakeDamage(damage);
                    Debug.Log("I shot an enemy with a shotgun!");
                }
            }

            //Bullets that goes down
            if (Physics.Raycast(cam.transform.position, cam.transform.forward + new Vector3(0f, -6f, 0f), out hit_3, distance))
            {
                Instantiate(impact, hit_3.point, Quaternion.LookRotation(hit_3.normal));
                if (hit.transform.gameObject.tag == "Enemy")
                {
                    hit.transform.GetComponent<EnemyHealth>().TakeDamage(damage);
                    Debug.Log("I shot an enemy with a shotgun!");
                }
            }
        }
    }
}
