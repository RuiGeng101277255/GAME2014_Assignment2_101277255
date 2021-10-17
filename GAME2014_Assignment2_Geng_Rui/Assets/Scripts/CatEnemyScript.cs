using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatEnemyScript : MonoBehaviour
{
    public float moveSpeed;

    Rigidbody2D CatRB;

    bool isMoving;
    int Health;
    Vector2 moveDirection;

    // Start is called before the first frame update
    void Start()
    {
        CatRB = GetComponent<Rigidbody2D>();

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
                //CatRB.position += moveDirection * moveSpeed;
            }
        }
        else
        {
            CatDeath();
        }
    }

    public void setNewDirection(Vector2 dir)
    {
        moveDirection = dir;
    }

    public void CauseDamage(int damage)
    {
        Health -= damage;
    }

    void CatDeath()
    {
        //destroy cat and spawns some loot
    }
}
