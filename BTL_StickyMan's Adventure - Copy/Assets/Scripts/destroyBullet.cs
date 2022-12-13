using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyBullet : MonoBehaviour
{
    public float timeBeforeDestroy;
    public float damage;
    // Start is called before the first frame update
    void Start()
    {
        damage = 1;
        timeBeforeDestroy = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(this.gameObject, timeBeforeDestroy);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            collision.collider.GetComponent<enemy>().takeDamage(damage);
            Destroy(this.gameObject, timeBeforeDestroy);
        }
        else if (collision.collider.CompareTag("HeadEnemy"))
        {
            collision.collider.GetComponent<head_enemy>().takeDamage(damage);
            Destroy(this.gameObject, timeBeforeDestroy);
        }
        else {
            Destroy(this.gameObject, timeBeforeDestroy);
        }

    }
}
