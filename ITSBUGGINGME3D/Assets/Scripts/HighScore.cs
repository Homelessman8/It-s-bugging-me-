using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using TMPro;

public class HighScore : MonoBehaviour
{

    //reference player script that is attached to the Main camera
    private NewBehaviourScript player;

    //Referencing the Game manager script 
    public GameManager gameManager;

    //Reference to the text
    public TextMeshProUGUI ScoreText;
    public float Score;

    public TextMeshProUGUI HighScoreText;
    public float Highscore;

    //player health
    public TextMeshProUGUI Health;
    public float Healthpoint;

    //State of the player 
    private bool isDead;

    // Start is called before the first frame update
    void Start()
    {
        //Delete high score. Comment when not needed. Call it when clicking on game reset button
        //PlayerPrefs.DeleteKey("Highscore");

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
        Highscore = PlayerPrefs.GetFloat("Highscore");
        HighScoreText.text = /*"High Score: " +*/ Highscore.ToString();
        ScoreText.text = /*"Score: " +*/ Score.ToString();
        Health.text = /*"Health: " +*/ Healthpoint.ToString();  

        //If the player is dead, save high score
        //if (player == null) 
        //{
        //    SaveHighScore();
        //}
        if (Healthpoint <= 0 && !isDead) 
        {
            Highscore = PlayerPrefs.GetFloat("Highscore");
            SaveHighScore();
            //Activate player death, only enabled once 
            isDead = true;
            //Then transition to GAME OVER scene
            gameManager.GameOver();
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
