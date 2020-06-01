using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


    // This Script controls the timer that shows the player how long they have been alive fot
    public class Timer : MonoBehaviour
    {
        //referance to the players health
        PlayerHealth playerHealth;

        // and the gameobject....
        public GameObject player;

        //Stores referance of text
        Text text;

        //Displays the amount of time gone
        float theTime;

        //controls speed of the time
        public float speed = 1;

        //Check to make sure its true
        public bool playing = true;

        private float stopTime;
        // Start is called before the first frame update

        //starts the referance of text
        void Awake()
        {
            text = GetComponent<Text>();
            playerHealth = player.GetComponent<PlayerHealth>();

        }

        // Update is called once per frame
        public void Update()
        {
            //if playing is true, it will start the timer and run smoothly with delta time
            if (playing == true)
            {
                theTime += Time.deltaTime * speed;

                //This code is quite complex, this sets up the hours,mins, and seconds and runs like a real stop watch.
                // It will  display on screen

                //builds the seconds in 60 seconds like time
                //  divides by 60
                string hours = Mathf.Floor((theTime % 216000) / 3600).ToString("00");
                string minutes = Mathf.Floor((theTime % 3600) / 60).ToString("00");
                string seconds = (theTime % 60).ToString("00");
                text.text = hours + ":" + minutes + ":" + seconds;
            }
            //If the player is dead, it will stop the timer
            if (playerHealth.currentHealth <= 0)
            {
                ClickStop();
            }


        }
        //if false, the timer will stop and show the player how long they have been alive
        public void ClickStop()
        {
            if (playing == true)
                playing = false;
            theTime = Time.time;

        }

    }

