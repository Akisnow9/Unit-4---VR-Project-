using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace UnityStandardAssets.Characters.FirstPerson
{
    //This script turns the crosshaur off when the player is dead, yep thats it
    public class Crosshair : MonoBehaviour
    {
        //Referance to the player health and the visor
        public PlayerHealth playerHealth;
        public Image crosshair;

        //Gathers referances
        void Start()
        {
            crosshair = GetComponent<Image>();
        }

        // once the player is dead, the crosshair is turned off
        void Update()
        {
            if (playerHealth.currentHealth <= 0)
            {
                crosshair.enabled = false;
            }
        }
    }
}
