using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeEnemyScript : MonoBehaviour
{
    public float moveSpeed;

    Rigidbody2D SlimeRB;
    Animator SlimeAnim;
    SpriteRenderer SlimeSprite;

    bool isMoving;
    int Health;
    Vector2 moveDirection;

    // Start is called before the first frame update
    void Start()
    {
        SlimeRB = GetComponent<Rigidbody2D>();
        SlimeAnim = GetComponent<Animator>();
        SlimeSprite = GetComponent<SpriteRenderer>();

        isMoving = true;
        Health = 100;
        moveDirection = new Vector2(1.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Health > 0)
        {
            if (isMoving)
            {
                SlimeRB.position += moveDirection * moveSpeed;
                //CatAnim.SetBool("IsMoving", isMoving);
            }
        }
        else
        {
            //CatAnim.SetBool("IsMoving", isMoving);
            CatDeath();
        }
    }

    public void setTargetPosition(Vector2 target)
    {
        calcDirection(SlimeRB.position, target);
    }
    public void CauseDamage(int damage)
    {
        Health -= damage;
    }

    void CatDeath()
    {
        //destroy cat and spawns some loot
    }

    void calcDirection(Vector2 pos, Vector2 target)
    {
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
