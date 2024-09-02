using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectivesManager : MonoBehaviour 
{

    ResourcesManager resourcesManager;

    public Button wingsButton;
    public Button windowsButton;
    public Button engineButton;
    public Button navigationButton;
    public Button hullButton;
    public Button fuelButton;

    public bool isNavigationBuilt = false;
    public bool isWindowsBuilt = false;
    public bool isEngineBuilt = false;
    public bool isWingsBuilt = false;
    public bool isHullBuilt = false;
    public bool isFuelBuilt = false;

    void Start()
    {
        resourcesManager = GetComponent<ResourcesManager>();
    }

    void Update()
    {
        int circuits = resourcesManager.circuitsCount;
        int plastic = resourcesManager.plasticCount;
        int glass = resourcesManager.glassCount;
        int uranium = resourcesManager.uraniumCount;
        int fuel = resourcesManager.fuelCount;
        int steel = resourcesManager.steelCount;
        
        // Navigation System

        if (!isNavigationBuilt && circuits >= 80 && plastic >= 30 && glass >= 10)
        {
            navigationButton.interactable = true;
        }
        else
        {
            navigationButton.interactable = false;
        }

        // Windows

        if (!isWindowsBuilt && glass >= 50 && plastic >= 30 && steel >= 10)
        {
            windowsButton.interactable = true;
        }
        else
        {
            windowsButton.interactable = false;
        }

        // Engine

        if (!isEngineBuilt && uranium >= 80 && circuits >= 50 && steel >= 20)
        {
            engineButton.interactable = true;
        }
        else
        {
            engineButton.interactable = false;
        }

        // Wings

        if (!isWingsBuilt && steel >= 50 && plastic >= 25)
        {
            wingsButton.interactable = true;
        }
        else
        {
            wingsButton.interactable = false;
        }

        // Hull

        if (!isHullBuilt && steel >= 100 && plastic >= 20)
        {
            hullButton.interactable = true;
        }
        else
        {
            hullButton.interactable = false;
        }

        // Fuel

        if (!isFuelBuilt && fuel >= 100)
        {
            fuelButton.interactable = true;
        }
        else
        {
            fuelButton.interactable = false;
        }




    }

    public void OnFuelButtonClick()
    {
       resourcesManager.fuelCount -= 100;
       isFuelBuilt = true;
       SetColorGreen(fuelButton);
    }

    public void OnNavigationButtonClick()
    {
        resourcesManager.circuitsCount -= 80;
        resourcesManager.plasticCount -= 30;
        resourcesManager.glassCount -= 10;
        isNavigationBuilt = true;
        SetColorGreen(navigationButton);        
    }

    public void OnWindowsButtonClick()
    {
        resourcesManager.glassCount -= 50;
        resourcesManager.plasticCount -= 30;
        resourcesManager.steelCount -= 10;
        isWindowsBuilt = true;
        SetColorGreen(windowsButton);        
    }

    public void OnEngineButtonClick()
    {
        resourcesManager.uraniumCount -= 80;
        resourcesManager.circuitsCount -= 50;
        resourcesManager.steelCount -= 20;
        isEngineBuilt = true;
        SetColorGreen(engineButton);        
    }

    public void OnWingsButtonClick()
    {
        resourcesManager.steelCount -= 50;
        resourcesManager.plasticCount -= 25;
        isWingsBuilt = true;
        SetColorGreen(wingsButton);
    }

    public void OnHullButtonClick()
    {
        resourcesManager.steelCount -= 100;
        resourcesManager.plasticCount -= 20;
        isHullBuilt = true;
        SetColorGreen(hullButton);        
    }

    void SetColorGreen(Button button)
    {
       ColorBlock green = button.colors;

       green.disabledColor = Color.green;
       button.colors = green;
    }
}