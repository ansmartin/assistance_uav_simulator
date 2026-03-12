using System.Collections;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.UI;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

public class DetectorEmocionesScript : MonoBehaviour
{
    string username = "UnityEmociones";
    string topic = "PJ/Emotion";
    MqttClient client;

    public IdiomasScript idiomasScript;
    

    GameObject panelEmocionDec;
    public Text emocion_text;
    public Text confianza_text;


    IEnumerator actualizarPanel;

    // Start is called before the first frame update
    void Start()
    {
        panelEmocionDec = this.gameObject.transform.GetChild(0).gameObject;


        // conectarse al broker y suscribirse al topic de la emoción detectada
        client = new MqttClient(OpcionesScript._brokerHostname);

        client.Connect(username);

        byte[] levelQoS = { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE };
        string[] topics = { topic };

        client.Subscribe(topics, levelQoS);

        client.MqttMsgPublishReceived += MostrarEmocionDetectada;

    }

    bool actualizar = false;

    private void Update() {
        if(actualizar){
            if(actualizarPanel!=null) StopCoroutine(actualizarPanel);
            actualizarPanel = ActualizarPanelEmocion();
            StartCoroutine(actualizarPanel);

            actualizar=false;
        }
    }
    

    string stringMessage;
    Dictionary<string, int> JSON_obj;

    void MostrarEmocionDetectada(object sender, MqttMsgPublishEventArgs e)
    {
        //stringMessage = System.Text.Encoding.Default.GetString(e.Message);
        //Debug.Log(stringMessage);

        JSON_obj = (Dictionary<string, int>)JsonConvert.DeserializeObject(Encoding.UTF8.GetString(e.Message), typeof (Dictionary<string, int>));
        
        //Debug.Log(JSON_obj["emotion"] +"   "+ JSON_obj["confianza"]);

        actualizar = true;

    }

    IEnumerator ActualizarPanelEmocion(){
        panelEmocionDec.SetActive(true);

        emocion_text.text = idiomasScript.emociones[ DatosEmociones.traductor[ JSON_obj["emotion"] ] ];
        confianza_text.text = JSON_obj["confianza"].ToString();

        yield return new WaitForSeconds(10);
        panelEmocionDec.SetActive(false);
    }

    
}
