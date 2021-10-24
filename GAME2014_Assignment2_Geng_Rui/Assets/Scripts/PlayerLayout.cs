using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLayout : MonoBehaviour
{
    public GameObject PlaceableGrids;
    public GameObject GridButtons;
    public float ZRot;
    public bool Flip = false;
    public PlayerManager manager;

    private SpriteRenderer spriteR;
    private AttackTypes setType;

    // Start is called before the first frame update
    void Start()
    {
        spriteR = GetComponent<SpriteRenderer>();
        //setType = AttackTypes.SCYTHE;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetPlayerType (AttackTypes type)
    {
        //spawn player

        //spriteR.color = Color.black;
        setType = type;

        //...
        //PlaceableGrids.SetActive(false);
    }

    public void PlacePlayer()
    {
        manager.PlacePlayer(setType, transform.position, ZRot);
        Destroy(gameObject);

        PlaceableGrids.SetActive(false);
        GridButtons.SetActive(false);
    }
}
