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
    public GameObject PlasmagunmeshReady;
    public GameObject FlamethrowerMesh;
    public GameObject minigunMesh;

    public ParticleSystem shotgunflash;

    public AudioSource shotgunstart;
    //Referances to gun power ups and guns players guns
    PlasmagunPowerup plasmagunPU;
    ShotgunPowerup shotgunPU;
    PlasmaGun plasmagun;
    FlameThrower2 flamer;
    Minigun minigun;

    //referance to the players guns to keep track of ammo
    public GameObject playersPlasmagun;
    public GameObject playersFlamer;
    public GameObject playersMinigun;

    ZanicHealth zanicHealth;
    RingPowerup RingPU;

    //referrance of camera to fire ray
    Camera cam;
    ActivateZem zem;

    //Referance to gun animation
    public Animation gunFire;

    void Awake()
    {
         shotgunflash = GetComponentInChildren<ParticleSystem>();
        shotgunstart = GetComponent<AudioSource>();
        enemyHealth = GetComponent<EnemyHealth>();
        gunAudio = GetComponent<AudioSource>();
        shotgunPU = GetComponent<ShotgunPowerup>();
        plasmagun = playersPlasmagun.GetComponent<PlasmaGun>();
        plasmagunPU = GetComponent<PlasmagunPowerup>();
        flamer = playersFlamer.GetComponent<FlameThrower2>();
        minigun = playersMinigun.GetComponent<Minigun>();
        gunFire = GetComponentInChildren<Animation>();
        // gunFire = GetComponentInChildren<Animation>();

        zanicHealth = GetComponent<ZanicHealth>();
        RingPU = GetComponent<RingPowerup>();
        
        zem = GetComponent<ActivateZem>();

        // Start is called before the first frame update
    }
    void Start()
    {
        // ammoCount = 20;
        cam = Camera.main;
        UpdateText();
    }
    public void UpdateText()
    {
        //assigns the number of ammo and clips you have on the UI 
        ammoText.text = ammoCount.ToString();
        // clipText.text = clipCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && ammoCount > 0 && Shotgunready == true)
        {
            shotgunflash.Play();
            gunFire.Play();
            UpdateText();
            Shoot();
            //muzzle.SetActive(true);
        }
        if (ammoCount == 0 && plasmagun.ammoCount == 0 && flamer.ammoCount == 0 && minigun.ammoCount == 0)
        {
            // muzzleFlash.Stop();
            // clipempty.Play();
            Shotgunready = false;
            shotgunmesh.SetActive(false);
            defaultMachinegun.SetActive(true);
            FlamethrowerMesh.SetActive(false);
            minigunMesh.SetActive(false);

            // return;
        }
        else if (ammoCount >= 0 && plasmagun.ammoCount == 0 && flamer.ammoCount == 0)
        {
            Shotgunready = true;
            shotgunflash.Stop();

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
        RaycastHit hit_4;
        RaycastHit hit_5;    

        GameObject muzzleInstance = Instantiate(muzzle, spawnPoint.position, spawnPoint.localRotation);
        muzzleInstance.transform.parent = spawnPoint;

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, distance))
        {
            Instantiate(impact, hit.point, Quaternion.LookRotation(hit.normal));
            Debug.Log("bang ");

            if (hit.transform.gameObject.tag == "Enemy")
            {
                hit.transform.GetComponent<EnemyHealth>().TakeDamage(damage);

                Debug.Log("I shot an enemy with a shotgun!");
            }
            //  else if (hit.transform.gameObject.tag != "Enemy")
            //  {
            //  return;
            //  }
            if (hit.transform.gameObject.tag == "Health")
            {
                hit.transform.GetComponent<HealthPickUp2>().HealPlayer();
                Debug.Log("I shot an Healthkit!");
            }
            if (hit.transform.gameObject.tag == "Shotgun")
            {
                hit.transform.GetComponent<ShotgunPowerup>().GetMoreAmmo();
                PlasmagunmeshReady.SetActive(false);
                shotgunstart.Play();
            }
            if (hit.transform.gameObject.tag == "Plasmagun")
            {
                ammoCount = 0;
                hit.transform.GetComponent<PlasmagunPowerup>().GivePlasmagun();
                defaultMachinegun.SetActive(false);
                shotgunmesh.SetActive(false);
                PlasmagunmeshReady.SetActive(true);
                Debug.Log("I shot a shotgun with a plasmagun");
            }

            if (hit.transform.gameObject.tag == "Flamer")
            {
                ammoCount = 0;
                hit.transform.GetComponent<FlameThrowerPowerUp>().GiveFlamer();
                FlamethrowerMesh.SetActive(true);
                PlasmagunmeshReady.SetActive(false);
                shotgunmesh.SetActive(false);
                defaultMachinegun.SetActive(false);
                Debug.Log("I shot a flamer with a shotty!");
            }

            if (hit.transform.gameObject.tag == "Minigun")
            {
                ammoCount = 0;
                hit.transform.GetComponent<MinigunPowerUp>().GiveMinigun();
                minigunMesh.SetActive(true);
                PlasmagunmeshReady.SetActive(false);
                shotgunmesh.SetActive(false);
                defaultMachinegun.SetActive(false);
                Debug.Log("I shot a minigun with a shotgun");
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

            if(hit.transform.gameObject.tag == "ZanicRing")
            {
                hit.transform.GetComponent<ActivateZem>().activiatezem();
            }



            //Bullets that goes forward
            if (Physics.Raycast(cam.transform.position, cam.transform.forward + new Vector3(-1f, 0f, 0f), out hit_1, distance))
            {
                Instantiate(impact, hit_1.point, Quaternion.LookRotation(hit_1.normal));
                {
                    if (hit_1.transform.gameObject.tag == "Enemy")
                    {
                        hit_1.transform.GetComponent<EnemyHealth>().TakeDamage(damage);
                        Debug.Log("I shot an enemy with a shotgun!");
                    }
                    Debug.Log("bang 1");
                }
            }

            //Bullets that goes up
            if (Physics.Raycast(cam.transform.position, cam.transform.forward + new Vector3(1f, 0f, 0f), out hit_2, distance))
            {
                Instantiate(impact, hit_2.point, Quaternion.LookRotation(hit_2.normal));
                {
                    if (hit_2.transform.gameObject.tag == "Enemy")
                    {
                        hit_2.transform.GetComponent<EnemyHealth>().TakeDamage(damage);
                        Debug.Log("I shot an enemy with a shotgun!");
                    }
                    //  else if (hit_2.transform.gameObject.tag != "Enemy")
                    //  {
                    //     return;
                    // }
                    Debug.Log("bang 2");
                }
            }

            //Bullets that goes down
            if (Physics.Raycast(cam.transform.position, cam.transform.forward + new Vector3(1f, 0f, 0f), out hit_3, distance))
            {
                Instantiate(impact, hit_3.point, Quaternion.LookRotation(hit_3.normal));
                {
                    if (hit_3.transform.gameObject.tag == "Enemy")
                    {
                        hit_3.transform.GetComponent<EnemyHealth>().TakeDamage(damage);
                        Debug.Log("I shot an enemy with a shotgun!");
                    }
                    //  else if (hit_3.transform.gameObject.tag != "Enemy")
                    //   {
                    //     return;
                    // }
                    Debug.Log("bang 3");
                }
            }

            if (Physics.Raycast(cam.transform.position, cam.transform.forward + new Vector3(-1f, 0f, 0f), out hit_4, distance))
            {
                Instantiate(impact, hit_4.point, Quaternion.LookRotation(hit_4.normal));
                {
                    if (hit_4.transform.gameObject.tag == "Enemy")
                    {
                        hit_4.transform.GetComponent<EnemyHealth>().TakeDamage(damage);
                        Debug.Log("I shot an enemy with a shotgun!");
                    }
                    Debug.Log("bang 4");
                }
            }


            if (Physics.Raycast(cam.transform.position, cam.transform.forward + new Vector3(1f, 0f, 0f), out hit_5, distance))
            {
                Instantiate(impact, hit_5.point, Quaternion.LookRotation(hit_5.normal));
                {
                    if (hit_5.transform.gameObject.tag == "Enemy")
                    {
                        hit_5.transform.GetComponent<EnemyHealth>().TakeDamage(damage);
                        Debug.Log("I shot an enemy with a shotgun!");
                    }
                    //  else if (hit_2.transform.gameObject.tag != "Enemy")
                    //  {
                    //     return;
                    // }
                    Debug.Log("bang 5");
                }
            }
        }
    }
        
            public void AmmoPickup(int amount)
            {
                ammoCount += amount;
                // shotgunstart.Play();
                UpdateText();
                Debug.Log("I got shotgun ammo!");
            }
        }

    

