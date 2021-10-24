/*
 Full Name: Rui Chen Geng Li (101277255)
 File Name: UIScoresNItemsScript.cs
 Last Modified: October 24th, 2021
 Description: UI System for the score, coin, gem, potion and health text display. Along with the calculation for the weapon costs (so the player can afford them), and health
                If the player's health goes <= 0, the game will load the game over scene along with a saved score.
 Version History: v1.08 Cleaned Up Codes and Comments
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class UIScoresNItemsScript : MonoBehaviour
{
    //Text objects for the game play information
    public Text score;
    public Text coins;
    public Text gems;
    public Text potions;
    public Text health;

    //Corresponding values to the text display objects
    private int scoreNum;
    private int coinNum;
    private int gemNum;
    private int potionNum;
    private int MaxHealth;
    private int CurrentHealth;

    //Cost of the attack methods
    private List<int> scytheCosts = new List<int>{ 4, 4, 1 };
    private List<int> hammerCosts = new List<int> { 5, 3, 2 };
    private List<int> rifleCosts = new List<int> { 3, 2, 4 };
    private List<int> bombCosts = new List<int> { 3, 4, 5 };

    // Start is called before the first frame update
    void Start()
    {
        //Initial values
        scoreNum = 0;
        coinNum = 0;
        gemNum = 0;
        potionNum = 0;
        MaxHealth = 100;
        CurrentHealth = MaxHealth;

        setTextContent();
    }

    // Update is called once per frame
    void Update()
    {
        setTextContent();

        //If player dies, then a stream writer is used to write the score into Score.txt file, so that the gameover scene loaded in the next lines can access it without this scene's information.
        if (CurrentHealth <= 0)
        {
            StreamWriter scoreWriter = new StreamWriter(Application.dataPath + Path.DirectorySeparatorChar + "Score.txt");
            scoreWriter.WriteLine(scoreNum);
            scoreWriter.Close();
            UnityEngine.SceneManagement.SceneManager.LoadScene("GameOverScene", UnityEngine.SceneManagement.LoadSceneMode.Single);
        }
    }

    void setTextContent()
    {
        //Updates the texts that are being displayed
        score.text = "Score: " + scoreNum;
        coins.text = coinNum.ToString();
        gems.text = gemNum.ToString();
        potions.text = potionNum.ToString();
        health.text = "Health: " + CurrentHealth;
        //Changes color of health based on how close/far away the health is from full health
        health.color = new Color((1.0f - (CurrentHealth / MaxHealth)), (CurrentHealth / MaxHealth), 0.0f, 1.0f);
    }

    public void addScore(int s)
    {
        //Add score
        scoreNum += s;
    }

    public void addResources(int coin, int gem, int potion)
    {
        //Add loot resources that are being picked up
        coinNum += coin;
        gemNum += gem;
        potionNum += potion;
    }

    public int getHealth()
    {
        //Returns the base's health
        return CurrentHealth;
    }
    public void setDamage(int d)
    {
        //Damages the base
        CurrentHealth -= d;
    }

    public int getCoinNum()
    {
        //returns coins collected
        return coinNum;
    }

    public int getGemNum()
    {
        //returns gems collected
        return gemNum;
    }

    public int getPotionNum()
    {
        //returns potions collected
        return potionNum;
    }
    public void useResources(List<int> costs)
    {
        //uses recourses for a specific amount when a player attack is being placed.
        coinNum -= costs[0];
        gemNum -= costs[1];
        potionNum -= costs[2];
    }

    public List<int> getCosts(AttackTypes type)
    {
        //checks the costs for each of the attack type
        switch (type)
        {
            case AttackTypes.SCYTHE:
                return scytheCosts;
                break;
            case AttackTypes.HAMMER:
                return hammerCosts;
                break;
            case AttackTypes.RIFLE:
                return rifleCosts;
                break;
            case AttackTypes.BOMB:
                return bombCosts;
                break;
            default:
                return null;
                break;
        }
    }

    public bool checkIfCanPlaceAttack(AttackTypes type)
    {
        //checks if there is enough resources for a chosen attack type, then return true. Else returns false

        switch (type)
        {
            case AttackTypes.SCYTHE:
                if ((scytheCosts[0] <= coinNum) && (scytheCosts[1] <= gemNum) && (scytheCosts[2] <= potionNum))
                {
                    return true;
                }
                break;
            case AttackTypes.HAMMER:
                if ((hammerCosts[0] <= coinNum) && (hammerCosts[1] <= gemNum) && (hammerCosts[2] <= potionNum))
                {
                    return true;
                }
                break;
            case AttackTypes.RIFLE:
                if ((rifleCosts[0] <= coinNum) && (rifleCosts[1] <= gemNum) && (rifleCosts[2] <= potionNum))
                {
                    return true;
                }
                break;
            case AttackTypes.BOMB:
                if ((bombCosts[0] <= coinNum) && (bombCosts[1] <= gemNum) && (bombCosts[2] <= potionNum))
                {
                    return true;
                }
                break;
            default:
                break;
        }
        return false;
    }
}
