/*
 Full Name: Rui Chen Geng Li (101277255)
 File Name: EnemyManager.cs
 Last Modified: October 24th, 2021
 Description: This is the enemy manager that has the enemy queues and manages the spawn/return of enemies
 Version History: v1.10 Cleaned Up Codes and Comments
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    //Sets up the path trigger boxes for the enemy guidance
    //Variables for enemies
    public List<TriggerBoxScript> PathTriggerBoxes;
    public CatEnemyScript CatPrefab;
    public SlimeEnemyScript SlimePrefab;
    public Vector2 spawnPosition;
    public int SpawnedSlimeNum;
    public int SpawnedCatNum;

    //random spawn delay for each enemy
    float SlimeSpawnDelay;
    float CatSpawnDelay;

    //enemy queue/pools
    Queue<SlimeEnemyScript> SlimePool;
    Queue<CatEnemyScript> CatPool;

    // Start is called before the first frame update
    void Start()
    {
        //initial delay of 0 so there is an enemy of each type spawning right away
        SlimeSpawnDelay = 0.0f;
        CatSpawnDelay = 0.0f;

        //empty queues
        SlimePool = new Queue<SlimeEnemyScript>();
        CatPool = new Queue<CatEnemyScript>();
        SpawnedSlimeNum = 0;
        SpawnedCatNum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Based on if each of the delays is <= 0. If so, then spawn the enemy

        if (SlimeSpawnDelay <= 0.0f)
        {
            spawnSlime();
        }
        else
        {
            SlimeSpawnDelay -= Time.deltaTime;
        }

        if (CatSpawnDelay <= 0.0f)
        {
            spawnCat();
        }
        else
        {
            CatSpawnDelay -= Time.deltaTime;
        }
    }

    void spawnSlime()
    {
        //spawns a new slime
        if (SlimePool.Count < 1)
        {
            //if the pool is empty, then create a new slime
            createSlime();
        }

        //if pool has inactive slimes, then activate that
        SlimeEnemyScript tempSlime = SlimePool.Dequeue();
        tempSlime.gameObject.SetActive(true);
        tempSlime.GetComponent<Rigidbody2D>().position = spawnPosition;

        //random delay
        SlimeSpawnDelay = Random.Range(0.0f, 5.0f);
        SpawnedSlimeNum++;
    }

    void spawnCat()
    {
        //spawns a new cat
        if (CatPool.Count < 1)
        {
            //empty pool would create a new cat object
            createCat();
        }

        //if pool is not empty, then dequeue one
        CatEnemyScript tempCat = CatPool.Dequeue();
        tempCat.gameObject.SetActive(true);
        tempCat.GetComponent<Rigidbody2D>().position = spawnPosition;

        //random delay
        CatSpawnDelay = Random.Range(0.5f, 10.0f);
        SpawnedCatNum++;
    }

    void createSlime()
    {
        //creates a new slime game object
        SlimeEnemyScript tempSlime = Instantiate(SlimePrefab);
        tempSlime.GetComponent<Rigidbody2D>().position = spawnPosition;
        tempSlime.gameObject.SetActive(false);
        SlimePool.Enqueue(tempSlime);
    }

    void createCat()
    {
        //creates a new cat game object
        CatEnemyScript tempCat = Instantiate(CatPrefab);
        tempCat.GetComponent<Rigidbody2D>().position = spawnPosition;
        tempCat.gameObject.SetActive(false);
        CatPool.Enqueue(tempCat);
    }

    public void PointTriggeredByCat(CatEnemyScript cat, TriggerBoxScript box)
    {
        //target guidance for cat enemies
        if (box != null)
        {
            cat.setTargetPosition(box.transform.position);
        }
    }
    public void PointTriggeredBySlime(SlimeEnemyScript slime, TriggerBoxScript box)
    {
        //target guidance for slime enemies
        if (box != null)
        {
            slime.setTargetPosition(box.transform.position);
        }
    }

    public void returnSlime(SlimeEnemyScript slime)
    {
        //returns a slime to the slime queue
        slime.gameObject.SetActive(false);
        SlimePool.Enqueue(slime);
    }

    public void returnCat(CatEnemyScript cat)
    {
        //returns the cat to the cat queue
        cat.gameObject.SetActive(false);
        CatPool.Enqueue(cat);
    }
}
