using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeScript : MonoBehaviour
{
    public void GoToScene(string s)
    {
        if (s != "QUIT")
        {
            SceneManager.LoadScene(s, LoadSceneMode.Single);
        }
        else
        {
            Application.Quit();
        }
    }
}
