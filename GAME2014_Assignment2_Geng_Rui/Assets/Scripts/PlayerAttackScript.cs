using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackScript : MonoBehaviour
{
    public int AttackDamage;
    public float AttackIntervalDuration;

    float currentTimeInterval = 0.0f;
    bool canDamage = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTimeInterval > 0.0f)
        {
            currentTimeInterval -= Time.deltaTime;
        }
        else
        {
            canDamage = true;
            currentTimeInterval = 0.0f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (canDamage)
        {
            if (collision.gameObject.GetComponent<CatEnemyScript>() != null)
            {
                collision.gameObject.GetComponent<CatEnemyScript>().CauseDamage(AttackDamage);
                //collision.gameObject.GetComponent<CatEnemyScript>().setTargetPosition(new Vector2(-10.5f, 5.5f));
                currentTimeInterval = AttackIntervalDuration;
                canDamage = false;
            }
            
            if (collision.gameObject.GetComponent<SlimeEnemyScript>() != null)
            {
                collision.gameObject.GetComponent<SlimeEnemyScript>().CauseDamage(AttackDamage);
                //collision.gameObject.GetComponent<SlimeEnemyScript>().setTargetPosition(new Vector2(-10.5f, 5.5f));
                currentTimeInterval = AttackIntervalDuration;
                canDamage = false;
            }
        }
    }
}
