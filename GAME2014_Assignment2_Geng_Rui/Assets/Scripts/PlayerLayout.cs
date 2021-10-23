using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLayout : MonoBehaviour
{
    public GameObject PlaceableGrids;
    public Vector2 RowColNum;
    public PlayerAttackScript Scythe;
    public PlayerAttackScript Hammer;
    public PlayerAttackScript Rifle;
    public PlayerAttackScript Bomb;

    private SpriteRenderer spriteR;
    private AttackTypes setType;

    // Start is called before the first frame update
    void Start()
    {
        spriteR = GetComponent<SpriteRenderer>();
        setType = AttackTypes.NONE;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetPlayerType (AttackTypes type)
    {
        //spawn player

        spriteR.color = Color.black;
        setType = type;

        //...
        //PlaceableGrids.SetActive(false);
    }

    public void PlacePlayer()
    {
        Debug.Log("Clicked");
        spriteR.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
        
        if ((setType != AttackTypes.NONE) && (setType != null))
        {
            switch (setType)
            {
                case AttackTypes.SCYTHE:
                    var tempNewPlayer = MonoBehaviour.Instantiate(Scythe);
                    //set orientation and active
                    break;

            }
        }
        

        Destroy(this);
    }
}
