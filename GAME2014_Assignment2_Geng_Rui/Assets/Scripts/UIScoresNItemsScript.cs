using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScoresNItemsScript : MonoBehaviour
{
    public Text score;
    public Text coins;
    public Text gems;
    public Text potions;
    public GameObject health;

    private int scoreNum;
    private int coinNum;
    private int gemNum;
    private int potionNum;
    private int MaxHealth;
    private int CurrentHealth;

    private List<int> scytheCosts = new List<int>{ 4, 4, 1 };
    private List<int> hammerCosts = new List<int> { 5, 3, 2 };
    private List<int> rifleCosts = new List<int> { 3, 2, 4 };
    private List<int> bombCosts = new List<int> { 3, 4, 5 };

    // Start is called before the first frame update
    void Start()
    {
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
    }

    void setTextContent()
    {
        score.text = "Score: " + scoreNum;
        coins.text = coinNum.ToString();
        gems.text = gemNum.ToString();
        potions.text = potionNum.ToString();
    }

    public void addScore(int s)
    {
        scoreNum += s;
    }

    public void addResources(int coin, int gem, int potion)
    {
        coinNum += coin;
        gemNum += gem;
        potionNum += potion;
    }

    public int getHealth()
    {
        return CurrentHealth;
    }
    public void setDamage(int d)
    {
        CurrentHealth -= d;
    }

    public int getCoinNum()
    {
        return coinNum;
    }

    public int getGemNum()
    {
        return gemNum;
    }

    public int getPotionNum()
    {
        return potionNum;
    }
    public void useResources(List<int> costs)
    {
        coinNum -= costs[0];
        gemNum -= costs[1];
        potionNum -= costs[2];
    }

    public List<int> getCosts(AttackTypes type)
    {
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
}
