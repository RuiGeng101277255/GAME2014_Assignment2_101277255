using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystemScript : MonoBehaviour
{
    public GameObject InventoryObject;
    public GameObject ButtonObj;

    public void OpenInventory()
    {
        InventoryObject.SetActive(true);
        ButtonObj.SetActive(false);
    }

    public void SelectType(string s)
    {
        InventoryObject.SetActive(false);
        ButtonObj.SetActive(true);
    }
}
