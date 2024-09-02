using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public float maxTime;
    public GameObject getConditions;
    PlayerConditions playerConditions;
    GameObject player;
    bool isGameOverCalled = false;
    public bool onVictory;
    public Text timeText;
    ResourcesPlacement resourcesPlacement;
    ObjectivesManager objManager;
    ParticleSystem explosion;
    ParticleSystem fire;
    public Image imageGameOver;
    public Canvas playerCanvas;
    public Canvas timeCanvas;   


    void Start()
    {
        playerConditions = getConditions.GetComponent<PlayerConditions>();
        player = GameObject.Find("Player");
        
        resourcesPlacement = GameObject.Find("ResourcePlacer").GetComponent<ResourcesPlacement>();
        objManager = GameObject.Find("Rocket").GetComponent<ObjectivesManager>();
        explosion = GameObject.Find("Explosion").GetComponent<ParticleSystem>();
        fire = GameObject.Find("Fire").GetComponent<ParticleSystem>();
    }


    void Update()
    {
        float healthTemp = playerConditions.health;

        // Player death conditions
        if ((healthTemp <= 0.0f || maxTime <= 0.0f) && !isGameOverCalled)
        {
            StartCoroutine(WaitSomeSeconds(8));
            GameOver();
        }

        if (imageGameOver.enabled)
        {
            if (Input.GetKeyUp(KeyCode.R))
            {
                SceneManager.LoadScene(0,LoadSceneMode.Single);
            }
        }

        if (!resourcesPlacement.onInstancing && playerConditions.health > 0 && !onVictory)
        {
            if (maxTime > 0)
            {
                maxTime -= Time.deltaTime;
            }
            else
            {
                maxTime = 0;
                playerConditions.health = 0;
            }
        }
        //


        // Victory conditions
        if (objManager.isNavigationBuilt &&
            objManager.isWindowsBuilt &&
            objManager.isEngineBuilt &&
            objManager.isFuelBuilt &&
            objManager.isHullBuilt &&
            objManager.isWingsBuilt)
        {
            Victory();
        }
        //


        // Updates time text
        int seconds = (Mathf.FloorToInt(maxTime) % 60);

        if (seconds < 10)
        {
            timeText.text = (Mathf.FloorToInt(maxTime) / 60).ToString() + ":0" + seconds.ToString();
        }
        else
        {
            timeText.text = (Mathf.FloorToInt(maxTime) / 60).ToString() + ":" + seconds.ToString();
        }
    }


    void GameOver()
    {
        isGameOverCalled = true;

        GameObject animation = player.transform.GetChild(0).gameObject;
        animation.GetComponent<Animator>().enabled = false;

        GameObject camera = player.transform.GetChild(1).gameObject;
        camera.transform.parent = null;

        Rigidbody rbPlayer = player.GetComponent<Rigidbody>();
        rbPlayer.constraints = RigidbodyConstraints.None;
    }


    void Victory()
    {
        if (!onVictory)
        {
            explosion.Play();
            fire.Play();

            GameObject animation = player.transform.GetChild(0).gameObject;
            animation.GetComponent<Animator>().enabled = false;

            Rigidbody rbPlayer = player.GetComponent<Rigidbody>();
            rbPlayer.constraints = RigidbodyConstraints.None;

            player.transform.Rotate(Random.Range(-5, 5), 0, Random.Range(-5, 5));
            StartCoroutine(WaitSomeSeconds(8));
            playerCanvas.enabled = false;
            timeCanvas.enabled = false;
        }

        onVictory = true;
    }


    IEnumerator WaitSomeSeconds(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        timeCanvas.enabled = false;
        imageGameOver.enabled = true;
    }
}
