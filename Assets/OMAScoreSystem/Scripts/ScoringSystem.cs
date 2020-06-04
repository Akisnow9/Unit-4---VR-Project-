using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoringSystem : MonoBehaviour
{
    public  GameObject endMenu;
    private static GameObject highScoreInstance;
    public TextMeshProUGUI scoreUI;
    public TextMeshProUGUI highScoreUI;
    public TextMeshProUGUI timeUI;

    private float time;    
    public static int score;
    private int highScore;

    public static bool end;
    private bool timer = true;
    // Start is called before the first frame update
    private void Awake()
    {
        highScoreUI = GameObject.Find("HighScore").GetComponent<TextMeshProUGUI>();
        DontDestroyOnLoad(gameObject);

        if (highScoreInstance == null)
        {
            highScoreInstance = gameObject;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        scoreUI = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
        timeUI = GameObject.Find("Time").GetComponent<TextMeshProUGUI>();
        endMenu = GameObject.Find("EndMenu");

        endMenu.SetActive(false);
        end = false;
    }

    // Update is called once per frame
    void Update()
    {

        //Score
        scoreUI.text = score.ToString();


        //Timer              
        if (timer)
        {
            time += Time.deltaTime;
            string minutes = ((int)time / 60).ToString();
            string seconds = (time % 60).ToString("f2");

            timeUI.text = minutes + ":" + seconds;
        }

        //HightScore
        highScoreUI.text = highScore.ToString();


        if (end)
        {         
            EndMenu();
        }
        else
        {
            endMenu.SetActive(false);
        }
     
    }

    public void Play()
    {
        score = 0;
        time = 0;
        end = false;
        timer = true;
        endMenu.SetActive(false);
        SceneManager.LoadScene(1);
    }
    public void Quit()
    {
        SceneManager.LoadScene(0);
    }

    public void EndMenu()
    {
        endMenu.SetActive(true);
        timer = false;
        if(highScore < score)
        {
            highScore = score;
        }
    }
}
