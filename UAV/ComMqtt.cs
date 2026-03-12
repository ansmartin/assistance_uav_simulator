using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

using System.Text;
using System.Diagnostics;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

public class ComMqtt : MonoBehaviour {

    //https://m2mqtt.wordpress.com/m2mqtt_doc/
    //private MqttClient client;
    // The connection information
    // public string brokerHostname = "161.67.100.85";
    public string brokerHostname = "Localhost";
    public int brokerPort = 8883;
    public string userName1 = "Unity3dClient-n1";
    public string userName2 = "Unity3dClient-n2";
    public TextAsset certificate;
    // listen on all the Topic
    static string subTopic = "#";
    static MqttClient client1;
    static MqttClient client2;

    static public Vector3 positionReceived;

    static public Vector3 rotationReceived;



    //public ComMqtt objectMqtt;

    

    //static public float positionX;
    //static public float positionY;
    //static public float positionZ;

    // Constructor de la Clase
    public ComMqtt()
    {
        brokerHostname = OpcionesScript._brokerHostname;
        positionReceived = new Vector3(0f, 0f, 0f);
        rotationReceived = new Vector3 (0f, 0f, 0f);
    }

    //static public Vector3 PositionReceived
    //{
    //    get { return positionReceived; }
    //    set { positionReceived = value; }
    //}

    public Vector3 getPosition()
    {
        return positionReceived;
    }    

    public void setPosition(Vector3 pos)
    {
        positionReceived = pos;
    }

    public Vector3 getRotation()
    {
        return rotationReceived;
    }

    public void setRotation(Vector3 rot)
    {
        rotationReceived = rot;
    }


    



    // Use this for initialization
    void Start()
    {

        //StartMosquittoCMD();
        //ConfigMqttConnection();
               
    }

    // Update is called once per frame
    void Update () {
        
        
    }

    public void StartMosquittoCMD()
    {
        //string YourApplicationPath = "C:\\Mosquitto";
        ProcessStartInfo processInfo = new ProcessStartInfo();
        //processInfo.WindowStyle = ProcessWindowStyle.Hidden;
        processInfo.FileName = "CMD.exe";
        //processInfo.WorkingDirectory = Path.GetDirectoryName(YourApplicationPath);
        processInfo.WorkingDirectory = "C:\\Mosquitto";
        processInfo.Arguments = "/C mosquitto -v ";
        Process.Start(processInfo);
    }

    public void ConfigMqttConnection()
    {
        try
        {

            // CLIENT DEFINITION
            client1 = new MqttClient(brokerHostname);
            client2 = new MqttClient(brokerHostname);

            //string clientId = Guid.NewGuid().ToString();  // Genera un identificador
            string clientId1 = userName1;
            string clientId2 = userName2;

            byte connection1 = client1.Connect(clientId1);
            print("client1.Connect -> Connect: " + connection1);
            byte connection2 = client2.Connect(clientId2);
            print("client1.Connect -> Connect: " + connection2);

            // TOPICS DEFINITION
            /*string topic_1 = "test/Simulation Control";
            string topic_1_1 = topic_1 + "/Switch";
            string topic_1_2 = topic_1 + "/Sample Time";
            string topic_1_3 = topic_1 + "/Simulation Time";
            string topic_1_0 = topic_1 + "/Feedback";

            string topic_2 = "test/Visualization";
            string topic_2_0 = topic_2 + "/Data";*/
            string topic_2_0 = "UAV/Data";

            //string[] topic_sub_1_0 = { topic_1_0 };
            byte[] levelQoS = { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE }; // MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE = 0 -> QoS
                                                                      // byte[] nivel = { 0 };

            string[] topic_sub_2_0 = { topic_2_0 };

            //ushort msgId1 = client1.Subscribe(topic_sub_1_0, levelQoS);
            //client1.MqttMsgPublishReceived += client1_MqttMsgPublishReceived_MATLAB;
            //Debug.WriteLine("client1.Subscribe -> msdgId: " + msgId1);

            ushort msgId2 = client2.Subscribe(topic_sub_2_0, levelQoS);
            client2.MqttMsgPublishReceived += client2_MqttMsgPublishReceived_MATLAB_6Data;
            print("client2.Subscribe -> msdgId: " + msgId2);

            //Start Simulation
            /*ushort msgIdp1 = client1.Publish(topic_1_1, //Tópico
                Encoding.UTF8.GetBytes("Start Simulation"), //Mensaje a enviar codificado
                MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE, //Nivel de QoS 0    
                false); //Bandera de Mensaje retenido

            Console.WriteLine("Waiting...");
            while (stateSimulation == "Stop") { }

            Console.WriteLine("Simulation Started");
            Console.WriteLine("Messages:");

            Console.WriteLine("Running...");
            while (stateSimulation == "Started") { }

            Console.WriteLine("Simulation Finished");

            Console.WriteLine("END");

            */

            //}
            //else
            //{
            // Fin Programa
            //    Console.WriteLine("END");
            //}


        }

        catch (uPLibrary.Networking.M2Mqtt.Exceptions.MqttConnectionException e)
        {
            // Error al conectar 
            UnityEngine.Debug.Log("Exception: " + e);

        }
        catch (uPLibrary.Networking.M2Mqtt.Exceptions.MqttCommunicationException e)
        {
            // Error comunicación
            UnityEngine.Debug.Log("Exception: " + e);

        }
        catch (Exception e)
        {
            // Otros Errores
            UnityEngine.Debug.Log("Exception: " + e);
        }
    }

