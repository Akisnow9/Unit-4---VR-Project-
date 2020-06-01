using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

    //This script controls the Players Health and will happen if the player dies
    public class PlayerHealth : MonoBehaviour
    {
        // The amount of health the player starts the game with.
        public int startingHealth = 100;

        //gets referance when player is hurt
      //  public GameObject playerhurt;

        // The current health the player has.
        public int currentHealth;

        //Referance to the the Bowie and its gunpoint on the player
       // public GameObject TheBowie;
       // public GameObject SecGunpoint;

        //Referance to the Yowie
       // public GameObject TheYowie;

        // Reference to the PLayers UI health bar.
       public Slider healthSlider;

        // Reference to an image to flash on the screen on being hurt. When player is damaged
        public Image damageImage;

        //Referance to gun lights
       // GunLight gunLight;
      
        // The speed the damageImage will fade at.
        public float flashSpeed = 5f;

        // The colour the damageImage is set to, to flash.
        public Color flashColour = new Color(1f, 0f, 0f, 0.1f);                                  

        // Reference to the player's movement.
       // CharacterController playerMovement;

        //Referance to the grenade script
      //  FireGrenade fireGrenade;

        //this Variable is not yet resolved
        Timer timer;

        // Reference to the PlayerShooting script.
      //  PlayerShooting playerShooting;

       // public GameObject gunDeactivate;

        // Whether the player is dead.
        bool isDead;

        // True when the player gets damaged.
        bool damaged;



        void Awake()
        {
            // Setting up the references.

          //  gunLight = GetComponentInChildren<GunLight>();
          //  fireGrenade = GetComponentInChildren<FireGrenade>();
          //  playerMovement = GetComponent<CharacterController>();
          //  playerShooting = GetComponentInChildren<PlayerShooting>();
            timer = GetComponent<Timer>();
            currentHealth = startingHealth;
            
        }


        void Update()
        {
            // If the player has just been damaged...
            if (damaged)
            {
                //Instantiates the player hurt SFX prefab when the player is hurt
              //  Instantiate(playerhurt, gameObject.transform.position, transform.rotation);
                // ... set the colour of the damageImage to the flash colour.
                damageImage.color = flashColour;
            }
            // Otherwise...
            else
            {

                // ... transition the colour back to clear.
                damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
            }

            // Reset the damaged flag.
            damaged = false;
        }

        //If the Player is damaged by Enemys..
        public void TakeDamage(int amount)
        {
            // Set the damaged flag so the screen will flash.
            damaged = true;

            // Reduce the current health by the damage amount.
            currentHealth -= amount;

            // Set the health bar's value to the current health.
            healthSlider.value = currentHealth;
            // Play the hurt sound effect.
            //  playerAudio.Play();

            // If the player has lost all it's health and the death flag hasn't been set yet...
            if (currentHealth <= 0 && !isDead)
            {
                // ... it should die.
                Death();
            }
        }


        void Death()
        {
            // Set the death flag so this function won't be called again.
            isDead = true;
            Debug.Log("PLayer is dead");
            //Disables muzzleflash when player is dead
          //  playerShooting.StopMuzzleFlash();
            // Turn off any remaining shooting effects.
         //   playerShooting.DisableEffects();


            // Set the audiosource to play the death clip and play it (this will stop the hurt sound from playing).
            // playerAudio.clip = deathClip;
            //playerAudio.Play();

            // Turn off the movement and shooting scripts.
       //     playerMovement.enabled = false;
        //    playerShooting.enabled = false;
        //    fireGrenade.enabled = false;
        //    TheBowie.SetActive(false);
       //     SecGunpoint.SetActive(false);
       //     TheYowie.SetActive(false);
      //      gunLight.enabled = false;
            

            
     


        }
        //When Player picks up the health, the player gains health
        public void HealthEarned(int amount)
        {
            currentHealth += amount;
            healthSlider.value = currentHealth;
            if (currentHealth > startingHealth)
            {
                currentHealth = 100;
            }
        }
    }

       



