using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void LoadScene0()
    {
        SceneManager.LoadScene(0);
    }    

    public void LoadScene1()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadScene2()
    {
        SceneManager.LoadScene(2);
    }


    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Exited Game");
    }

}
