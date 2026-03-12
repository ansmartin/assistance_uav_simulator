using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElegirOpcionesScript : MonoBehaviour
{
    //[Header("Script de opciones")]
    //public OpcionesScript opciones_script;

    [Header("Opciones de pj y control")]
    public Dropdown dropdown_pj;
    public Dropdown dropdown_control;
    public Dropdown dropdown_emocion;


    private void Start() {
        // inicia los valores de los dropdowns
        dropdown_pj.value = OpcionesScript._pj;
        dropdown_control.value = OpcionesScript._control;
        dropdown_emocion.value = OpcionesScript._emocion;
    }


    public void ConfirmarPJ(){
        //coge los valores seleccionados de los desplegables y actualiza el script de opciones
        OpcionesScript._pj = dropdown_pj.value;
        OpcionesScript._control = dropdown_control.value;
        OpcionesScript._emocion = dropdown_emocion.value;
    }


}
