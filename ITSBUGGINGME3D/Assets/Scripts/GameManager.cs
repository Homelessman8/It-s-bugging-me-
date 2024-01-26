using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Variables


    private void Awake()
    {
        
    }

    private void Start()
    {
        
    }

    //public void Change state method


    //--------------

    //Methods needed


    private void StartGame()
    {

    }

    public void Pause()
    {
        Debug.Log("Paused");
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;

        //Add setActive.true pause menu panel
    }


    public void UnPause()
    {
        Debug.Log("Back to Game");
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;

        //Add setActive.false pause menu panel
    }

    public void RestartLevel()
    {

    }

    public void GameOver()
    {
        //SetActive.true 
    }
}
