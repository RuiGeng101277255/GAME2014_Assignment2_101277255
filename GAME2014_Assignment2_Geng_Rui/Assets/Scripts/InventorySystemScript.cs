using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystemScript : MonoBehaviour
{
    public GameObject InventoryObject;
    public GameObject ButtonObj;

    public GameObject PlaceableGrids;
    public GameObject GridButtons;

    public void OpenInventory()
    {
        InventoryObject.SetActive(true);
        ButtonObj.SetActive(false);
    }

    public void SelectType(string s)
    {
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
