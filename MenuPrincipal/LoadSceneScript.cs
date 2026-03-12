using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneScript : MonoBehaviour
{
    //public OpcionesScript opciones;

    public GameObject loadingtext;

    public MatlabConfigInicial confmatlab_script;

    private MostrarErrorScript me;

    public GameObject Player; //entre cambio de escenas hay que borrar al player rv

    public void LoadScene(){

        me = GetComponent<MostrarErrorScript>();

        if(OpcionesScript._debug){
            CargarEscena();
        }
        else

        try{
            // se intenta mandar la configuración a matlab y se espera la respuesta
            confmatlab_script.MandarConfig();

            bool resp = confmatlab_script.EsperaRespuesta();

            if (resp) {
                // carga la simulación cuando llegue la respuesta de matlab
                CargarEscena();
            }
            else{
                // muestra un error si Matlab no responde
                me.MostrarPanelError(1);
                Debug.Log("Matlab no responde");
            } 

        }
        catch (uPLibrary.Networking.M2Mqtt.Exceptions.MqttConnectionException e){
            // muestra un error si no se ha podido conectar a Mosquitto
            me.MostrarPanelError(0);
            Debug.Log(e.ToString());
        }
        catch (uPLibrary.Networking.M2Mqtt.Exceptions.MqttCommunicationException e){
            // muestra error de comunicación con Mosquitto
            me.MostrarPanelError(0);
            Debug.Log(e.ToString());
        }
        
    }


    void CargarEscena(){
        loadingtext.SetActive(true);
        SceneManager.LoadScene(OpcionesScript._escena);
    }


    public void BacktoMenu(){
        SceneManager.LoadScene(0);
        Destroy(Player);
    }
    
}
