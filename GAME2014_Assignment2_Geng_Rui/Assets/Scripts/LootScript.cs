/*
 Full Name: Rui Chen Geng Li (101277255)
 File Name: LootScript.cs
 Last Modified: October 24th, 2021
 Description: This is the loot object script
 Version History: v1.06 Cleaned Up Codes and Comments
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootScript : MonoBehaviour
{
    //Variables to set up the type of the loot and the quantity each object contains
    public string type;
    public int quantity = 5;

    public void clickedLoot()
    {
        //Depending on the loot clicked it will add the amount to the resources in the UI system and returns the loot to their corresponding queue

        var manager = FindObjectOfType<LootManagerScript>();
        var LootUI = FindObjectOfType<UIScoresNItemsScript>();

        switch (type)
        {
            case "coin":
                LootUI.addResources(quantity, 0, 0);
                manager.returnCoin(this);
                break;
            case "gem":
                LootUI.addResources(0, quantity, 0);
                manager.returnGem(this);
                break;
            case "potion":
                LootUI.addResources(0, 0, quantity);
                manager.returnPotion(this);
                break;
            default:
                break;
        }
    }
}
