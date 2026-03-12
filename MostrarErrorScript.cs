using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MostrarErrorScript : MonoBehaviour
{
    public GameObject panelError;
    public Text error_texto;
    public Text mosquitto_text;
    public Text matlab_text;

    public void MostrarPanelError(int opcion){

        // se muestra el mensaje del error
        switch(opcion){
            case 0:
                error_texto.text = mosquitto_text.text;
                break;
            case 1:
                error_texto.text = matlab_text.text;
                break;
        }

        // se activa el panel de error
        panelError.SetActive(true);
    }

}
