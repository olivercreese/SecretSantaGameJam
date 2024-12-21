using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonHandler : MonoBehaviour
{
    public void onclickButton0()
    {
        SceneManager.LoadScene(0);
    }
    public void onclickButton1()
    {
        SceneManager.LoadScene(1);
    }

    public void onclickButton2()
    {
        SceneManager.LoadScene(2);
    }

    public void onclickButton3()
    {
        Application.Quit();
    }
}
