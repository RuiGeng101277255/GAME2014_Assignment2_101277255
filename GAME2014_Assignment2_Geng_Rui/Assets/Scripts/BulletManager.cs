using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public ProjectileScript bulletPrefab;
    public ProjectileScript bombPrefab;

    private Queue<ProjectileScript> bulletQueue;
    private Queue<ProjectileScript> bombQueue;

    // Start is called before the first frame update
    void Start()
    {
        bulletQueue = new Queue<ProjectileScript>();
        bombQueue = new Queue<ProjectileScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawnBullet(Vector3 position, float zRotation)
    {
        ProjectileScript tempBullet = null;

        if (bulletQueue.Count < 1)
        {
            tempBullet = Instantiate(bulletPrefab);
            tempBullet.transform.SetParent(transform);
            tempBullet.gameObject.SetActive(false);
        }
        else
        {
            tempBullet = bulletQueue.Dequeue();
        }

        if (tempBullet != null)
        {
            Debug.Log(tempBullet);
            tempBullet.transform.position = position;
            tempBullet.transform.Rotate(new Vector3(0.0f, 0.0f, 1.0f), zRotation);
            //tempBullet.setDirection(new Vector3(0.0f, -1.0f, 0.0f));
            if (zRotation == 0.0f)
            {
                tempBullet.setDirection(new Vector3(0.0f, -1.0f, 0.0f));
            }
            else if(zRotation == -45.0f)
            {
                tempBullet.setDirection(new Vector3(-0.5f, -0.5f, 0.0f));

            }
            else if (zRotation == 45.0f)
            {
                tempBullet.setDirection(new Vector3(0.5f, -0.5f, 0.0f));
            }
            else if (zRotation == -90.0f)
            {
                tempBullet.setDirection(new Vector3(-1.0f, 0.0f, 0.0f));
            }
            else if (zRotation == 90.0f)
            {
                tempBullet.setDirection(new Vector3(1.0f, 0.0f, 0.0f));
            }
            else if (zRotation == -135.0f)
            {
                tempBullet.setDirection(new Vector3(-0.5f, 0.5f, 0.0f));
            }

            //tempBullet.setDirection(new Vector3(Mathf.Sin(zRotation / (2.0f * Mathf.PI)), -Mathf.Cos(zRotation / (2.0f * Mathf.PI)), 0.0f));
            tempBullet.gameObject.SetActive(true);
        }
    }

    public void spawnBomb(Vector3 position, float zRotation)
    {
        ProjectileScript tempBomb = null;

        if (bulletQueue.Count < 1)
        {
            tempBomb = Instantiate(bombPrefab);
            tempBomb.transform.SetParent(transform);
            tempBomb.gameObject.SetActive(false);
        }
        else
        {
            tempBomb = bombQueue.Dequeue();
        }

        if (tempBomb != null)
        {
            Debug.Log(tempBomb);

            if (zRotation == 0.0f)
            {
                tempBomb.transform.position = position - new Vector3(0.0f, 1.0f, 0.0f);
            }
            else if (zRotation == -45.0f)
            {
                tempBomb.transform.position = position - new Vector3(0.5f, 0.5f, 0.0f);
            }
            else if (zRotation == 45.0f)
            {
                tempBomb.transform.position = position - new Vector3(-0.5f, 1.0f, 0.0f);
            }
            else if (zRotation == -90.0f)
            {
                tempBomb.transform.position = position - new Vector3(0.5f, 0.25f, 0.0f);
            }
            else if (zRotation == 90.0f)
            {
                tempBomb.transform.position = position - new Vector3(-0.5f, 0.25f, 0.0f);
            }
            else if (zRotation == -135.0f)
            {
                tempBomb.transform.position = position - new Vector3(0.5f, -0.0f, 0.0f);
            }
            else if (zRotation == 180.0f)
            {
                tempBomb.transform.position = position - new Vector3(0.0f, -0.15f, 0.0f);
            }

            //tempBullet.setDirection(new Vector3(Mathf.Sin(zRotation / (2.0f * Mathf.PI)), -Mathf.Cos(zRotation / (2.0f * Mathf.PI)), 0.0f));
            tempBomb.gameObject.SetActive(true);
        }
    }

    public void returnBullet(ProjectileScript bullet)
    {
        bullet.gameObject.SetActive(false);
        bulletQueue.Enqueue(bullet);
    }

    public void returnBomb(ProjectileScript bomb)
    {
        bomb.gameObject.SetActive(false);
        bombQueue.Enqueue(bomb);
    }
}
