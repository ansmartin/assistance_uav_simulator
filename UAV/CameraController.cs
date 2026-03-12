using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    //--------------------------------------------------------------------------------
    // DEFINITION OF GLOBAL VARIABLES
    //--------------------------------------------------------------------------------

    // CAMERAS ------------------------------------------------
    [Header("CAMERAS")]
    [Space]
    [Tooltip("Full-Screen Cameras")]
    public Camera[] cameras = new Camera[4];

    // Bottom Cameras
    private const int SIZE = 2;
    [Tooltip("Bottom Corner Cameras")]
    public Camera[] bottomCameras = new Camera[SIZE];

    //-----------------------------------------------------------
    // KEYS
    [Header("KEYS")]
    [Space]
    [Tooltip("Key used to change the active camera")]
    public KeyCode cameraTKey = KeyCode.C;
    [Tooltip("Key used to switch to multiple view mode")]
    public KeyCode viewTKey = KeyCode.V;

    //------------------------------------------------------------
    // INDEXES
    private int currentCameraIndex;
    private int bottomCameraIndex;

    //--------------------------------------------------------------------------------
    //--------------------------------------------------------------------------------

    //--------------------------------------------------------------------------------
    // START FUNCTION
    //--------------------------------------------------------------------------------
    // Use this for initialization
    void Start()
    {

        currentCameraIndex = 0;

        // Turn main camera on
        cameras[currentCameraIndex].gameObject.SetActive(true);

        //Turn all cameras off, except the first default one
        for (int i = 1; i < cameras.Length; i++) //cameras.Length
        {
            cameras[i].gameObject.SetActive(false);
        }

        //Turn all bottom corner cameras off
        for (int i = 0; i < bottomCameras.Length; i++) //cameras.Length
        {
            bottomCameras[i].gameObject.SetActive(false);
        }
    }
    //--------------------------------------------------------------------------------

    //--------------------------------------------------------------------------------
    // UPDATE FUNCTION
    //--------------------------------------------------------------------------------
    // Update is called once per frame
    void Update()
    {
        //If the button "cameraTKey" is pressed, switch to the next camera
        //Set the camera at the current index to inactive, and set the next one in the array to active
        //When we reach the end of the camera array, move back to the beginning or the array.
        if (Input.GetKeyDown(cameraTKey))
        {
            currentCameraIndex++;         
            if (currentCameraIndex < cameras.Length)
            {
                cameras[currentCameraIndex - 1].gameObject.SetActive(false);
                cameras[currentCameraIndex].gameObject.SetActive(true);
            }
            else
            {
                cameras[currentCameraIndex - 1].gameObject.SetActive(false);
                currentCameraIndex = 0;
                cameras[currentCameraIndex].gameObject.SetActive(true);
            }
        }

        if (Input.GetKeyDown(viewTKey))
        {
            // If the button "viewTKey" is pressed, switch to the next camera option
            // 0 -> Bottom Camera Disable
            // 1 -> Bottom Camera 1 Activated
            // 2 -> Bottom Camera 2 Activated
            bottomCameraIndex++;
            switch (bottomCameraIndex)
            {
                case 1:
                    bottomCameras[0].gameObject.SetActive(true);
                    bottomCameras[1].gameObject.SetActive(false);
                    break;
                case 2:
                    bottomCameras[0].gameObject.SetActive(false);
                    bottomCameras[1].gameObject.SetActive(true);
                    break;
                case 3:
                    bottomCameraIndex = 0;
                    bottomCameras[0].gameObject.SetActive(false);
                    bottomCameras[1].gameObject.SetActive(false);
                    break;
            };

        }
    }
    //--------------------------------------------------------------------------------

}
