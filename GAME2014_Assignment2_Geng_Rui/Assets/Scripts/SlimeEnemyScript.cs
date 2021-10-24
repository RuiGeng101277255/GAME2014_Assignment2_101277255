/*
 Full Name: Rui Chen Geng Li (101277255)
 File Name: SlimeEnemyScript.cs
 Last Modified: October 24th, 2021
 Description: This is the core structed of the slime type enemy
 Version History: v1.09 Cleaned Up Codes and Comments
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeEnemyScript : MonoBehaviour
{
    //Variables that define the slime movement speeds
    public float moveSpeed;

    //Rigidbody and sprite for correct display and orientation
    Rigidbody2D SlimeRB;
    SpriteRenderer SlimeSprite;

    //Slime status
    bool isMoving;
    int Health;
    int DamageStrength;
    int slimeWorth;
    Vector2 moveDirection;

    //Enemy Manager
    EnemyManager manager;

    // Start is called before the first frame update
    void Start()
    {
        //Gets the slime's component and set up the initial status values

        SlimeRB = GetComponent<Rigidbody2D>();
        SlimeSprite = GetComponent<SpriteRenderer>();

        manager = FindObjectOfType<EnemyManager>();

        isMoving = true;
        Health = 100;
        DamageStrength = 35;
        slimeWorth = 100;
        moveDirection = new Vector2(1.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Health > 0)
        {
            //If slime is alive, then see if it moves
            if (isMoving)
            {
                SlimeRB.position += moveDirection * moveSpeed;
            }
        }
        else
        {
            //If slime is dead, aka killed by player by reducing health, then it rewards a score amount
            var UIInfo = FindObjectOfType<UIScoresNItemsScript>();
            UIInfo.addScore(slimeWorth);

            SlimeDeath();
        }
    }

    public void setTargetPosition(Vector2 target)
    {
        //Sets where slime should be moved next
        calcDirection(SlimeRB.position, target);
    }
    public void CauseDamage(int damage)
    {
        //player's damage to the enemy
        Health -= damage;
    }
    public int getSlimeDamage()
    {
        //gets the slime's damage for the player's base
        return DamageStrength;
    }

    public void SlimeDeath()
    {
        //destroy cat and spawns some loot
        Health = 100;
        manager.returnSlime(this);
    }

    void calcDirection(Vector2 pos, Vector2 target)
    {
        //Calculates the moving direction and orientation for proper enemy display

        Vector2 tempDirection = target - pos;

        if (Mathf.Abs(tempDirection.x) > Mathf.Abs(tempDirection.y))
        {
            if (tempDirection.x >= 0)
            {
                moveDirection = new Vector2(1.0f, 0.0f);
                SlimeSprite.flipX = true;
            }
            else
            {
                moveDirection = new Vector2(-1.0f, 0.0f);
                SlimeSprite.flipX = false;
            }
            SlimeRB.position = new Vector2(SlimeRB.position.x, target.y);
        }
        else
        {
            if (tempDirection.y >= 0)
            {
                moveDirection = new Vector2(0.0f, 1.0f);
                SlimeRB.position = new Vector2(target.x, SlimeRB.position.y);
            }
            else
            {
                moveDirection = new Vector2(0.0f, -1.0f);
                SlimeRB.position = new Vector2(target.x, SlimeRB.position.y);
            }
        }
    }
}
