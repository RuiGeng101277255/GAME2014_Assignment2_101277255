/*
 Full Name: Rui Chen Geng Li (101277255)
 File Name: BulletManager.cs
 Last Modified: October 24th, 2021
 Description: This manages the projectile objects (bullets and bombs) and their placements with queues
 Version History: v1.06 Cleaned Up Codes and Comments
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    //Variables for the prefabs that will be created
    public ProjectileScript bulletPrefab;
    public ProjectileScript bombPrefab;

    //queues for different types of projectiles
    private Queue<ProjectileScript> bulletQueue;
    private Queue<ProjectileScript> bombQueue;

    // Start is called before the first frame update
    void Start()
    {
        //Initialize with empty queues
        bulletQueue = new Queue<ProjectileScript>();
        bombQueue = new Queue<ProjectileScript>();
    }

    public void spawnBullet(Vector3 position, float zRotation, int damage)
    {
        //spawns a bullet
        ProjectileScript tempBullet = null;

        if (bulletQueue.Count < 1)
        {
            //if the queue is empty, then create a new bullet
            tempBullet = Instantiate(bulletPrefab);
            tempBullet.transform.SetParent(transform);
            tempBullet.gameObject.SetActive(false);
        }
        else
        {
            //if the queue is not empty, then dequeue
            tempBullet = bulletQueue.Dequeue();
        }

        //Manual set up for the bomb's position, due to possible direction error similar to the player layout grid's. Fixed by defining the z-axis rotation
        if (tempBullet != null)
        {
            Debug.Log(tempBullet);
            tempBullet.transform.position = position;
            tempBullet.transform.Rotate(new Vector3(0.0f, 0.0f, 1.0f), zRotation);

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

            //set's the projectile damage and active
            tempBullet.setProjectileDamage(damage);
            tempBullet.gameObject.SetActive(true);
        }
    }

    public void spawnBomb(Vector3 position, float zRotation, int damage)
    {
        //spawns a new bomb
        ProjectileScript tempBomb = null;

        if (bulletQueue.Count < 1)
        {
            //if the queue is empty, then create a new bomb
            tempBomb = Instantiate(bombPrefab);
            tempBomb.transform.SetParent(transform);
            tempBomb.gameObject.SetActive(false);
        }
        else
        {
            //if the queue is not empty, then dequeue
            tempBomb = bombQueue.Dequeue();
        }

        //Manual set up for the bomb's position, due to possible direction error similar to the player layout grid's. Fixed by defining the z-axis rotation
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

            //set's the projectile damage and active
            tempBomb.setProjectileDamage(damage);
            tempBomb.gameObject.SetActive(true);
        }
    }

    public void returnBullet(ProjectileScript bullet)
    {
        //returns the bullet to the bullet queue
        bullet.gameObject.SetActive(false);
        bulletQueue.Enqueue(bullet);
    }

    public void returnBomb(ProjectileScript bomb)
    {
        //returns the bomb to the bomb queue
        bomb.gameObject.SetActive(false);
        bombQueue.Enqueue(bomb);
    }
}
