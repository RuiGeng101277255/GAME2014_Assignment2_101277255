/*
 Full Name: Rui Chen Geng Li (101277255)
 File Name: CatEnemyScript.cs
 Last Modified: October 24th, 2021
 Description: This is the core structed of the cat type enemy
 Version History: v1.10 added max health variable so cats become harder to kill as they die
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatEnemyScript : MonoBehaviour
{
    //Variables that define the cat movement speeds
    public float moveSpeed;

    //Rigidbody and sprite for correct display and orientation
    Rigidbody2D CatRB;
    Animator CatAnim;
    SpriteRenderer CatSprite;

    //Cat status
    public bool isMoving;
    int Health;
    int MaxHealth;
    int DamageStrength;
    int catWorth;
    Vector2 moveDirection;

    //Enemy Manager
    EnemyManager manager;

    AudioSource sfx;

    // Start is called before the first frame update
    void Start()
    {
        //Gets the cat's component and set up the initial status values

        CatRB = GetComponent<Rigidbody2D>();
        CatAnim = GetComponent<Animator>();
        CatSprite = GetComponent<SpriteRenderer>();
        sfx = GetComponent<AudioSource>();

        manager = FindObjectOfType<EnemyManager>();

        isMoving = true;
        Health = 500;
        MaxHealth = Health;
        DamageStrength = 60;
        catWorth = 350;
        moveDirection = new Vector2(1.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Health > 0)
        {
            //If cat is alive, then see if it moves
            if (isMoving)
            {
                CatRB.position += moveDirection * moveSpeed;
            }
        }
        else
        {
            if (isMoving)
            {
                sfx.Play();
                CatSprite.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
                isMoving = false;
            }
            else
            {
                if (!sfx.isPlaying)
                {
                    //If cat is dead, aka killed by player by reducing health, then it rewards a score amount
                    var UIInfo = FindObjectOfType<UIScoresNItemsScript>();
                    UIInfo.addScore(catWorth);

                    CatDeath();
                }
            }
        }
    }

    public void setTargetPosition(Vector2 target)
    {
        //Sets where cat should be moved next
        calcDirection(CatRB.position, target);
    }
    public void CauseDamage(int damage)
    {
        //player's damage to the enemy
        Health -= damage;
    }

    public int getCatDamage()
    {
        //gets the cat's damage for the player's base
        return DamageStrength;
    }

    public void CatDeath()
    {
        //destroy cat and spawns some loot
        MaxHealth += 200;
        Health = MaxHealth;
        isMoving = true;
        CatSprite.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        manager.returnCat(this);
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
                CatSprite.flipX = true;
            }
            else
            {
                moveDirection = new Vector2(-1.0f, 0.0f);
                CatSprite.flipX = false;
            }
            CatAnim.SetInteger("Direction", 1);
            CatRB.position = new Vector2(CatRB.position.x, target.y);
        }
        else
        {
            if (tempDirection.y >= 0)
            {
                moveDirection = new Vector2(0.0f, 1.0f);
                CatRB.position = new Vector2(target.x, CatRB.position.y);
                CatAnim.SetInteger("Direction", 0);
            }
            else
            {
                moveDirection = new Vector2(0.0f, -1.0f);
                CatRB.position = new Vector2(target.x, CatRB.position.y);
                CatAnim.SetInteger("Direction", 2);
            }
        }
    }
}