    static void client2_MqttMsgPublishReceived_MATLAB_6Data(object sender, MqttMsgPublishEventArgs e)
    {

        //if (e.Topic == "test/Visualization/Data")
        //{
        //print("Data: " + Encoding.UTF8.GetString(e.Message) + ". Time: " + DateTime.Now);
        //Console.WriteLine(string.Format("Data: {0} , Time: {1}", Encoding.UTF8.GetString(e.Message), DateTime.Now));

        //Console.WriteLine("Data: " + Encoding.UTF8.GetString(e.Message));
        //Debug.WriteLine("Data: " + Encoding.UTF8.GetString(e.Message));
        //Debug.WriteLine(string.Format("Data: {0} , Time: {1}", Encoding.UTF8.GetString(e.Message), DateTime.Now));

        string stringMessage = System.Text.Encoding.Default.GetString(e.Message);
        //var JSONObj1 = JsonConvert.DeserializeObject(stringMessage);
        //List<float> listJSONObj1 = (List<float>)JsonConvert.DeserializeObject(stringMessage, typeof(List<float>));

        var JSONObj2 = JsonConvert.DeserializeObject(Encoding.UTF8.GetString(e.Message));
        List<float> listJSONObj2 = (List<float>)JsonConvert.DeserializeObject(Encoding.UTF8.GetString(e.Message), typeof(List<float>));


        //------------------------------------------------------------------------------
        // POSITION
        float posX_matlab = listJSONObj2[0]; 
        float posY_matlab = listJSONObj2[1];
        float posZ_matlab = listJSONObj2[2];

        positionReceived.x = posX_matlab; // posX_unity = posX_matlab
        positionReceived.y = posZ_matlab; // posY_unity = posZ_matlab
        positionReceived.z = posY_matlab; // posZ_unity = posY_matlab
        //-------------------------------------------------------------------------------

        //--------------------------------------------------------------------------------
        // ORIENTATION (Rad -> Deg) 
        float rotX_matlab = listJSONObj2[3] * Mathf.Rad2Deg;   // rotX_matlab = pitch (theta)
        float rotY_matlab = listJSONObj2[4] * Mathf.Rad2Deg;   // rotY_matlab = roll  (phi)
        float rotZ_matlab = listJSONObj2[5] * Mathf.Rad2Deg;   // rotZ_matlab = yaw   (psi)

        rotationReceived.x = - rotX_matlab;  // rotX_unity = - rotX_matlab = - pitch (theta)
        rotationReceived.y = - rotZ_matlab;  // rotY_unity = - rotZ_matlab = - yaw   (psi)
        rotationReceived.z = - rotY_matlab;  // rotZ_unity = - rotY_maltab = - roll  (phi)
        // ---------------------------------------------------------------------------------
        

        


    }


}
