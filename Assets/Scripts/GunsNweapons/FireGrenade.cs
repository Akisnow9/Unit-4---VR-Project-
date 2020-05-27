using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//This script controls how the grenade is thrown and when it explodes

public class FireGrenade : MonoBehaviour
{
    //referance to the pickup sound
    public AudioSource pickupSound;
    
    //stores referances of Grenade text and to diplay to show the player how much Grenades he/she has
    public Text GrenadeText;

    //How much the player starts with the grenades
    public int grenadeCount = 5;

    //the launch point to instantiate grenades
    public GameObject grenadeLaunchPoint;

    //Stores the dropbear Grenades
    public GameObject Grenade;

    //how much power it launchs the grenades
    public float launchPower;

    //referance to the sound where th player throws the grenade
    public AudioSource launch;

    // updates the text ready to be displayed to the player
    void Start()
    {
        UpdateGrenadeText();
    }

    // Update is called once per frame
    void Update()
    {
		//If the player presses the left mouse and has a grenade
		if (Input.GetMouseButtonDown(1) && grenadeCount != 0) 
		{
            launch.Play();
            grenadeCount--;
            //it shoots an grenade
            GameObject GO = Instantiate (Grenade, grenadeLaunchPoint.transform.position, 
				Quaternion.identity) 
				as GameObject;
                
		
		//Adds force to the grenades rigidbody to push it forward
			GO.GetComponent<Rigidbody> ().AddForce (
				grenadeLaunchPoint.transform.forward * launchPower, ForceMode.Impulse);
               UpdateGrenadeText();

            //If the player has no grenades, the player cannot throw any
            if (grenadeCount <= 0)
            {
               
                return;
            }
        }   
        }
    //Updates Grenade values whenever called
    private void UpdateGrenadeText()
    {
        GrenadeText.text = grenadeCount.ToString();
       
    }

    //a function used to gain grenades when the player picks it up
    public void GrenadesEarned( int amount)
    {
        grenadeCount += amount;
        pickupSound.Play();
        UpdateGrenadeText();
    }
}

