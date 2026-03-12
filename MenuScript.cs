using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    //[Header("Opciones")]
    //public OpcionesScript opciones;

    [Header("Titulos panel escena")]
    public Text Titulo;
    public Text sencilla;
    public Text realista;
    public Text patio;




    public void PanelEscena(int escena){

        OpcionesScript._escena = escena;

        switch(escena){
            case 1:
                Titulo.text = sencilla.text;
                break;
            case 2:
                Titulo.text = realista.text;
                break;
            case 3:
                Titulo.text = patio.text;
                break;
        }


    }


}
