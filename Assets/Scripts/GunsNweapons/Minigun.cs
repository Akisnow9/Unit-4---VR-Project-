using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

    public class Minigun : MonoBehaviour
{
        //Displays marker or blood depening where the player has shot
        //  public GameObject raycastMarker = null;
        // public GameObject Blood = null;

        //number of damage to deal to enemy
        public int damage = 10;

       
        //timer of when to fire
        float timer;

        //stores referances of ammo text and clipText to diplay to show the player how much ammo he/she has
        public Text ammoText;


        //Stores referance to the enemyhealth to hurt or kill the enemy
        EnemyHealth enemyHealth;
        //EnemyMovement2 enemyMovement2;

        //stores referance of the gunshots
         AudioSource gunAudio;

        //stores referance of when the clip is empty
        // public AudioSource clipempty;

        //stores referance of when the player reloads
        //public AudioSource ReloadSound;

        //Shows  the how much ammo that the player has ready to reload for the next fire 
        public int ammoCount = 500;

        // public int CombatAdd = 1;

        //Shows the current clip that the player is ready to shoot
        //public int clipSize = 100;

        //Shows the starting  clip that the player is ready to shoot
        //public int clipCount = 50;

        //shows effects in certain amount of time
        public float effectsDisplayTime;

        

        //controls how quickly the gun can fire
        public float timeBetweenBullets = 5f;

        //Controls when to shoot
        private bool canShoot = true;

    //shows gun particles when gun is fired
   // public ParticleSystem muzzleFlash;

    // public Animation gunFire;

    //Referance to weopons to reset ammo
    Shotgun shotgun;
    PlasmaGun plasmagun;
    FlameThrower2 flameThrower;
    Minigun minigun;

    //to fix shotgun bug

    public GameObject playershotgun;

    //Referance to the PU scripts 
    HealthPickUp2 healthPU;
    MinigunPowerUp minigunPU;
    ShotgunPowerup shotgunPU;
    PlasmagunPowerup PlasmagunPU;
    FlameThrowerPowerUp flamerPU;


    //Referance to the players weopon meshs to be ready
    public GameObject defaultMachinegun;
    public GameObject shotgunReady;
    public GameObject Plasmagunready;
    public GameObject flamerReady;
    public GameObject minigunReady;

    //Referance to gun animation
    public Animation gunFire;


    //Sets up Referances
    void Awake()
        {
            //  muzzleFlash = GetComponentInChildren<ParticleSystem>();
            enemyHealth = GetComponent<EnemyHealth>();
             gunAudio = GetComponent<AudioSource>();
        shotgun = playershotgun.GetComponent<Shotgun>();
        shotgunPU = GetComponent<ShotgunPowerup>();
        PlasmagunPU = GetComponent<PlasmagunPowerup>();
        minigunPU = GetComponent<MinigunPowerUp>();
       
             gunFire = GetComponentInChildren<Animation>();



        }

        // updates the text ready to be displayed to the player
        void Start()
        {
            UpdateText();
        minigunReady.SetActive(false);
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
            // clipText.text = clipCount.ToString();
        }

        //Reloads weopon whenever the ammo is greater than the clip count
        /*void ReloadA()
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
        */
        // Update is called once per frame
        void Update()
        {
            RaycastHit hit;

            //The distance of the ray that we are using
            float distanceOfRay = 3000f;



            //Cast the ray and check if it hits anything
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, distanceOfRay))
            {
                /*  if (Input.GetKeyDown(KeyCode.R))
                  {
                      //reloads weopon when called
                      ReloadSound.Play();
                      ReloadA();
                  } */
                //Controls the fire rate of the gun
                timer += Time.deltaTime;
                if (Input.GetMouseButton(0) && timer >= timeBetweenBullets && ammoCount > 0)
                {
                    timer = 0f;

                //if you are out of ammo in your clip, you cant fire and a sound will play
                if (ammoCount == 0)
                {
                    // muzzleFlash.Stop();
                    // clipempty.Play();
                    gameObject.SetActive(false);
                    minigunReady.SetActive(true);
                }
                // return;
                else if ( ammoCount >= 0)
                    {
                    minigunReady.SetActive(true);

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
                    // muzzleFlash.Stop();
                   //  muzzleFlash.Play();
                    canShoot = false;
                    Invoke("ResetShooting", timeBetweenBullets);

                    // - 1 everytime the player fires and updates text
                    ammoCount -= 1;
                    UpdateText();


                    //If you hit the enemy, you will damage the zombie and eventuallu kill it
                    if (hit.transform.gameObject.tag == "Enemy")
                    {
                        hit.transform.GetComponent<EnemyHealth>().TakeDamage(damage);
                        Debug.Log("I shot an enemy with a minigun!");
                    }
                     if (hit.transform.gameObject.tag == "Minigun")
                    {
                    hit.transform.GetComponent<MinigunPowerUp>().GetMoreAmmo();
                    Debug.Log("I shot an ammo pack and got more minigun Ammo!");
                    }
                    if (hit.transform.gameObject.tag == "Health")
                {
                    hit.transform.GetComponent<HealthPickUp2>().HealPlayer();
                    Debug.Log("I shot an Healthkit!");
                }
                if (hit.transform.gameObject.tag == "Plasmagun")
                {
                    ammoCount = 0;
                    hit.transform.GetComponent<PlasmagunPowerup>().GivePlasmagun();
                    defaultMachinegun.SetActive(false);
                    minigunReady.SetActive(false);
                    Plasmagunready.SetActive(true);
                    Debug.Log("I shot a plasmagun with minigun");
                }

                if (hit.transform.gameObject.tag == "Shotgun")
                {
                    ammoCount = 0;
                    
                    shotgun.ammoCount = 20;
                    playershotgun.GetComponent<Shotgun>().UpdateText();
                    minigunReady.SetActive(false);
                    shotgunReady.SetActive(true);
                    hit.transform.GetComponent<ShotgunPowerup>().Destroyonfire();
                    defaultMachinegun.SetActive(false);
                    shotgunReady.SetActive(true);
                    Debug.Log("I shot a shotgun with a minigun");
                }
                if (hit.transform.gameObject.tag == "Flamer")
                {
                    ammoCount = 0;
                    hit.transform.GetComponent<FlameThrowerPowerUp>().GiveFlamer();
                    defaultMachinegun.SetActive(false);
                    flamerReady.SetActive(true);
                    minigunReady.SetActive(false);
                    Debug.Log("I shot a flamer with a Minigun!");
                }




            }
                //If not firing, dont display the effects
                else if (Input.GetMouseButtonUp(0))
                {
                 //    muzzleFlash.Stop();
                    // gunLight.enabled = false;

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
            //   gunLight.enabled = false;

        }
        //Disables muzzleflash when player is dead
        public void StopMuzzleFlash()
        {
            //  muzzleFlash.Stop();
        }

        //a function used to gain ammo when the player picks up ammo
        public void AmmoEarned(int amount)
       {
           ammoCount += amount;
            //  ReloadSound.Play();
          UpdateText();
      }
    }


