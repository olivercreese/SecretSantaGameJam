using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonHandler : MonoBehaviour
{
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
