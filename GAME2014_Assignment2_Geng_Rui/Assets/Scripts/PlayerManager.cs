using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public PlayerAttackScript Scythe;
    public PlayerAttackScript Hammer;
    public PlayerAttackScript Rifle;
    public PlayerAttackScript Bomb;

    private AttackTypes setType;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlacePlayer(Vector3 pos, float rot)
    {
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
                attack.transform.position = pos;
                //attack.transform.SetParent(transform);
                //attack.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
                attack.transform.Rotate(new Vector3(0.0f, 0.0f, 1.0f), rot);
                attack.gameObject.SetActive(true);
            }
        }
    }
}
