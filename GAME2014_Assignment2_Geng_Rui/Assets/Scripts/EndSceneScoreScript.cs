using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class EndSceneScoreScript : MonoBehaviour
{
    Text ScoreText;

    // Start is called before the first frame update
    void Start()
    {
        ScoreText = GetComponent<Text>();

        StreamReader scoreReader = new StreamReader(Application.dataPath + Path.DirectorySeparatorChar + "Score.txt");
        string scoreString = scoreReader.ReadLine();

        ScoreText.text = "Final Score: " + scoreString;
    }
}
