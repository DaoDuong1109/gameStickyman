using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class head_enemy : MonoBehaviour
{
    public float maxHealth;
    float currentHealth;


    //khai bao bien tao blood bar
    public Slider enemyHealthSlider;


    //khai bao cac bien khi enemy chet se roi ra binh mau
    public bool drop;
    public GameObject theDrop;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        enemyHealthSlider.maxValue = maxHealth;
        enemyHealthSlider.value = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void takeDamage(float damage)
    {
        currentHealth -= damage;
        enemyHealthSlider.value = currentHealth;
        if (currentHealth <= 0)
        {
            makeDead();
        }
    }
    void makeDead()
    {
        //chuc nang roi ra binh mau
        if (drop)
        {
            Instantiate(theDrop, transform.position, transform.rotation);
        }

        Destroy(gameObject);


    }
}
