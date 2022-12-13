using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bloodPickup : MonoBehaviour
{
    public float healthAmount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerHealth thePlayerHealth = collision.gameObject.GetComponent<playerHealth>();
            thePlayerHealth.addHealth(healthAmount);
            Destroy(gameObject);
        }
    }
}
