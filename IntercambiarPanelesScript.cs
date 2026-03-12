using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntercambiarPanelesScript : MonoBehaviour
{
    [Header("Paneles")]
    public GameObject panel1;
    public GameObject panel2;
    
    public void Intercambiar(){
        //intercambia las imagenes
        Transform imagen1 = panel1.transform.GetChild(1);
        Transform imagen2 = panel2.transform.GetChild(1);
        imagen1.GetChild(0).SetParent(imagen2);
        imagen2.GetChild(0).SetParent(imagen1);

        //intercambia el texto
        Text t1 = panel1.transform.GetChild(0).GetChild(0).GetComponent<Text>();
        Text t2 = panel2.transform.GetChild(0).GetChild(0).GetComponent<Text>();
        string aux = t1.text;
        t1.text = t2.text;
        t2.text = aux;

        //intercambia colores
        Image c1 = panel1.transform.GetChild(0).GetComponent<Image>();
        Image c2 = panel2.transform.GetChild(0).GetComponent<Image>();
        Color c = c1.color;
        c1.color = c2.color;
        c2.color = c;

    }

}
