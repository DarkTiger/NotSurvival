using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesQuantity : MonoBehaviour 
{
    [HideInInspector]public int steelCount = 0;
    [HideInInspector]public int circuitsCount = 0;
    [HideInInspector]public int uraniumCount = 0;
    [HideInInspector]public int plasticCount = 0;
    [HideInInspector]public int glassCount = 0;
    [HideInInspector]public int fuelCount = 0;
    public ResourceType type;



    public enum ResourceType
    {
        SpaceShip,
        Crystal,
        Antenna,
        Plant,
        Vent,
        Wheel,
        SteelStuff
    }


    void Start()
    {
        if (type == ResourceType.SpaceShip)
        {
            steelCount = Mathf.RoundToInt(Random.Range(10, 50));
            circuitsCount = Mathf.RoundToInt(Random.Range(0, 10));
            uraniumCount = Mathf.RoundToInt(Random.Range(0, 10));
            plasticCount = Mathf.RoundToInt(Random.Range(5, 25));
            glassCount = Mathf.RoundToInt(Random.Range(5, 20));
            fuelCount = Mathf.RoundToInt(Random.Range(0, 10));
        }
        else if (type == ResourceType.Crystal)
        {
            uraniumCount = Mathf.RoundToInt(Random.Range(10, 50));
            glassCount = Mathf.RoundToInt(Random.Range(5, 15));
        }
        else if (type == ResourceType.Antenna)
        {
            steelCount = Mathf.RoundToInt(Random.Range(10, 25));
            circuitsCount = Mathf.RoundToInt(Random.Range(10, 50));
            uraniumCount = Mathf.RoundToInt(Random.Range(0, 10));
            plasticCount = Mathf.RoundToInt(Random.Range(0, 20));
        }
        else if (type == ResourceType.Plant)
        {
            fuelCount = Mathf.RoundToInt(Random.Range(20, 50));
        }
        else if (type == ResourceType.Vent)
        {
            steelCount = Mathf.RoundToInt(Random.Range(0, 20));
            circuitsCount = Mathf.RoundToInt(Random.Range(0, 15));
            uraniumCount = Mathf.RoundToInt(Random.Range(0, 5));
            plasticCount = Mathf.RoundToInt(Random.Range(0, 10));
        }
        else if (type == ResourceType.Wheel)
        {
            steelCount = Mathf.RoundToInt(Random.Range(0, 20));
            plasticCount = Mathf.RoundToInt(Random.Range(10, 30));
        }
        else if (type == ResourceType.SteelStuff)
        {
            steelCount = Mathf.RoundToInt(Random.Range(5, 15));
        }
    }
}
