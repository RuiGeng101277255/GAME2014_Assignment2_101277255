using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatEnemyScript : MonoBehaviour
{
    public float moveSpeed;

    Rigidbody2D CatRB;
    Animator CatAnim;
    SpriteRenderer CatSprite;

    bool isMoving;
    int Health;
    Vector2 moveDirection;

    EnemyManager manager;

    // Start is called before the first frame update
    void Start()
    {
        CatRB = GetComponent<Rigidbody2D>();
        CatAnim = GetComponent<Animator>();
        CatSprite = GetComponent<SpriteRenderer>();

        manager = FindObjectOfType<EnemyManager>();

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
                CatRB.position += moveDirection * moveSpeed;
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
        calcDirection(CatRB.position, target);
    }
    public void CauseDamage(int damage)
    {
        Health -= damage;
    }

    void CatDeath()
    {
        //destroy cat and spawns some loot
        Health = 100;
        manager.returnCat(this);
    }

    void calcDirection(Vector2 pos, Vector2 target)
    {
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
