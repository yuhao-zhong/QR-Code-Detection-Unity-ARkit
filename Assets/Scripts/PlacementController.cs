using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

//[RequireComponent(typeof(ARRaycastManager))]

public class PlacementController : MonoBehaviour
{

    [SerializeField] private GameObject cubePrefab;
    [SerializeField] private GameObject spherePrefab;

    private ARRaycastManager raycastManager;
    private ARPlaneManager arPlaneManager;
    private Camera arCam;

    private List<ARRaycastHit> hits = new List<ARRaycastHit>();

    void Awake()
    {
        raycastManager = GetComponent<ARRaycastManager>();
        arPlaneManager = GetComponent<ARPlaneManager>();

    }


    void Start()
    {
        arCam = GetComponentInChildren<Camera>();
    }

    void Update()
    {

        // If detected QR Code 1
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = arCam.ScreenPointToRay(Input.mousePosition);
            if (raycastManager.Raycast(ray, hits))
            {
                Pose pose = hits[0].pose;
                Instantiate(spherePrefab, pose.position, pose.rotation);
            }
        }

        // If detected QR Code 2
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = arCam.ScreenPointToRay(Input.mousePosition);
            if (raycastManager.Raycast(ray, hits))
            {
                Pose pose = hits[0].pose;
                Instantiate(cubePrefab, pose.position, pose.rotation);
            }
        }


    }

}
