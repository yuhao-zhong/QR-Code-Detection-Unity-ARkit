using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;


[RequireComponent(typeof(ARRaycastManager))]
public class PlacementController : MonoBehaviour
{
    [SerializeField] private GameObject spherePrefab;
    [SerializeField] private GameObject cubePrefab;
    [SerializeField] private ARRaycastManager raycastManager;
    [SerializeField] private ARPlaneManager arPlaneManager;

    private GameObject placedObject;
    private String returnedText = "sphere";
    public Button yourButton;

    void Awake() {
        arPlaneManager.planesChanged += PlaneChanged;
    }

    void Start()
    {
        arPlaneManager.enabled = false;
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);

    }

    void TaskOnClick(){
        String strHi = SwiftForUnity.HiFromSwift();
        Debug.Log(strHi);
    }

    void Update()
    {

        ReturnPrefab();

        if(Input.touchCount > 0)
        {
            TogglePlaneDetection();
        }
  
    }

    private void ReturnPrefab()
    {
        if (returnedText == "cube")
        {
            placedObject = cubePrefab;
        }

        if (returnedText == "sphere")
        {
            placedObject = spherePrefab;
        }
    }

    private void PlaneChanged(ARPlanesChangedEventArgs args) 
    {
        if(args.added != null && returnedText != null) {
            ARPlane arPlane = args.added[0];
            Instantiate(placedObject, arPlane.transform.position, Quaternion.identity);
            TogglePlaneDetection();
        }
    }

    private void TogglePlaneDetection()
    {
        arPlaneManager.enabled = !arPlaneManager.enabled;

        foreach (ARPlane plane in arPlaneManager.trackables)
        {
            plane.gameObject.SetActive(arPlaneManager.enabled);
        }
    }

}