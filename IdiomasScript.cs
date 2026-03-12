using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IdiomasScript : MonoBehaviour
{
    //public OpcionesScript opciones;
    
    public Text[] paneles_texto;

    public Dropdown[] dropdowns;

    public string[] emociones = new string[7];


    public Dropdown idioma_dropdown;
    public Idioma esp;
    public Idioma eng;


    
    public delegate void IdiomaEventHandler();
    public event IdiomaEventHandler ActualizarTextos;
    

    void Start(){
        int option = OpcionesScript._idioma;

        // pone correctamente el estado del dropdown de idiomas al inicio
        idioma_dropdown.value = option;
        
        // cambia el idioma al inicio
        CambiarIdioma(option);
        
    }

    
    // Cambia el idioma de la aplicación
    public void CambiarIdioma(int option){

        OpcionesScript._idioma = option;

        switch(option){
            case 0: //español
                EditarTextos(esp);
                break;

            case 1: //english
                EditarTextos(eng);
                break;
        }

        OnActualizarTextos();
    }


    private void EditarTextos(Idioma idioma){

        string[] textos = idioma.textos;
        string[] dropdown_textos = idioma.dropdown_textos;

        for(int i=0; i<paneles_texto.Length; i++){
            paneles_texto[i].text = textos[i];
        }

        int pos = 0;
        for(int i=0; i<dropdowns.Length; i++){
            for(int j=0; j<dropdowns[i].options.Count; j++){
                dropdowns[i].options[j].text = dropdown_textos[pos+j]; 
            }
            pos += dropdowns[i].options.Count;

            //dropdowns[i].transform.GetChild(0).GetComponent<Text>().text = dropdowns[i].options[dropdowns[i].value].text;
            dropdowns[i].captionText.text = dropdowns[i].options[dropdowns[i].value].text;

        }


        for(int i=0; i<dropdowns[1].options.Count-1; i++){
            emociones[i] = dropdowns[1].options[i].text;
        }

        
    }


    public Idioma GetIdiomaObject(){
        switch(OpcionesScript._idioma){
            case 0: //español
                return esp;
            case 1: //english
                return eng;
        }
        return null;
    }



    private void OnActualizarTextos()
    {
        if (ActualizarTextos != null)
        {
            ActualizarTextos();
        }
    }



}
