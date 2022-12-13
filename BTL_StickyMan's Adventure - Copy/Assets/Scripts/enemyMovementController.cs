using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovementController : MonoBehaviour
{
    public float enemySpeed;

    Rigidbody2D enemyRB;
    Animator enemyAnim;

    //khai bao cac bien de Enemy co the lat duoc
    public GameObject enemyGraphic;
    bool facingLeft = true;
    float facingTime = 5f;
    float nextFlip=0f;
    bool canFlip = true;
    // Start is called before the first frame update

    void Awake()
    {
        enemyRB = GetComponent<Rigidbody2D>();
        enemyAnim = GetComponentInChildren<Animator>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextFlip)
        {
            nextFlip = Time.time + facingTime;
            flip();
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            
            if(facingLeft && collision.transform.position.x > transform.position.x)
            {
                flip();
            }
            else if(!facingLeft && collision.transform.position.x < transform.position.x)
            {
                flip();
            }
            canFlip = false;
        }    
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (facingLeft)
            {
                enemyRB.AddForce(new Vector2(-1, 0) * enemySpeed);
            }
            else
            {
                enemyRB.AddForce(new Vector2(1, 0) * enemySpeed);
            }
            enemyAnim.SetBool("isRun", true);
            enemyAnim.SetBool("isAttack", true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            canFlip = true;
            enemyRB.velocity = new Vector2(0, 0);
            enemyAnim.SetBool("isRun", false);
            enemyAnim.SetBool("isAttack", false);
        }
    }
    void flip()
    {
        if (!canFlip)
        {
            return;
        }
        facingLeft = !facingLeft;
        Vector3 theScale = enemyGraphic.transform.localScale;
        theScale.x *= -1;
        enemyGraphic.transform.localScale = theScale;
    }
}
