using UnityEngine;
using UnityEngine.UI;
using System.Collections;


//This Script displays the PLayers score after killing each zombie
 public class ScoreManager : MonoBehaviour
 {
       // The player's score.
        public static int score;

    // Reference to the Text component.
     Text text;                     


        void Awake ()
        {
            // Set up the reference.
            text = GetComponent <Text> ();

            // Reset the score starting at 0
            score = 0;
        }


        void Update ()
        {
            // Set the displayed text to be the word "Score" followed by the score value.
			text.text = "Score: " + score;
        }
 }