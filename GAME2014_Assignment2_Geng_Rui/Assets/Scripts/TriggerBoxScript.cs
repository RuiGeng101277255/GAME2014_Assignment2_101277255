using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBoxScript : MonoBehaviour
{
    public EnemyManager manager;
    public TriggerBoxScript nextBox;
    public bool isLastBox = false;
    public UIScoresNItemsScript UIInfo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isLastBox)
        {
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
