using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLayout : MonoBehaviour
{
    public GameObject PlaceableGrids;
    public float ZRot;
    public bool Flip = false;
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
        setType = AttackTypes.SCYTHE;
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
        
        if (setType != AttackTypes.NONE)
        {
            PlayerAttackScript attack = null;

            switch (setType)
            {
                case AttackTypes.SCYTHE:
                    attack = MonoBehaviour.Instantiate(Scythe);
                    break;
                case AttackTypes.HAMMER:
                    attack = MonoBehaviour.Instantiate(Hammer);
                    break;
                case AttackTypes.RIFLE:
                    attack = MonoBehaviour.Instantiate(Rifle);
                    break;
                case AttackTypes.BOMB:
                    attack = MonoBehaviour.Instantiate(Bomb);
                    break;
            }

            if (attack != null)
            {
                attack.transform.SetParent(transform);
                //attack.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
                attack.transform.Rotate(new Vector3(0.0f, 0.0f, 1.0f), ZRot);
                attack.gameObject.SetActive(true);
            }
        }
        

        //Destroy(this);
    }
}
