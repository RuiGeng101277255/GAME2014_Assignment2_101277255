using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public List<TriggerBoxScript> PathTriggerBoxes;
    public CatEnemyScript CatPrefab;
    public SlimeEnemyScript SlimePrefab;
    public Vector2 spawnPosition;
    public int SpawnedSlimeNum;
    public int SpawnedCatNum;

    float SlimeSpawnDelay;
    float CatSpawnDelay;

    Queue<SlimeEnemyScript> SlimePool;
    Queue<CatEnemyScript> CatPool;

    // Start is called before the first frame update
    void Start()
    {
        SlimeSpawnDelay = 0.0f;
        CatSpawnDelay = 0.0f;

        SlimePool = new Queue<SlimeEnemyScript>();
        CatPool = new Queue<CatEnemyScript>();
        SpawnedSlimeNum = 0;
        SpawnedCatNum = 0;
    }

    // Update is called once per frame
    void Update()
    {
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
        if (SlimePool.Count < 1)
        {
            createSlime();
        }

        SlimeEnemyScript tempSlime = SlimePool.Dequeue();
        tempSlime.gameObject.SetActive(true);
        tempSlime.GetComponent<Rigidbody2D>().position = spawnPosition;

        SlimeSpawnDelay = Random.Range(0.0f, 5.0f);
        SpawnedSlimeNum++;
    }

    void spawnCat()
    {
        if (CatPool.Count < 1)
        {
            createCat();
        }

        CatEnemyScript tempCat = CatPool.Dequeue();
        tempCat.gameObject.SetActive(true);
        tempCat.GetComponent<Rigidbody2D>().position = spawnPosition;

        CatSpawnDelay = Random.Range(0.5f, 10.0f);
        SpawnedCatNum++;
    }

    void createSlime()
    {
        SlimeEnemyScript tempSlime = Instantiate(SlimePrefab);
        tempSlime.GetComponent<Rigidbody2D>().position = spawnPosition;
        tempSlime.gameObject.SetActive(false);
        SlimePool.Enqueue(tempSlime);
    }

    void createCat()
    {
        CatEnemyScript tempCat = Instantiate(CatPrefab);
        tempCat.GetComponent<Rigidbody2D>().position = spawnPosition;
        tempCat.gameObject.SetActive(false);
        CatPool.Enqueue(tempCat);
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

    public void returnSlime(SlimeEnemyScript slime)
    {
        slime.gameObject.SetActive(false);
        SlimePool.Enqueue(slime);
    }

    public void returnCat(CatEnemyScript cat)
    {
        cat.gameObject.SetActive(false);
        CatPool.Enqueue(cat);
    }
}
