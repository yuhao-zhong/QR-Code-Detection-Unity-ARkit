using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class SwiftForUnity : MonoBehaviour
{

    #region Declare external C interface

    #if UNITY_IOS && !UNITY_EDITOR

    [DllImport("_Internal")]
    private static extern string _sayHiToUnity();

    #endif

    #endregion


    #region Wrapper methods and properties

    public static string HiFromSwift()
    {
    #if UNITY_IOS && !UNITY_EDITOR
        return _sayHiToUnity();

    #else
        return "No Swift found!";
    #endif
    }

    #endregion


    // #region Singleton implementation

    // private static SwiftForUnity _instance;

    // public static SwiftForUnity Instance
    // {
    //     get
    //     {
    //         if (_instance == null)
    //         {
    //             var obj = new GameObject("SwiftUnity");
    //             _instance = obj.AddComponent<SwiftForUnity>();
    //         }

    //         return _instance;
    //     }
    // }

    // private void private void Awake() 
    // {
    //     if (_instance != null)
    //     {
    //         Destroy(gameObject);
    //         return;
    //     }    
    //     DontDestroyOnLoad(gameObject);
    // }

    // #endregion

}
