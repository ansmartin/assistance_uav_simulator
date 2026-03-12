using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReordenarPanelesScript : MonoBehaviour
{
    //public OpcionesScript opciones;

    [Header("Paneles")]
    public Transform panelprincipal;
    public Transform panelsec1;
    public Transform panelsec2;


    [Header("Images")]
    public Transform imageprincipalpj;
    public Transform imageprincipalrv;
    private Transform imageprincipal;
    public Transform imagesec1;
    public Transform imagesec2;


    [Header("Text")]
    public IdiomasScript idiomasScript;
    private Idioma idioma;


    private int c;


    void Start(){
        c = OpcionesScript._control;

        if(c==1){
            imageprincipal = imageprincipalrv;
        }
        else {
            imageprincipal = imageprincipalpj;
        }

        //idioma = idiomasScript.GetIdiomaObject();
    }


    public void RestablecerLayout(){
        idioma = idiomasScript.GetIdiomaObject();
        RestablecerPanel(panelprincipal, imageprincipal, idioma.textos[0], new Color32(112,173,71,255));
        RestablecerPanel(panelsec1, imagesec1, idioma.textos[1], new Color32(91,155,213,255));
        RestablecerPanel(panelsec2, imagesec2, idioma.textos[2], new Color32(237,125,49,255));
    }
    

    void RestablecerPanel(Transform panel, Transform imagen, string t, Color32 c)
    {
        imagen.SetParent(panel.GetChild(1));
        panel.GetChild(0).GetChild(0).GetComponent<Text>().text = t;
        panel.GetChild(0).GetComponent<Image>().color = c;
    }
}
