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
            tempBullet.setDirection(new Vector3(Mathf.Sin(zRotation), -Mathf.Cos(zRotation), 0.0f));
            tempBullet.gameObject.SetActive(true);
        }
    }

    public ProjectileScript getBullet()
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

        return tempBullet;
    }

    public void spawnBomb(Vector3 position)
    {

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