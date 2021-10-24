using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public PlayerAttackScript Scythe;
    public PlayerAttackScript Hammer;
    public PlayerAttackScript Rifle;
    public PlayerAttackScript Bomb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlacePlayer(AttackTypes type, Vector3 pos, float rot)
    {
        var UIAmount = FindObjectOfType<UIScoresNItemsScript>();

        if (type != AttackTypes.NONE)
        {
            PlayerAttackScript attack = null;

            switch (type)
            {
                case AttackTypes.SCYTHE:
                    attack = MonoBehaviour.Instantiate(Scythe);
                    UIAmount.useResources(UIAmount.getCosts(AttackTypes.SCYTHE));
                    break;
                case AttackTypes.HAMMER:
                    attack = MonoBehaviour.Instantiate(Hammer);
                    UIAmount.useResources(UIAmount.getCosts(AttackTypes.HAMMER));
                    break;
                case AttackTypes.RIFLE:
                    attack = MonoBehaviour.Instantiate(Rifle);
                    UIAmount.useResources(UIAmount.getCosts(AttackTypes.RIFLE));
                    break;
                case AttackTypes.BOMB:
                    attack = MonoBehaviour.Instantiate(Bomb);
                    UIAmount.useResources(UIAmount.getCosts(AttackTypes.BOMB));
                    break;
            }

            if (attack != null)
            {
                if (rot == 0.0f)
                {
                    attack.transform.position = pos - new Vector3(0.0f, 0.5f, 0.0f);
                }
                else if (rot == 180.0f)
                {
                    attack.transform.position = pos + new Vector3(0.0f, 0.5f, 0.0f);
                }
                else if (rot == 45.0f)
                {
                    attack.transform.position = pos - new Vector3(-0.5f, 0.5f, 0.0f);
                }
                else if (rot == -45.0f)
                {
                    attack.transform.position = pos + new Vector3(-1.0f, -1.0f, 0.0f);
                }
                else if (rot == 90.0f)
                {
                    attack.transform.position = pos + new Vector3(0.5f, 0.0f, 0.0f);
                }
                else if (rot == -90.0f)
                {
                    attack.transform.position = pos + new Vector3(-1.0f, 0.0f, 0.0f);
                }
                else if (rot == -135.0f)
                {
                    attack.transform.position = pos + new Vector3(-0.5f, 0.5f, 0.0f);
                }
                else
                {
                    attack.transform.position = pos;
                }
                //attack.transform.SetParent(transform);
                //attack.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
                attack.transform.Rotate(new Vector3(0.0f, 0.0f, 1.0f), rot);
                attack.gameObject.SetActive(true);
            }
        }
    }
}
