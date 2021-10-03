////////////////////////////////////////////////////////////////////////////////////////////////
///
/// SceneChangeScript.cs
/// Rui Chen Geng Li (101277255)
/// Last Mod: Oct 3rd, 2021
/// Description:
/// Scene Change for the button clicking events
/// Modified to include header info
/// 
////////////////////////////////////////////////////////////////////////////////////////////////


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
