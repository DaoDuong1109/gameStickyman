using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class gameController : MonoBehaviour
{
    public GameObject playerBlood;
    public Slider bloodSlider;
    public GameObject player;
    public Slider enemy1;
    public GameObject enemy2;
    public GameObject menu;
    public GameObject door;
    // Start is called before the first frame update
    void Start()
    {
   
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy1.value<=0)
        {
            door.SetActive(true);
        }
        if (bloodSlider.value<=0)
        {
            playerBlood.SetActive(false);
            menu.SetActive(true);
        }
    }
}
