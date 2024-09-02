using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourcesManager : MonoBehaviour 
{
    public int steelCount = 0;
    public int circuitsCount = 0;
    public int uraniumCount = 0;
    public int plasticCount = 0;
    public int glassCount = 0;
    public int fuelCount = 0;

    public Text steelCountText;
    public Text circuitsCountText;
    public Text uraniumCountText;
    public Text plasticCountText;
    public Text glassCountText;
    public Text fuelCountText;

    public Button rocketButton;

    public GameObject getPlayerResources;
    PlayerCameraAndGUI playerCameraAndGUI;

    private void Start()
    {
        playerCameraAndGUI = getPlayerResources.GetComponent<PlayerCameraAndGUI>();
    }

    void Update()
    {
        steelCountText.text = steelCount.ToString();
        circuitsCountText.text = circuitsCount.ToString();
        uraniumCountText.text = uraniumCount.ToString();
        plasticCountText.text = plasticCount.ToString();
        glassCountText.text = glassCount.ToString();
        fuelCountText.text = fuelCount.ToString();
    }

    public void OnRocketButtonClick()
    {
        steelCount += playerCameraAndGUI.playerSteelCount;
        circuitsCount += playerCameraAndGUI.playerCircuitsCount;
        uraniumCount += playerCameraAndGUI.playerUraniumCount;
        plasticCount += playerCameraAndGUI.playerPlasticCount;
        glassCount += playerCameraAndGUI.playerGlassCount;
        fuelCount += playerCameraAndGUI.playerFuelCount;

        playerCameraAndGUI.playerSteelCount = 0;
        playerCameraAndGUI.playerCircuitsCount = 0;
        playerCameraAndGUI.playerUraniumCount = 0;
        playerCameraAndGUI.playerPlasticCount = 0;
        playerCameraAndGUI.playerGlassCount = 0;
        playerCameraAndGUI.playerFuelCount = 0;
    }
    
}
