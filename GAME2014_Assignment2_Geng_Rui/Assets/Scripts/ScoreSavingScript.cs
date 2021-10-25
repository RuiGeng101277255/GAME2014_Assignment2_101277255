/*
 Full Name: Rui Chen Geng Li (101277255)
 File Name: ScoreSavingScript.cs
 Last Modified: October 24th, 2021
 Description: Using a static class instead to save data, otherwise error occured with streamreader/writer
 Version History: v1.02 changed from using stream readers and writer to a static class since score is just a number
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScoreSavingScript
{
    public static int Score { get; set; }
}
