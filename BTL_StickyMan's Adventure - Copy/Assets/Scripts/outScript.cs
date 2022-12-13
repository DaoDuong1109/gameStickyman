using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class outScript : MonoBehaviour
{
    public GameObject ui;
    public GameObject bloodPlayer;
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
        bloodPlayer.SetActive(false);
        ui.SetActive(true);
    }
    public void playAgain()
    {
        Time.timeScale = 1;
        Scene thisScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene("IslandGame");
        
    }
}
