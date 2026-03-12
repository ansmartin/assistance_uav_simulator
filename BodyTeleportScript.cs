using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyTeleportScript : MonoBehaviour
{
    public Transform head;
    private float y;
    private Vector3 rescale;

    void Start(){
        y = transform.position.y;
    }

    
    void LateUpdate()
    {
        //actualiza la posicion
        transform.position = new Vector3(
            head.position.x,
            y,
            head.position.z);

        //actualiza la rotacion
        transform.rotation = Quaternion.Euler(
            0,
            head.rotation.eulerAngles.y,
            0);
        
        //actualiza el tamaño
        rescale = transform.localScale;
        rescale.y = head.position.y / 1.4f;
        transform.localScale = rescale;

    }
}
