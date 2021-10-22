using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLayout : MonoBehaviour
{
    public GameObject PlaceableGrids;

    private SpriteRenderer spriteR;

    // Start is called before the first frame update
    void Start()
    {
        spriteR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetPlayerType (AttackTypes type)
    {
        //spawn player

        spriteR.color = Color.black;

        //...
        //PlaceableGrids.SetActive(false);
    }

    public void PlacePlayer()
    {
        Debug.Log("Clicked");
        spriteR.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
        Destroy(this);
    }
}
