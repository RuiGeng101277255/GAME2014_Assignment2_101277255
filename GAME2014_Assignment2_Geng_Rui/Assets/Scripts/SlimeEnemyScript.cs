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
    int DamageStrength;
    Vector2 moveDirection;

    EnemyManager manager;

    // Start is called before the first frame update
    void Start()
    {
        SlimeRB = GetComponent<Rigidbody2D>();
        SlimeAnim = GetComponent<Animator>();
        SlimeSprite = GetComponent<SpriteRenderer>();

        manager = FindObjectOfType<EnemyManager>();

        isMoving = true;
        Health = 100;
        DamageStrength = 35;
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
            SlimeDeath();
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
    public int getSlimeDamage()
    {
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
