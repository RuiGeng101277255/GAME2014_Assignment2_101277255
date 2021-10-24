using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootManagerScript : MonoBehaviour
{
    public UIScoresNItemsScript UIInformation;
    public LootScript coinPrefab;
    public LootScript gemPrefab;
    public LootScript potionPrefab;

    Queue<LootScript> coinQueue;
    Queue<LootScript> gemQueue;
    Queue<LootScript> potionQueue;

    float coinSpawnDelay;
    float gemSpawnDelay;
    float potionSpawnDelay;

    // Start is called before the first frame update
    void Start()
    {
        coinQueue = new Queue<LootScript>();
        gemQueue = new Queue<LootScript>();
        potionQueue = new Queue<LootScript>();

        coinSpawnDelay = 0.0f;
        gemSpawnDelay = 0.0f;
        potionSpawnDelay = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (coinSpawnDelay <= 0.0f)
        {
            spawnCoin();
        }
        else
        {
            coinSpawnDelay -= Time.deltaTime;
        }

        if (gemSpawnDelay <= 0.0f)
        {
            spawnGem();
        }
        else
        {
            gemSpawnDelay -= Time.deltaTime;
        }

        if (potionSpawnDelay <= 0.0f)
        {
            spawnPotion();
        }
        else
        {
            potionSpawnDelay -= Time.deltaTime;
        }
    }

    void spawnCoin()
    {
        //random position based on safe area of the screen
        Rect screenSize = Screen.safeArea;
        Vector2 randPosition = new Vector2(Random.Range(-(screenSize.width / 2) + 10.0f, (screenSize.width /2) - 10.0f), Random.Range(-(screenSize.height / 2) + 10.0f, (screenSize.height / 2) - 10.0f));
        
        //Temp Coin creation, null
        LootScript tempCoin = null;

        if (coinQueue.Count < 1)
        {
            //creates a new coin if the queue is empty
            tempCoin = Instantiate(coinPrefab);
            tempCoin.transform.SetParent(transform);
            tempCoin.gameObject.SetActive(false);
        }
        else
        {
            //use an available coin
            tempCoin = coinQueue.Dequeue();
        }

        //activates the coin
        if (tempCoin != null)
        {
            tempCoin.transform.position = randPosition;
            tempCoin.gameObject.SetActive(true);
        }

        coinSpawnDelay = Random.Range(0, 5);

    }

    void spawnGem()
    {
        //random position based on safe area of the screen
        Rect screenSize = Screen.safeArea;
        Vector2 randPosition = new Vector2(Random.Range(-(screenSize.width / 2) + 10.0f, (screenSize.width / 2) - 10.0f), Random.Range(-(screenSize.height / 2) + 10.0f, (screenSize.height / 2) - 10.0f));

        //Temp gem creation, null
        LootScript tempGem = null;

        if (coinQueue.Count < 1)
        {
            //creates a new gem if the queue is empty
            tempGem = Instantiate(gemPrefab);
            tempGem.transform.SetParent(transform);
            tempGem.gameObject.SetActive(false);
        }
        else
        {
            //use an available gem
            tempGem = gemQueue.Dequeue();
        }

        //activates the gem
        if (tempGem != null)
        {
            tempGem.transform.position = randPosition;
            tempGem.gameObject.SetActive(true);
        }

        gemSpawnDelay = Random.Range(0, 10);
    }

    void spawnPotion()
    {
        //random position based on safe area of the screen
        Rect screenSize = Screen.safeArea;
        Vector2 randPosition = new Vector2(Random.Range(-(screenSize.width / 2) + 10.0f, (screenSize.width / 2) - 10.0f), Random.Range(-(screenSize.height / 2) + 10.0f, (screenSize.height / 2) - 10.0f));

        //Temp potion creation, null
        LootScript tempGem = null;

        if (coinQueue.Count < 1)
        {
            //creates a new potion if the queue is empty
            tempGem = Instantiate(potionPrefab);
            tempGem.transform.SetParent(transform);
            tempGem.gameObject.SetActive(false);
        }
        else
        {
            //use an available potion
            tempGem = potionQueue.Dequeue();
        }

        //activates the potion
        if (tempGem != null)
        {
            tempGem.transform.position = randPosition;
            tempGem.gameObject.SetActive(true);
        }

        potionSpawnDelay = Random.Range(0, 5);
    }

    public void returnCoin(LootScript coin)
    {
        coin.gameObject.SetActive(false);
        coinQueue.Enqueue(coin);
    }
    public void returnGem(LootScript gem)
    {
        gem.gameObject.SetActive(false);
        gemQueue.Enqueue(gem);
    }
    public void returnPotion(LootScript potion)
    {
        potion.gameObject.SetActive(false);
        potionQueue.Enqueue(potion);
    }
}
