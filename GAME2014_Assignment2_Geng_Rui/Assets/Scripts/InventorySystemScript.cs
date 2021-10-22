using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystemScript : MonoBehaviour
{
    public GameObject InventoryObject;
    public GameObject ButtonObj;
    public GameObject PlaceableGrids;

    public void OpenInventory()
    {
        InventoryObject.SetActive(true);
        ButtonObj.SetActive(false);
    }

    public void SelectType(string s)
    {
        InventoryObject.SetActive(false);
        ButtonObj.SetActive(true);
        PlaceableGrids.SetActive(true);

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
        PlaceableGrids.GetComponent<PlayerLayout>().SetPlayerType(type);
    }
}
