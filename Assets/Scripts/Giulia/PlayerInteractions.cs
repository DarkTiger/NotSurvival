using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour 
{
    public float grabRange;
    bool isCameraDetached = false;
    public Camera rocketCamera;
    public Camera playerCamera;
    public GameObject rocketGUI;
    public GameObject playerGUI;

    PlayerMovement playerMovement;
    GameManager gameManager;


    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }


    void Update()
    {
        if (gameManager.onVictory && !isCameraDetached)
        {
            SetPlayerCamera(true);

            GameObject camera = transform.GetChild(1).gameObject;
            camera.transform.parent = null;

            isCameraDetached = true;
        }
        else
        {
            Vector3 rayDestinationUp = transform.forward;
            rayDestinationUp.y += 0.5f;

            Vector3 rayDestinationDown = transform.forward;
            rayDestinationDown.y -= 0.5f;

            Ray rayUp = new Ray(transform.position, rayDestinationUp);
            Ray rayDown = new Ray(transform.position, rayDestinationDown);
            

            RaycastHit hit;
            if (Physics.Raycast(rayUp, out hit, grabRange) ||
                Physics.Raycast(rayDown, out hit, grabRange) ||
                Physics.Raycast(transform.position, transform.forward, out hit, grabRange))
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (hit.collider.tag == "Rocket")
                    {
                        if (rocketCamera.enabled)
                        {
                            SetPlayerCamera(true);
                        }
                        else
                        {
                            SetPlayerCamera(false);
                        }
                    }
                    else if (hit.collider.tag == "Resource")
                    {
                        GameObject resource = hit.collider.gameObject;

                        PlayerCameraAndGUI inventory = GetComponent<PlayerCameraAndGUI>();
                        ResourcesQuantity resCount = new ResourcesQuantity();
                        resCount = resource.GetComponent<ResourcesQuantity>();

                        inventory.playerSteelCount += resCount.steelCount;
                        inventory.playerCircuitsCount += resCount.circuitsCount;
                        inventory.playerUraniumCount += resCount.uraniumCount;
                        inventory.playerPlasticCount += resCount.plasticCount;
                        inventory.playerGlassCount += resCount.glassCount;
                        inventory.playerFuelCount += resCount.fuelCount;

                        Destroy(resource);
                    }
                }
            }
        }
    }

    void SetPlayerCamera(bool isSet)
    {
        playerCamera.enabled = isSet;
        rocketCamera.enabled = !isSet;
        rocketGUI.SetActive(!isSet);
        playerGUI.SetActive(isSet);
        playerMovement.enabled = isSet;
    }
}
