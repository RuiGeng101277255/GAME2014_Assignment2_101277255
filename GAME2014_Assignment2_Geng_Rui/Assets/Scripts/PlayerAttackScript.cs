/*
 Full Name: Rui Chen Geng Li (101277255)
 File Name: PlayerAttackScript.cs
 Last Modified: October 24th, 2021
 Description: This is the player attack script that defines the active damage intervals, amounts and types
 Version History: v1.07 Cleaned Up Codes and Comments
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackScript : MonoBehaviour
{
    //Variable for the attack damage, intervals, and types
    public int AttackDamage;
    public float AttackIntervalDuration;
    public AttackTypes type;

    //Attack conditions
    float currentTimeInterval = 0.0f;
    bool canDamage = false;
    BulletManager bulletManager = null;
    float playerRotation;

    // Update is called once per frame
    void Update()
    {
        //Only attack and be able to damage if interval is <= 0.0

        if (currentTimeInterval > 0.0f)
        {
            currentTimeInterval -= Time.deltaTime;
        }
        else
        {
            if (type == AttackTypes.RIFLE)
            {
                rifleAttack();
            }
            else if (type == AttackTypes.BOMB)
            {
                bombAttack();
            }
            else
            {
                canDamage = true;
                currentTimeInterval = 0.0f;
            }
        }
    }

    void rifleAttack()
    {
        //Rifle attack with bullets

        bulletManager = FindObjectOfType<BulletManager>();

        bulletManager.spawnBullet(transform.position, playerRotation, AttackDamage);

        //Bullet shooting intervals
        currentTimeInterval = 0.5f;
    }

    void bombAttack()
    {
        //Bomb attack with bomb

        bulletManager = FindObjectOfType<BulletManager>();

        bulletManager.spawnBomb(transform.position, playerRotation, AttackDamage);

        //bomb spawning intervals
        currentTimeInterval = 5.0f;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If attacks can cause damage, then cause a specific amount to the triggered enemy

        if (canDamage)
        {
            if (collision.gameObject.GetComponent<CatEnemyScript>() != null)
            {
                collision.gameObject.GetComponent<CatEnemyScript>().CauseDamage(AttackDamage);
                currentTimeInterval = AttackIntervalDuration;
                canDamage = false;
            }
            
            if (collision.gameObject.GetComponent<SlimeEnemyScript>() != null)
            {
                collision.gameObject.GetComponent<SlimeEnemyScript>().CauseDamage(AttackDamage);
                currentTimeInterval = AttackIntervalDuration;
                canDamage = false;
            }
        }
    }

    public void setRotation(float rot)
    {
        //set's the player's rotation that will be used for bullet and bomb spawning
        playerRotation = rot;
    }
}
