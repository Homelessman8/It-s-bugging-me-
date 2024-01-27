using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScore : MonoBehaviour
{

    //reference player script that is attached to the Main camera
    //PLACEHOLDER name of script 
    private NewBehaviourScript player;

    //Reference to the text
    public TextMeshProUGUI ScoreText;
    public float Score;

    public TextMeshProUGUI HighScoreText;
    public float Highscore;

    //player health
    public TextMeshProUGUI Health;
    public float Healthpoint;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<NewBehaviourScript>();

        //Check if there is already a high score at the start of game
        if (PlayerPrefs.HasKey("Highscore"))
        {
            Highscore = PlayerPrefs.GetFloat("Highscore");
        }
        //otherwise reset high score to 0 
        else
        {
            Highscore = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        HighScoreText.text = "High Score: " + Highscore.ToString();
        ScoreText.text = "Score: " + Score.ToString();
        Health.text = "Health: " + Healthpoint.ToString();  

        //If the player is dead, save high score
        //if (player == null) 
        //{
        //    SaveHighScore();
        //}
        if (Healthpoint <= 0) 
        {
            SaveHighScore();
        }

    }

    //When the game is over, update high score 
    public void SaveHighScore()
    {
        //update high score if score is greater than previous high score
        if (Score > PlayerPrefs.GetFloat("Highscore"))
        {
            PlayerPrefs.SetFloat("Highscore", Score);
        }
    }
}
