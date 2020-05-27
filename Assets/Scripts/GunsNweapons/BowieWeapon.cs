using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class gives the player another gun: The Bowie
public class BowieWeapon : MonoBehaviour
{
    //referance to rotation
    public float speed = 1;
    
    //referance the gun so the player can use it 
    public GameObject TheBowie;
    

    //referance to the text so that way it shows the bowies ammo once collected
    public GameObject ammotext;
    public GameObject cliptext;

    //Referance to the Bowie ammo Sp so it will spawn Bowie ammo once player has picked up the Bowie
    public GameObject Bowiesp;

    

   //Rotates the Bowie
    void Update()
    {
        transform.Rotate(new Vector3(0, speed, 0));
    }

    //Gives the player the bowi and enables the bowie ammo spawning
     void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            TheBowie.SetActive(true);
            ammotext.SetActive(true);
            cliptext.SetActive(true);
            Bowiesp.SetActive(true);
            Destroy(this.gameObject);
           
        }
       }
}
