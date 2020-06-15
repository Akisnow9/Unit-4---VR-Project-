using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script controls the Enemys health
public class EnemyHealth : MonoBehaviour
{
    //Referance to when the enmey is hurt
     public AudioSource enemyhurt;
   
    // EnemyWarningZone enemyWarningZone;
    //enemys starting Health 
    public int Ehealth = 100;
    //Sets how much points the player gets when this enemey is destroyed
    public int Scorevalue = 10;
    //This stores a prefab that when the enemey dies, it cause an explosion damaging the player and nearby zombies
    public bool isburning = false;
    public int firedamage = 5;
    public int fireDOT = 1;
    public ParticleSystem fireeffect;
    //The number of points the the player is sighted
    public int Sightpoints;
    public GameObject blood;
    //  public  ParticleSystem hitparticles;
    // bool HasExploded = false;
    // public GameObject Explosivo;
    public Transform pickupPosition;
    // stores pickups so when thge enmey dies, it instantiates powerups
    public Rigidbody[] SpawnPickupPrefabs;


   // public GameObject warningzone;
    //Removes Counter points from Warning zone when sighted zombie is dead
    private int removeCpoints = 2;

    void Update()
    {
        if (isburning == true)
        {
            enemyhurt.Play();
            Ehealth -= fireDOT;
            // Debug.Log("Im burning!");
        }
        if (Ehealth <= 0f)
        {

            Die();
            //  HasExploded = true;
        }
        if (Ehealth <= 0f && Sightpoints == 2)
        {
            //GameObject WarningZone = GameObject.FindGameObjectWithTag("Finish");
    
            Debug.Log("The enemy is no longer in sight");
            // warningZone.GetComponent<EnemyWarningZone>().RemoveCounterpoints(removeCpoints);
            Debug.Log("Points removed");
        }

    }

    //IF the enemy takes damage from a value from another script, it will take damage
    void Awake()
    {

       // enemyWarningZone = warningzone.GetComponent<EnemyWarningZone>();
         enemyhurt = GetComponent<AudioSource>();
        //  fireeffect = GetComponent<ParticleSystem>();
    }

    public void TakeDamage(int amount)
    {
         Instantiate(blood, gameObject.transform.position, transform.rotation);
        Ehealth -= amount;
        enemyhurt.Play();
        //If the enemys health is 0......
        //  if (Ehealth <= 0f && !HasExploded)
        if (Ehealth <= 0f)
        {

            Die();
            //  HasExploded = true;
        }
       

    }
    public void OnParticleCollision(GameObject other)
    {
        isburning = true;
        fireeffect.Play();
        Ehealth -= firedamage;
        enemyhurt.Play();
        //  Debug.Log("A particle hit me!");
        if (Ehealth <= 0f)
        {

            Die();
            
            //  HasExploded = true;
        }

    }


    //The enemy will die by destroying its gameObject
    //This function also gives players points to the scoreValue
    void Die()
    {
        ScoreManager.score += Scorevalue;
        //Instantiate(Explosivo, gameObject.transform.position, transform.rotation);
        int a = Random.Range(0, SpawnPickupPrefabs.Length);
        Rigidbody spawnPickupInstance;
        spawnPickupInstance = Instantiate(SpawnPickupPrefabs[a], pickupPosition.position, pickupPosition.rotation) as Rigidbody; 
        Destroy(gameObject);
    }

    public void Sighted( int amount)
    {
        Sightpoints += amount;
        Debug.Log("Enemy sighted");
    }
    
}
