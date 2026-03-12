using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ElegirConfigInicialScript : MonoBehaviour
{
    //[Header("Scripts opciones")]
    //public OpcionesScript opciones_script;
    //public MatlabConfigInicial confmatlab_script;

    [Header("Otras opciones")]
    public Toggle toggle_postprocess;
    public Toggle toggle_debug;
    public MostrarIPScript mostrarIP;


    [Header("Opciones del broker")]
    public Dropdown dropdown_broker;
    public InputField[] input_ip;

    [Header("Opciones de MQTT")]
    public InputField input_tsim;
    public InputField input_distseg;


    void Start()
    {
        // pone correctamente el estado de los toggles
        toggle_postprocess.isOn = OpcionesScript._postprocess;
        toggle_debug.isOn = OpcionesScript._debug;

        // pone correctamente el broker y actualiza el valor de la ip
        int option = OpcionesScript._broker_option;
        dropdown_broker.value = option;
        mostrarIP.MostrarIP(option);

        string[] ip = OpcionesScript._ip_values;
        for(int i=0; i<4; i++){
            input_ip[i].text = ip[i];
        }

        // pone correctamente los valores de los campos de la configuración
        input_tsim.text = OpcionesScript._t_sim.ToString();
        input_distseg.text = OpcionesScript._dist_seguridad.ToString();

    }


    public void ConfirmarOpciones(){

        // Confirma el broker
        int opcion_broker = dropdown_broker.value;
        OpcionesScript._broker_option = opcion_broker;

        switch(opcion_broker){
            case 0 :
                OpcionesScript._brokerHostname = "Localhost";
                break;
            case 1 :
                string ip = "";
                for(int i=0; i<3; i++){
                    ip += input_ip[i].text + ".";
                }
                ip += input_ip[3].text;
                
                //actualiza la dirección ip del broker
                OpcionesScript._brokerHostname = ip;

                OpcionesScript._ip_values = new string[4] { input_ip[0].text, input_ip[1].text, input_ip[2].text, input_ip[3].text } ;

                break;
        }


        // Confirma efectos de postprocesado
        OpcionesScript._postprocess = toggle_postprocess.isOn;

        // Confirma debug
        OpcionesScript._debug = toggle_debug.isOn;


        // Confirma el tiempo de simulación
        OpcionesScript._t_sim = int.Parse(input_tsim.text);

        // Confirma la distancia de seguridad
        OpcionesScript._dist_seguridad = int.Parse(input_distseg.text);

    }


}
