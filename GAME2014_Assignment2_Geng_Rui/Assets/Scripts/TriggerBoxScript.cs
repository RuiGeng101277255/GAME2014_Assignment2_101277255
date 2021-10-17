using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBoxScript : MonoBehaviour
{
    public EnemyManager manager;
    public TriggerBoxScript nextBox;
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
        if (collision.gameObject.GetComponent<CatEnemyScript>())
        {
            manager.PointTriggeredByCat(collision.gameObject.GetComponent<CatEnemyScript>(), nextBox);
        }
        else if (collision.gameObject.GetComponent<SlimeEnemyScript>())
        {
            manager.PointTriggeredBySlime(collision.gameObject.GetComponent<SlimeEnemyScript>(), nextBox);
        }
    }
}
