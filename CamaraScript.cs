using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraScript : MonoBehaviour
{
    [Header("Cabeza del player")]
	//variable para guardar la referencia a la cabeza del player
    public Transform head;
       
    
    void LateUpdate () 
    {
        transform.position = head.transform.position;
    }
}