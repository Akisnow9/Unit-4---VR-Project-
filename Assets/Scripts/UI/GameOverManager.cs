using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
namespace UnityStandardAssets.Characters.FirstPerson
{
    //This Scrip controls the game to close when the player dies
    public class GameOverManager : MonoBehaviour
    {
        //referance to players health
        public PlayerHealth playerHealth;
        
        //referance to the game over text
        public Text gameover;

        //referance to the sfx
        public AudioSource gameOverSound;
        
        //how long it takes before the game quits itself
        public float restartDelay = 5f;
        float restartTimer;

        //Gathers referances
        void Start()
        {
            gameover = GetComponent<Text>();
            gameOverSound = GetComponent<AudioSource>();
        }

        // If player dies, it will display the text and the sound will play
        //then countdowns then closes the application
        void Update()
        {
            if (playerHealth.currentHealth <= 0)
            {
                gameOverSound.enabled = true;
                restartTimer += Time.deltaTime;
                gameover.enabled = true;
                if (restartTimer >= restartDelay)
                {
                    Application.Quit();
                   

                }
            }
        }
    }
}
