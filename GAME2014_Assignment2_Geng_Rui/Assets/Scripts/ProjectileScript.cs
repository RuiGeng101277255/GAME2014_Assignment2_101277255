using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public string ProjectileType;

    private Vector3 direction;
    private float bulletSpeed = 5.0f;

    private CapsuleCollider2D projCollider;

    // Start is called before the first frame update
    void Start()
    {
        //direction = new Vector3(0.0f, -1.0f, 0.0f);
        //projCollider = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ProjectileType == "bullet")
        {
            updateBullet();
        }
        else if (ProjectileType == "bomb")
        {
            updateBomb();
        }
    }

    void updateBullet()
    {
        transform.position += direction * bulletSpeed * Time.deltaTime;
    }

    void updateBomb()
    {

    }

    public void setDirection(Vector3 dir)
    {
        direction = dir;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //do damage to cat and slimes



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
