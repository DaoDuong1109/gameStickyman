using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class playerHealth : MonoBehaviour
{
    public float maxHealth;
    float currentHealth;

    public Slider playerHealthSlider;
    public GameObject bloodEffect;
    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        playerHealthSlider.maxValue = maxHealth;
        playerHealthSlider.value = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void addHealth(float healthAmount)
    {
        currentHealth += healthAmount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        playerHealthSlider.value = currentHealth;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            currentHealth -= 1f;
            playerHealthSlider.value = currentHealth;
            //if (playerHealthSlider.value <= 0)
            //{
              //  Scene thisScene = SceneManager.GetActiveScene();
                //SceneManager.LoadScene(thisScene.name);
            //}
        }
        if (collision.tag == "head_bullet")
        {
            currentHealth -= 5f;
            playerHealthSlider.value = currentHealth;
        }
    }
    
}
