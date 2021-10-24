/*
 Full Name: Rui Chen Geng Li (101277255)
 File Name: TriggerBoxScript.cs
 Last Modified: October 24th, 2021
 Description: TriggerBox objects that will guide the enemies towards the player's base
 Version History: v1.06 Cleaned Up Codes and Comments
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBoxScript : MonoBehaviour
{
    //Variables that will allow the enemy manager to know which is the next target trigger box and whether it is the last box (player base) or not.
    public EnemyManager manager;
    public TriggerBoxScript nextBox;
    public bool isLastBox = false;
    public UIScoresNItemsScript UIInfo;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Checks and applies the correct trigger response
        if (!isLastBox)
        {
            //Guides the enemies to the next target
            if (collision.gameObject.GetComponent<CatEnemyScript>())
            {
                manager.PointTriggeredByCat(collision.gameObject.GetComponent<CatEnemyScript>(), nextBox);
            }
            else if (collision.gameObject.GetComponent<SlimeEnemyScript>())
            {
                manager.PointTriggeredBySlime(collision.gameObject.GetComponent<SlimeEnemyScript>(), nextBox);
            }
        }
        else
        {
            //If this is the last box (player's base) then the enemies will do their damages to the base before being sent back to their queues
            //Note: cat/slime death is not actual enemy death, so they will not give any score rewards but only damages the base
            if (collision.gameObject.GetComponent<CatEnemyScript>())
            {
                manager.PointTriggeredByCat(collision.gameObject.GetComponent<CatEnemyScript>(), nextBox);
                UIInfo.setDamage(collision.gameObject.GetComponent<CatEnemyScript>().getCatDamage());
                collision.gameObject.GetComponent<CatEnemyScript>().CatDeath();
            }
            else if (collision.gameObject.GetComponent<SlimeEnemyScript>())
            {
                manager.PointTriggeredBySlime(collision.gameObject.GetComponent<SlimeEnemyScript>(), nextBox);
                UIInfo.setDamage(collision.gameObject.GetComponent<SlimeEnemyScript>().getSlimeDamage());
                collision.gameObject.GetComponent<SlimeEnemyScript>().SlimeDeath();
            }
        }
    }
}
