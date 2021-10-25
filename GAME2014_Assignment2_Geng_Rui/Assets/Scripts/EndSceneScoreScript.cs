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

public class EndSceneScoreScript : MonoBehaviour
{
    //Score text with the amount
    Text ScoreText;

    // Start is called before the first frame update
    void Start()
    {
        ScoreText = GetComponent<Text>();
        ScoreText.text = "Final Score: " + ScoreSavingScript.Score;
    }
}
