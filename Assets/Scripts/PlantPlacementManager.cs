using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlantPlacementManager : MonoBehaviour
{
    public GameObject[] flowers;

    public ARSessionOrigin sessionOrigin;
    public ARRaycastManager raycastManager;
    public ARPlaneManager planeManager;

    private List<ARRaycastHit> raycastHits = new List<ARRaycastHit>();

    private void Update()
    {
        if(Input.GetTouch(0).phase == TouchPhase.Began)
        {
            //Shoot Raycast
            raycastManager.Raycast(Input.mousePosition, raycastHits, TrackableType.PlaneWithinPolygon);

            //Place Objects Randomly
            GameObject _object = Instantiate(flowers[Random.Range(0, flowers.Length - 1)]);
            _object.transform.position = raycastHits[0].pose.position;
        }
    }
}
