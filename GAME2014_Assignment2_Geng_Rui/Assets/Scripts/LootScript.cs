using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootScript : MonoBehaviour
{
    public string type;
    public int quantity = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void clickedLoot()
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
    }
}
