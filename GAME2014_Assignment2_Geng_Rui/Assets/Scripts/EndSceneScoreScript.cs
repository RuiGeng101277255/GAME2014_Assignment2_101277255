/*
 Full Name: Rui Chen Geng Li (101277255)
 File Name: EndSceneScoreScript.cs
 Last Modified: October 24th, 2021
 Description: This is the end scene score script, responsible for displaying player's score
 Version History: v1.01 StreamReader reads the score text from the saved file and loads it onto the screen.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class EndSceneScoreScript : MonoBehaviour
{
    //Score text with the amount
    Text ScoreText;

    // Start is called before the first frame update
    void Start()
    {
        ScoreText = GetComponent<Text>();

        //Reader reads a line from the specified file (which is the score but in string format) and set to be part of the scoretext.
        StreamReader scoreReader = new StreamReader(Application.dataPath + Path.DirectorySeparatorChar + "Score.txt");
        string scoreString = scoreReader.ReadLine();

        ScoreText.text = "Final Score: " + scoreString;
    }
}
