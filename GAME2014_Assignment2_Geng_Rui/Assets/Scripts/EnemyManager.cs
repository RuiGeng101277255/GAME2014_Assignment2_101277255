using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public List<TriggerBoxScript> PathTriggerBoxes;
    public CatEnemyScript CatPrefab;
    public SlimeEnemyScript EnemyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //checkCatEnemyPath();
    }

    public void PointTriggeredByCat(CatEnemyScript cat, TriggerBoxScript box)
    {
        if (box != null)
        {
            cat.setTargetPosition(box.transform.position);
        }
    }
    public void PointTriggeredBySlime(SlimeEnemyScript slime, TriggerBoxScript box)
    {
        if (box != null)
        {
            slime.setTargetPosition(box.transform.position);
        }
    }

    //void checkCatEnemyPath()
    //{
    //    if ((CatPrefab.reachedTurnPoint == 0)||(CatPrefab.reachedTurnPoint == 4))
    //    {
    //        //move right
    //        CatPrefab.setNewDirection(new Vector2(1.0f, 0.0f));
    //        CatPrefab.setCatPosition(new Vector2(CatPrefab.getCatPosition().x, EnemyPathPoints[CatPrefab.reachedTurnPoint]. .y));
    //    }
    //    else if (((CatPrefab.reachedTurnPoint == 1) || (CatPrefab.reachedTurnPoint == 3))||(CatPrefab.reachedTurnPoint == 5))
    //    {
    //        //move down
    //        CatPrefab.setNewDirection(new Vector2(0.0f, -1.0f));
    //        CatPrefab.setCatPosition(new Vector2(CatPrefab.getCatPosition().x, EnemyPathPoints[CatPrefab.reachedTurnPoint].y));
    //    }
    //    else if (CatPrefab.reachedTurnPoint == 2)
    //    {
    //        //move left
    //        CatPrefab.setNewDirection(new Vector2(-1.0f, 0.0f));
    //        CatPrefab.setCatPosition(new Vector2(CatPrefab.getCatPosition().x, EnemyPathPoints[CatPrefab.reachedTurnPoint].y));
    //    }
    //}
}
