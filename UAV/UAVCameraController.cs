using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UAVCameraController : MonoBehaviour {

    //--------------------------------------------------------------------------------
    // DEFINITION OF GLOBAL VARIABLES
    //--------------------------------------------------------------------------------

    //------------------------------------------------------------
    // GameObject
    [Header("GameObject")]
    //[Space]
    [Tooltip("UAV GameObject")]
    public GameObject UAV;

    //------------------------------------------------------------
    // Offset
    private Vector3 offset;

    //--------------------------------------------------------------------------------
    // AWAKE FUNCTION
    //--------------------------------------------------------------------------------
    // https://docs.unity3d.com/ScriptReference/MonoBehaviour.Awake.html
    // Awake is used to initialize any variables or game state before the game starts.
    // Awake is always called before any Start functions. 
    // (it doesn't depend on wether the script is enable or not)
    void Awake()
    {
        offset = transform.position - UAV.transform.position;
       
    }
    
    //--------------------------------------------------------------------------------
    // LATEUPDATE FUNCTION
    //--------------------------------------------------------------------------------
    // LateUpdate is called after all Update functions have been called
    void LateUpdate ()
    {
        transform.position = UAV.transform.position + offset;
         
    }
    //--------------------------------------------------------------------------------
}
