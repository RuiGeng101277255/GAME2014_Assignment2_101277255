/*
 Full Name: Rui Chen Geng Li (101277255)
 File Name: ProjectileScript.cs
 Last Modified: October 24th, 2021
 Description: This is the projectile script that manages bullet and bomb behaviours
 Version History: v1.06 Cleaned Up Codes and Comments
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    //defines the type of the projectile
    public string ProjectileType;

    //defines the projectile status and condition
    private Vector3 direction;
    private float bulletSpeed = 5.0f;
    private CapsuleCollider2D projCollider;
    private int ProjDamage = 0;

    // Update is called once per frame
    void Update()
    {
        //update the projectile based on it's type

        if (ProjectileType == "bullet")
        {
            updateBullet();
        }
    }

    void updateBullet()
    {
        //bullet is the only projectile type that moves and require updated positions
        transform.position += direction * bulletSpeed * Time.deltaTime;
    }

    public void setDirection(Vector3 dir)
    {
        //direction of the bullet travel
        direction = dir;
    }

    public void setProjectileDamage(int damage)
    {
        //amount of damages each bullet or bomb can do
        ProjDamage = damage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //do damage to cat and slimes

        if (collision.gameObject.GetComponent<CatEnemyScript>() != null)
        {
            collision.gameObject.GetComponent<CatEnemyScript>().CauseDamage(ProjDamage);
        }
        else if (collision.gameObject.GetComponent<SlimeEnemyScript>() != null)
        {
            collision.gameObject.GetComponent<SlimeEnemyScript>().CauseDamage(ProjDamage);
        }

        //returns the projectile object to their corresponding queue in bulletmanager
        var manager = FindObjectOfType<BulletManager>();

        if (ProjectileType == "bullet")
        {
            manager.returnBullet(this);
        }
        else if (ProjectileType == "bomb")
        {
            manager.returnBomb(this);
        }
    }
}
