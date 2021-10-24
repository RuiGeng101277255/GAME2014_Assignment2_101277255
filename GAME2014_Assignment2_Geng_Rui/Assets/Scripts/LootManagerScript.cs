/*
 Full Name: Rui Chen Geng Li (101277255)
 File Name: LootManagerScript.cs
 Last Modified: October 24th, 2021
 Description: This is the manager for random loot spawns
 Version History: v1.05 Cleaned Up Codes and Comments
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootManagerScript : MonoBehaviour
{
    //Variables for the display texts and the loot prefabs
    public UIScoresNItemsScript UIInformation;
    public LootScript coinPrefab;
    public LootScript gemPrefab;
    public LootScript potionPrefab;

    //loot queues
    Queue<LootScript> coinQueue;
    Queue<LootScript> gemQueue;
    Queue<LootScript> potionQueue;

    //random delay set to spawn each of the different loots
    float coinSpawnDelay;
    float gemSpawnDelay;
    float potionSpawnDelay;

    // Start is called before the first frame update
    void Start()
    {
        //Creates an empty queue for each of the loot queues
        coinQueue = new Queue<LootScript>();
        gemQueue = new Queue<LootScript>();
        potionQueue = new Queue<LootScript>();

        //initial spawn delay set to 0 so that the player has something to pick up in the beginning
        coinSpawnDelay = 0.0f;
        gemSpawnDelay = 0.0f;
        potionSpawnDelay = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        //Checks if the delays are <= 0, if so then spawn a corresponding loot object

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
        Vector2 randPosition = new Vector2(Random.Range(20.0f, screenSize.width - 20.0f), Random.Range(20.0f, screenSize.height - 20.0f));
        
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

        //delay with random range between 5 and 10
        coinSpawnDelay = Random.Range(5, 10);

    }

    void spawnGem()
    {
        //random position based on safe area of the screen
        Rect screenSize = Screen.safeArea;
        Vector2 randPosition = new Vector2(Random.Range(20.0f, screenSize.width - 20.0f), Random.Range(20.0f, screenSize.height - 20.0f));

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

        //delay with random range between 7 and 10
        gemSpawnDelay = Random.Range(7, 10);
    }

    void spawnPotion()
    {
        //random position based on safe area of the screen
        Rect screenSize = Screen.safeArea;
        Vector2 randPosition = new Vector2(Random.Range(20.0f, screenSize.width - 20.0f), Random.Range(20.0f, screenSize.height - 20.0f));

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

        //delay with random range between 10 and 20
        potionSpawnDelay = Random.Range(10, 20);
    }

    public void returnCoin(LootScript coin)
    {
        //Returns the coin to the coin queue
        coin.gameObject.SetActive(false);
        coinQueue.Enqueue(coin);
    }
    public void returnGem(LootScript gem)
    {
        //Returns the gem to the gem queue
        gem.gameObject.SetActive(false);
        gemQueue.Enqueue(gem);
    }
    public void returnPotion(LootScript potion)
    {
        //Returns the potion to the potion queue
        potion.gameObject.SetActive(false);
        potionQueue.Enqueue(potion);
    }
}
