using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class InicioScript : MonoBehaviour
{
    
    [Header("Hombre")]
    public GameObject hombre; // modelo señor
    public GameObject head_hombre; // modelo cabeza rv señor
    public GameObject body_hombre; // modelo cuerpo rv señor
    public Transform cabeza_h;

    [Header("Mujer")]
    public GameObject mujer; // modelo señora
    public GameObject head_mujer; // modelo cabeza rv señora
    public GameObject body_mujer; // modelo cuerpo rv señora

    public Transform cabeza_m;
    
    [Header("Casco de RV")]
    // componentes de realidad virtual
    public GameObject rv;
    public Transform cabeza_rv;
    public GameObject suelo_teleport;
    public GameObject teleporting;
    public GameObject rendertextureRV;

    [Header("Cámara personaje")]
    public GameObject camara;
    public GameObject rendertexturePJ;

    [Header("Publisher")]
    public GameObject publisher;

    [Header("UAV")]
    public GameObject uav;


    private int npj, control;

    private MqttPublisher publisher_script;


    // Start is called before the first frame update
    void Start()
    {
        // Inicializar script del UAV
        if(OpcionesScript._debug){
            uav.transform.GetChild(0).transform.Rotate(0,-45,0);
            uav.GetComponent<UAVejemplo>().enabled = true;
        }
        else {
            uav.GetComponent<UAV>().enabled = true;
        }

        // Inicializar publisher de los datos de la persona
        publisher_script = publisher.GetComponent<MqttPublisher>();

        // Inicializar  pj y control
        npj = OpcionesScript._pj;
        control = OpcionesScript._control;

        
        switch(control){
            // teclado
            case 0 :
                // activar pj
                Activar();
                break;

            // realidad virtual
            case 1 :
                teleporting.SetActive(true);
                suelo_teleport.SetActive(true);
                rv.SetActive(true);
                ActivarHeadRV();
                Destroy(camara);
                Destroy(rendertexturePJ);
                publisher_script.head = cabeza_rv;
                break;

            // automatico
            case 2 :
                // activar pj
                Activar();
                break;
        }



        // se activa el publisher
        if(!OpcionesScript._debug){
            publisher_script.brokerHostname = OpcionesScript._brokerHostname;
            publisher.SetActive(true);
        }
        
        

    }




    private void Activar(){

        switch(npj){
            case 0 :
                ActivarPJ(hombre, cabeza_h);
                break;
            case 1 :
                ActivarPJ(mujer, cabeza_m);
                break;
            
        }

    }


    private void ActivarPJ(GameObject pj, Transform cabeza){

        pj.SetActive(true);
        camara.transform.SetParent(pj.transform);
        //camara.transform.SetParent(cabeza);
        camara.GetComponent<CamaraScript>().head = cabeza;
        publisher.GetComponent<MqttPublisher>().head = cabeza;

        Destroy(rendertextureRV);

        switch(control){
            case 0 :
                // elimina los componentes necesarios para el control automatico
                Destroy(pj.GetComponent<PlayerAutoScript>());
                Destroy(pj.GetComponent<NavMeshAgent>());
                break;
            case 2 :
                // elimina el control manual
                Destroy(pj.GetComponent<PlayerScript>());
                break;
            
        }

    }


    private void ActivarHeadRV(){
        switch(npj){
            case 0 :
                head_hombre.SetActive(true);
                body_hombre.SetActive(true);
                break;
            case 1 :
                head_mujer.SetActive(true);
                body_mujer.SetActive(true);
                break;
            
        }
    }



}
