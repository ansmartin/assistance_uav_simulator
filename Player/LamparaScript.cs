using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LamparaScript : MonoBehaviour
{

    private bool encendido;
    private GameObject luz;
    private MeshRenderer mr;


    void Start(){
        encendido = false;
        luz = transform.GetChild(0).gameObject;
        mr = GetComponent<MeshRenderer>();
    }


    // Enciende o apaga la luz
    public void EncenderApagar(){

        // Cambia el estado
        encendido = !encendido;

        luz.SetActive(encendido);

        // Desactiva o activa las sombras del objeto al encender la lámpara
        if(encendido){
            mr.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
        }
        else{
            mr.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On; 
        }
        
    }




}
