using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public List<TriggerBoxScript> PathTriggerBoxes;
    public CatEnemyScript CatPrefab;
    public SlimeEnemyScript SlimePrefab;
    public Vector2 spawnPosition;

    float SlimeSpawnDelay;
    float CatSpawnDelay;

    Queue<SlimeEnemyScript> SlimePool;
    Queue<CatEnemyScript> CatPool;

    [SerializeField]
    int SpawnedSlimeNum;
    [SerializeField]
    int SpawnedCatNum;

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

    void spawnSlime()
    {
        SlimeEnemyScript tempSlime = null;

        if (SlimePool.Count < 1)
        {
            createSlime();
        }

        tempSlime = SlimePool.Dequeue();
        tempSlime.transform.position = spawnPosition;
        tempSlime.gameObject.SetActive(true);

        SlimeSpawnDelay = Random.Range(0.15f, 5.0f);
        SpawnedSlimeNum++;
    }

    void spawnCat()
    {
        CatEnemyScript tempSlime = null;

        if (CatPool.Count < 1)
        {
            createCat();
        }

        tempSlime = CatPool.Dequeue();
        tempSlime.transform.position = spawnPosition;
        tempSlime.gameObject.SetActive(true);

        CatSpawnDelay = Random.Range(0.15f, 7.5f);
        SpawnedCatNum++;
    }

    void createSlime()
    {
        SlimeEnemyScript tempSlime = Instantiate(SlimePrefab);
        tempSlime.transform.position = spawnPosition;
        tempSlime.gameObject.SetActive(false);
        SlimePool.Enqueue(tempSlime);
    }

    void createCat()
    {
        CatEnemyScript tempCat = Instantiate(CatPrefab);
        tempCat.transform.position = spawnPosition;
        tempCat.gameObject.SetActive(false);
        CatPool.Enqueue(tempCat);
    }
}
