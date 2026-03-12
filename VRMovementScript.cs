using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class VRMovementScript : MonoBehaviour
{

    private Vector2 touchpad;
    private bool touched;

    private int walk = Animator.StringToHash(nameof(walk));

    private bool adelante;
    private bool atras;

    public GameObject Head;
    //public VRLampScript vrlamp;

    private float speed = 0.5f;

    private Animator anim;

    public GameObject body_abuelo, body_abuela;


    void Start(){
        //vrlamp = GetComponent<VRLampScript>();

        if(OpcionesScript._pj == 0)
            anim = body_abuelo.GetComponent<Animator>();
        else
            anim = body_abuela.GetComponent<Animator>();
    }

    void Update()
    {
         
        /* touchpad = SteamVR_Actions.platformer_Move.axis;

        //moveDirection = Quaternion.AngleAxis(Angle(touchpad) + transform.localRotation.eulerAngles.y, Vector3.up) * Vector3.forward; //get the angle of the touch and correct it for the rotation of the controller
        //updateInput();

        if (touchpad.magnitude > 0){
            transform.position += Head.transform.forward * Time.deltaTime * speed;
        }
        

        Debug.Log(touchpad); */





        /* touched = SteamVR_Actions._default.GrabPinch.state;
        
        if(touched){
            transform.position += Head.transform.forward * Time.deltaTime * speed;
        } 
        
        Debug.Log(touched);
        */


        // Movimientos con los gatillos de los mandos

        adelante = SteamVR_Actions._default.GrabPinch.GetState(SteamVR_Input_Sources.RightHand);
        atras = SteamVR_Actions._default.GrabPinch.GetState(SteamVR_Input_Sources.LeftHand);

        if(adelante){
            transform.position += new Vector3(Head.transform.forward.x,0,Head.transform.forward.z) * Time.deltaTime * speed;
            anim.SetBool(walk,true);
        }
        else if(atras){
            transform.position += new Vector3(Head.transform.forward.x,0,Head.transform.forward.z) * Time.deltaTime * speed * -1;
            anim.SetBool(walk,true);
        }
        else anim.SetBool(walk,false);

        

        // Encender lámparas con el grip de los mandos

         /* touched = SteamVR_Actions._default.GrabGrip.stateDown;

        if(touched){
            vrlamp.Presionar();
        } */
    }


}
