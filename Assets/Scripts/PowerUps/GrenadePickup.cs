using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script is a power up to gain grenades for the player
public class GrenadePickup : MonoBehaviour
{
    //Referance to the FireGrenade script so we can add grendes to the player
    public FireGrenade fireGrenade;

    //The speed that the powerup rotates until picked up
    public float speed;

    //The amount of greandes gained when the player picks it up
    public int grenadeSupply;

    // Gets a referances ready to use when called
    void Awake()
    {
        fireGrenade = GetComponent<FireGrenade>();
    }

    //Rotates the object around until collided
    void Update()
    {
        transform.Rotate(new Vector3(0, speed, 0));
    }

    //When collided with the Player, it access's the players grenade script and gives the player grenades
    // and then destroys itself
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameObject GLP = GameObject.FindGameObjectWithTag("GLP");
            GLP.GetComponent<FireGrenade>().GrenadesEarned(grenadeSupply);
            Destroy(gameObject);
           
        }
    }
}
 

