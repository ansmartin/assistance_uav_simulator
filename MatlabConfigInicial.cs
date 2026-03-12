using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

using System.Text;
using Newtonsoft.Json;

public class MatlabConfigInicial : MonoBehaviour
{
    
    private string brokerHostname = OpcionesScript._brokerHostname;
    private string topic = "InitialConfig";

    static MqttClient client;

    private bool arrived = false;   // mensaje de respuesta de matlab 




    // Envía a Matlab la configuración inicial para la simulación
    public void MandarConfig()
    {
        // se conecta al broker
        brokerHostname = OpcionesScript._brokerHostname;
        client = new MqttClient(brokerHostname);
        client.Connect(brokerHostname);

        // crea el mensaje
        ConfigInicial config = new ConfigInicial();
        config.tsim = OpcionesScript._t_sim;
        config.distseg = OpcionesScript._dist_seguridad;

        string json = config.SaveToJSON();

        /*
        List<int> lista = new List<int>();
        lista.Add(t_sim);
        lista.Add(dist_seguridad);

        string sjson = JsonConvert.SerializeObject(lista);
        */
        

        //Debug.Log(json);

        // publica el mensaje
        client.Publish(topic, Encoding.UTF8.GetBytes(json));
    }


    // Espera a que Matlab responda al mensaje de iniciación
    public bool EsperaRespuesta()
    {
        string[] topics = { topic+"/resp" };
        byte[] qosLevels = { MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE };
        
        client.Subscribe(topics, qosLevels);

        // se suscribe al evento "MqttMsgPublishReceived". Cuando se lance, se ejecuta el método "client_MqttMsgPublishReceived"
        client.MqttMsgPublishReceived += client_MqttMsgPublishReceived;
        
        //System.Threading.Thread.Sleep(1000);
        //return arrived;
        
        // comprueba si llega la respuesta cada 0.5 segundos 5 veces 
        for(int i=0;i<5;i++){
            if(arrived){
                return true; 
            }
            else{
                System.Threading.Thread.Sleep(500);
                
            }
        }
        return false;
        

    }

    void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
    {
        string stringMessage = System.Text.Encoding.Default.GetString(e.Message);
        Debug.Log("Respuesta recibida: " + stringMessage);
        arrived = true;
    }

}
