using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CambiarPanelVistaScript : MonoBehaviour
{
    [Header("Paneles imagen")]
    public GameObject PanelPrincipal;
    public GameObject PanelIzquierdo;
    public GameObject PanelDerecho;

    [Header("Paneles texto")]
    public Text TextPrincipal;
    public Text TextIzquierdo;
    public Text TextDerecho;


    public void CambiarIzq(){
        //intercambia las imagenes
        PanelPrincipal.transform.GetChild(0).SetParent(PanelIzquierdo.transform);
        PanelIzquierdo.transform.GetChild(0).SetParent(PanelPrincipal.transform);

        //intercambia el texto
        string aux = TextPrincipal.text;
        TextPrincipal.text = TextIzquierdo.text;
        TextIzquierdo.text = aux;
    }

    public void CambiarDcha(){
        //intercambia las imagenes
        PanelPrincipal.transform.GetChild(0).SetParent(PanelDerecho.transform);
        PanelDerecho.transform.GetChild(0).SetParent(PanelPrincipal.transform);

        //intercambia el texto
        string aux = TextPrincipal.text;
        TextPrincipal.text = TextDerecho.text;
        TextDerecho.text = aux;
    }

}
