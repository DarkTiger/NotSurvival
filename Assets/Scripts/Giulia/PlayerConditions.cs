using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerConditions : MonoBehaviour {

    public float health = 100.0f;
    public float coef = 0.7f;
    public Text healthText;
    public Text rocketHealthText;
    PlayerInteractions playerInteractions; 
    ResourcesPlacement resourcesPlacement;
    GameManager gameManager;


    void Start()
    {
        playerInteractions = GetComponent<PlayerInteractions>();
        resourcesPlacement = GameObject.Find("ResourcePlacer").GetComponent<ResourcesPlacement>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }


    void Update()
    {
        if (playerInteractions.playerCamera.enabled && !resourcesPlacement.onInstancing && !gameManager.onVictory)
        {
            // decreases player's health
            if (health > 0)
            {
                health -= coef * Time.deltaTime;
            }
            else
            {
                health = 0;
            }
            // sets text to health percentage
            healthText.text = "ENERGY: " + Mathf.Round(health).ToString() + "%";
        }
        else
        {
            // resets health
            health = 100.0f;
            
            // sets text to health percentage
            rocketHealthText.text = "ENERGY: " + Mathf.Round(health).ToString() + "%";
        }
    }
}
