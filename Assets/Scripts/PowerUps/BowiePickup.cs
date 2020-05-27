using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This power gives the player a aditional gun Bowie permantly

public class BowiePickup : MonoBehaviour
{
    //Referance to the the Bowie and its gunpoint on the player
    public GameObject TheBowie;
    public GameObject SecGunpoint;

    //The speed that the powerup rotates until picked up
    public float speed;



    //Rotates the object around until collided
    void Update()
    {
        transform.Rotate(new Vector3(0, speed, 0));
    }
    //When collided with the Player, it gives's the player another gun to shoot such as the Bowie 
    // and then destroys itself
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            TheBowie.SetActive(true);
            SecGunpoint.SetActive(true);
        Destroy(this.gameObject);
      
    }
   }
