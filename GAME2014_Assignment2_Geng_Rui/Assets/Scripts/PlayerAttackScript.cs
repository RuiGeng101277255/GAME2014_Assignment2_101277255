using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackScript : MonoBehaviour
{
    public int AttackDamage;
    public float AttackIntervalDuration;
    public AttackTypes type;

    float currentTimeInterval = 0.0f;
    bool canDamage = false;
    BulletManager bulletManager = null;
    float playerRotation;

    // Start is called before the first frame update
    void Start()
    {
        //playerRotation = 0.0f;
        //manager = GetComponent<BulletManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTimeInterval > 0.0f)
        {
            currentTimeInterval -= Time.deltaTime;
        }
        else
        {
            if (type == AttackTypes.RIFLE)
            {
                rifleAttack();
            }
            else if (type == AttackTypes.BOMB)
            {
                bombAttack();
            }
            else
            {
                canDamage = true;
                currentTimeInterval = 0.0f;
            }
        }
    }

    void rifleAttack()
    {
        bulletManager = FindObjectOfType<BulletManager>();

        bulletManager.spawnBullet(transform.position, playerRotation);

        //ProjectileScript tempBullet = null; //= bulletManager.getBullet();
        //tempBullet = bulletManager.getBullet();

        //tempBullet.transform.position = transform.position;
        //tempBullet.transform.SetParent(transform);
        //tempBullet.transform.Rotate(new Vector3(0.0f, 0.0f, 1.0f), playerRotation);
        //tempBullet.setDirection(new Vector3(Mathf.Sin(playerRotation), -Mathf.Cos(playerRotation), 0.0f));
        //tempBullet.gameObject.SetActive(true);

        currentTimeInterval = 0.25f;
    }

    void bombAttack()
    {
        bulletManager = FindObjectOfType<BulletManager>();

        bulletManager.spawnBomb(transform.position);

        currentTimeInterval = 0.25f;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (canDamage)
        {
            if (collision.gameObject.GetComponent<CatEnemyScript>() != null)
            {
                collision.gameObject.GetComponent<CatEnemyScript>().CauseDamage(AttackDamage);
                //collision.gameObject.GetComponent<CatEnemyScript>().setTargetPosition(new Vector2(-10.5f, 5.5f));
                currentTimeInterval = AttackIntervalDuration;
                canDamage = false;
            }
            
            if (collision.gameObject.GetComponent<SlimeEnemyScript>() != null)
            {
                collision.gameObject.GetComponent<SlimeEnemyScript>().CauseDamage(AttackDamage);
                //collision.gameObject.GetComponent<SlimeEnemyScript>().setTargetPosition(new Vector2(-10.5f, 5.5f));
                currentTimeInterval = AttackIntervalDuration;
                canDamage = false;
            }
        }
    }

    public void setRotation(float rot)
    {
        playerRotation = rot;
    }
}
