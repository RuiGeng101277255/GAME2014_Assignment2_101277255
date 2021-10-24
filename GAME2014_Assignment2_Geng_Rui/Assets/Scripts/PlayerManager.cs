/*
 Full Name: Rui Chen Geng Li (101277255)
 File Name: PlayerManager.cs
 Last Modified: October 24th, 2021
 Description: Manages the player attacks that can be placed in the game scene
 Version History: v1.04 Cleaned Up Codes and Comments
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    //Types of attacks and prefabs
    public PlayerAttackScript Scythe;
    public PlayerAttackScript Hammer;
    public PlayerAttackScript Rifle;
    public PlayerAttackScript Bomb;

    public void PlacePlayer(AttackTypes type, Vector3 pos, float rot)
    {
        //Places a player attack based on the chosen type, the position from the grid and a rotation
        //Placing an attack would cost a specific amount of resources

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

            //Manually setting the rotation and transform of the attack due to some possible grid placement errors
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

                //appropiate rotation and sets the attack active
                attack.transform.Rotate(new Vector3(0.0f, 0.0f, 1.0f), rot);
                attack.setRotation(rot);
                attack.gameObject.SetActive(true);
            }
        }
    }
}
