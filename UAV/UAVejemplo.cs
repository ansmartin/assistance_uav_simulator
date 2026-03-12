using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UAVejemplo : MonoBehaviour
{
    public Transform head_pj;
    public Transform head_rv;
    private Transform head;

    public float speed = 1;
    private float step;
    bool ready=false;

    private Rigidbody rb;

    CamaraFotosScript camaraFotos;


    void Start(){
        
        rb = GetComponent<Rigidbody>();
        camaraFotos = GetComponent<CamaraFotosScript>();

        if(OpcionesScript._control == 1){
            head = head_rv;
        }
        else head = head_pj;

    }

    
    void LateUpdate()
    {
        try{
            // elevarse
            if(!ready){
                transform.position = new Vector3(transform.position.x, transform.position.y+0.01f, transform.position.z);
                if(transform.position.y>1.25f) ready=true;
                return;
            }

            transform.LookAt(head.position); //2 * transform.position - head.position);

            // Sigue a la persona sin sobrepasar la distancia de seguridad
            if (Vector3.Distance(transform.position, head.position) > (OpcionesScript._dist_seguridad + 10) * 0.01) {
                step = speed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, head.position, step);
                //if(camaraFotos.foto_tomada) camaraFotos.foto_tomada=false;
            }
            /* else{ 
                if(!camaraFotos.foto_tomada) camaraFotos.HazFoto();
            } */
            

            //rb.velocity = Vector3.zero; rb.angularVelocity = Vector3.zero;
        }
        catch(MissingReferenceException e){
            Debug.Log("No se ha encontrado la cabeza de la persona.");
            Debug.Log(e.ToString());
            Destroy(this);
        }
        
    }

    void OnCollisionExit(){
        rb.velocity = Vector3.zero; rb.angularVelocity = Vector3.zero;
    }
}
