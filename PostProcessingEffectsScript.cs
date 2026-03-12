using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessingEffectsScript : MonoBehaviour
{
    //public OpcionesScript opciones;


    public PostProcessLayer pj;

    public PostProcessLayer rv, rv_layout, rv_sim;
    
    public PostProcessLayer uav;

    public Transform room;


    void Start(){
        
        GestionarEfectos(OpcionesScript._postprocess);

    }



    // Activar o desactivar los efectos de post procesado en todas las cámaras
    void GestionarEfectos(bool option)
    {
        pj.enabled = option;

        rv.enabled = option;
        rv_layout.enabled = option;
        rv_sim.enabled = option;

        uav.enabled = option;

        for(int i=0; i < room.childCount; i++){
            room.GetChild(i).GetComponent<PostProcessLayer>().enabled = option;
        }

    }



}
