/*
 Full Name: Rui Chen Geng Li (101277255)
 File Name: LootScript.cs
 Last Modified: October 24th, 2021
 Description: This is the loot object script
 Version History: v1.07 added sound effects
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LootScript : MonoBehaviour
{
    //Variables to set up the type of the loot and the quantity each object contains
    public string type;
    public int quantity = 5;

    AudioSource sfx;
    Image img;
    bool clicked;

    private void Start()
    {
        sfx = GetComponent<AudioSource>();
        img = GetComponent<Image>();
    }

    private void Update()
    {
        if (sfx != null)
        {
            if ((!sfx.isPlaying) && (clicked))
            {
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
                img.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                clicked = false;
            }
        }
    }

    public void clickedLoot()
    {
        //Depending on the loot clicked it will add the amount to the resources in the UI system and returns the loot to their corresponding queue

        sfx.Play();
        img.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
        clicked = true;
    }
}
