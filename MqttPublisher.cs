using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using uPLibrary.Networking.M2Mqtt;

using System.Text;
using Newtonsoft.Json;

using static System.Math;

public class MqttPublisher : MonoBehaviour
{
    // public string brokerHostname = "161.67.100.85";
    public string brokerHostname = "Localhost";
    public int brokerPort = 1883;
    public string topic = "PJ/Data";

    static MqttClient client;

    public Transform head;

    public Text mensaje_pantalla1, mensaje_pantalla2;

    //private int cifras_dec = 2; //cifras decimales

    private PJData pd;



    // Start is called before the first frame update
    void Start()
    {
        client = new MqttClient(brokerHostname);
        client.Connect(brokerHostname);
        
        StartCoroutine(PublishDelay());
    }


    IEnumerator PublishDelay()
    {
        for(;;){
            Publish();
            yield return new WaitForSeconds(1);
        }
        
    }

    string json;
    void Publish()
    {

        //
        // Manera 1
        //

    /*
        List<float> al = new List<float>();
        al.Add((float)Round(head.position.x, cifras_dec));  // posX_matlab = posX_unity
        al.Add((float)Round(head.position.z, cifras_dec));  // posY_matlab = posZ_unity
        al.Add((float)Round(head.position.y, cifras_dec));  // posZ_matlab = posY_unity
        al.Add((float)Round(head.rotation.eulerAngles.x * Mathf.Deg2Rad * -1, cifras_dec));  // rotX_matlab = - rotX_unity = - pitch (theta)
        al.Add((float)Round(head.rotation.eulerAngles.z * Mathf.Deg2Rad * -1, cifras_dec));  // rotY_matlab = - rotZ_unity = - yaw   (psi)
        al.Add((float)Round(head.rotation.eulerAngles.y * Mathf.Deg2Rad * -1, cifras_dec));  // rotZ_matlab = - rotY_unity = - roll  (phi)

    

        // serializa el mensaje json
        string sjson = JsonConvert.SerializeObject(al);

        Debug.Log(sjson);
        
        // publica el mensaje
        client.Publish(topic, Encoding.UTF8.GetBytes(sjson));

    
        //byte[] datos = Encoding.UTF8.GetBytes(sjson);
        ////Debug.Log(datos);
        ////Debug.Log(Encoding.UTF8.GetString(datos));
        //List<float> ej = (List<float>)JsonConvert.DeserializeObject(Encoding.UTF8.GetString(datos), typeof(List<float>));
        //Debug.Log( "x: "+ej[0]+", y: "+ej[2]+", z: "+ej[1] + ", rot_x: "+ej[3]+", rot_y: "+ej[5]+", rot_z: "+ej[4] );

    */ 

        //
        // Manera 2
        //
        
        //PJData pd = new PJData();
        pd.x = head.position.x;  // posX_matlab = posX_unity
        pd.y = head.position.z;  // posY_matlab = posZ_unity
        pd.z = head.position.y;  // posZ_matlab = posY_unity
        //pd.rotx = head.rotation.eulerAngles.x * Mathf.Deg2Rad * -1;  // rotX_matlab = - rotX_unity = - pitch (theta)
        //pd.roty = head.rotation.eulerAngles.z * Mathf.Deg2Rad * -1;  // rotY_matlab = - rotZ_unity = - yaw   (psi)
        pd.rot = (head.rotation.eulerAngles.y-90) * Mathf.Deg2Rad * -1;  // rotZ_matlab = - rotY_unity = - roll  (phi)

        json = pd.SaveToJSON();
        //Debug.Log(json);
        mensaje_pantalla1.text = "x: "+head.position.x+"   y: "+head.position.y+"   z: "+head.position.z+"   rot: "+head.rotation.eulerAngles.y;
        mensaje_pantalla2.text = json;

        client.Publish(topic, Encoding.UTF8.GetBytes(json));
    
        
    }

}
