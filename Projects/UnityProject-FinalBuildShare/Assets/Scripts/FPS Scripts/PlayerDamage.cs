using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class PlayerDamage : MonoBehaviour
{
   

    public float Health = 100;
    public Slider healthBarSlider;
    public Text gameOverText;
    private bool isGameOver = false;


    GameObject zombie;
    CreatureController creatureScript;

    // Use this for initialization
    void Start()
    {
        gameOverText.enabled = false;
        zombie = GameObject.Find("Zombies");
    }

    // Update is called once per frame
    void Update()
    {
       
        if (healthBarSlider.value <= 0)
        {
            gameOverText.enabled = true;
            Destroy(zombie);
        }
    }

    void OnTriggerStay(Collider other)
    {

        if (healthBarSlider.value > 0)
        {
            healthBarSlider.value -= 0.05f;
        }
        else
        {
            isGameOver = true;
            gameOverText.enabled = true;
        }
    }
  
}


  