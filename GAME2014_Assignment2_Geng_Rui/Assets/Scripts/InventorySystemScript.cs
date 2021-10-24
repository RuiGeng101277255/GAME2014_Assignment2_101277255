/*
 Full Name: Rui Chen Geng Li (101277255)
 File Name: InventorySystemScript.cs
 Last Modified: October 24th, 2021
 Description: This manages the inventory system and allows the player to chose an attack type.
 Version History: v1.03 Cleaned Up Codes and Comments
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystemScript : MonoBehaviour
{
    //Inventory object and the buttons that chooses player attack types
    public GameObject InventoryObject;
    public GameObject ButtonObj;

    //The grid system that allow the player to place the attack at any available areas
    public GameObject PlaceableGrids;
    public GameObject GridButtons;

    public void OpenInventory()
    {
        //Opens the inventory for the player to choose the attack type
        InventoryObject.SetActive(true);
        ButtonObj.SetActive(false);
    }

    public void SelectType(string s)
    {
        //Select and specify an attack type
        InventoryObject.SetActive(false);
        ButtonObj.SetActive(true);

        AttackTypes type;

        switch (s)
        {
            case "scythe":
                type = AttackTypes.SCYTHE;
                break;
            case "hammer":
                type = AttackTypes.HAMMER;
                break;
            case "rifle":
                type = AttackTypes.RIFLE;
                break;
            case "bomb":
                type = AttackTypes.BOMB;
                break;
            default:
                type = AttackTypes.NONE;
                break;
        }

        //Check if the player has enough resources to spawn the attack. If so, it'll display the grid system. Else, it will just close the inventory menu.

        var UIAmount = FindObjectOfType<UIScoresNItemsScript>();

        if (UIAmount.checkIfCanPlaceAttack(type))
        {
            PlaceableGrids.SetActive(true);
            GridButtons.SetActive(true);

            var LayoutGrids = FindObjectsOfType<PlayerLayout>();

            foreach (PlayerLayout p in LayoutGrids)
            {
                p.SetPlayerType(type);
            }
        }
    }
}
