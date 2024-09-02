using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ResourcesPlacement : MonoBehaviour 
{
	public List<GameObject> resources;
    public int resourceCount = 10;
    public Canvas loadingCanvas;
    public Text loadingText;
    public Transform rocket;
    [HideInInspector]
    public bool onInstancing = true;
    private int instancedCount = 0;



    void Start()
    {
        loadingCanvas.enabled = true;
    }


    void Update()
    {
        if (instancedCount < resourceCount)
        {
            PlaceResources();
        }
    }


    void PlaceResources()
    {               
        instancedCount++;

        Vector3 newPos = new Vector3(Random.Range(470, 30), Random.Range(0, 35), Random.Range(30, 470));
        while (Vector3.Distance(newPos, rocket.position) < 20)
        {
            newPos = new Vector3(Random.Range(470, 30), Random.Range(0, 30), Random.Range(30, 470));
        }

        GameObject newResource = Instantiate(resources[Random.Range(0, resources.Count)], newPos, new Quaternion(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360)));
                
        if (TestDistanceFromGround(newResource, 1f) != "Ground")
        {
            Destroy(newResource);
        }

        loadingText.text = "CREATING PROCEDURAL RESOURCES: " + Mathf.Round((instancedCount * 100) / resourceCount).ToString() + "%";

        if (instancedCount >= resourceCount)
        {
            loadingCanvas.enabled = false;
            onInstancing = false;
        }
    }


    string TestDistanceFromGround(GameObject newResource, float rayLength)
    {
        string colliderTag = "";

        if (newResource.name == "Crystal(Clone)" || newResource.name == "MARMO(Clone)")
        {
            newResource.transform.rotation = Quaternion.identity;
        }

        RaycastHit hitInfo;
        if (Physics.Raycast(newResource.transform.position, Vector3.up, out hitInfo, rayLength))
        {
            colliderTag = hitInfo.collider.tag;
        }
        else if (Physics.Raycast(newResource.transform.position, Vector3.down, out hitInfo, rayLength))
        {
            colliderTag = hitInfo.collider.tag;
        }
        else if (Physics.Raycast(newResource.transform.position, Vector3.left, out hitInfo, rayLength))
        {
            colliderTag = hitInfo.collider.tag;
        }
        else if (Physics.Raycast(newResource.transform.position, Vector3.right, out hitInfo, rayLength))
        {
            colliderTag = hitInfo.collider.tag;
        }
        else if (Physics.Raycast(newResource.transform.position, Vector3.forward, out hitInfo, rayLength))
        {
            colliderTag = hitInfo.collider.tag;
        }
        else if (Physics.Raycast(newResource.transform.position, Vector3.back, out hitInfo, rayLength))
        {
            colliderTag = hitInfo.collider.tag;
        }

      
        return colliderTag;
    }
}
