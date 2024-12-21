using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonHandler : MonoBehaviour
{
    GameObject audio1;
    AudioManager audioManager1;

    public static MenuButtonHandler instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        audio1 = GameObject.Find("AudioManager");
        audioManager1 = audio1.GetComponent<AudioManager>();
    }
    public void onclickMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void onclickStartGame()
    {
        SceneManager.LoadScene(1);
        if(Time.timeScale != 1)
        {
            Time.timeScale = 1;
        }
      
        audioManager1.PlayODE();
    }

    public void onclickControls()
    {
        SceneManager.LoadScene(2);
    }

    public void onclickExit()
    {
        Application.Quit();
    }

    public void onclickResume()
    {
        GetComponent<Pausemenu>().Resume();
    }
}
