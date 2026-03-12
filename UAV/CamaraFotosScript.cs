using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using uPLibrary.Networking.M2Mqtt;
using System.Text;

public class CamaraFotosScript : MonoBehaviour
{
    string ubicacion;
    //public RenderTexture rt;
    public RawImage imagen; 
    Texture2D textura;
    RenderTexture currentRT, renderTexture;
    byte[] bytes;

    public bool foto_tomada=false;


    MqttClient client;
    string topic = "PJ/Face";
    string clientId = "camaraFotos";


    // Start is called before the first frame update
    void Start()
    {
        client = new MqttClient(OpcionesScript._brokerHostname);
        client.Connect(clientId);

        StartCoroutine(FotosBucle());
    }


    public void HazFoto(){
        foto_tomada = true;
        StartCoroutine(GuardaImagen());
    }

    
    public IEnumerator GuardaImagen()
    {
        yield return new WaitForEndOfFrame();


        textura = new Texture2D(imagen.texture.width, imagen.texture.height);
        currentRT = RenderTexture.active;
        renderTexture = RenderTexture.GetTemporary(imagen.texture.width, imagen.texture.height, 32);
        Graphics.Blit(imagen.texture, renderTexture);

        RenderTexture.active = renderTexture;
        textura.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
        textura.Apply();

        RenderTexture.active = currentRT;
        RenderTexture.ReleaseTemporary(renderTexture);

        bytes = textura.EncodeToPNG();

        // guardar imagen como png en el ordenador
        //ubicacion = Application.dataPath + "/../fotos/" + System.DateTime.Now.ToString("yyyy-MM-dd-THH-mm-ss") + ".png";
        //System.IO.File.WriteAllBytes(ubicacion, bytes);

        // enviar imagen
        client.Publish(topic, bytes);
    }


    public IEnumerator FotosBucle(){
        for(;;){
            yield return new WaitForSeconds(1);

            // toma imagen
            yield return new WaitForEndOfFrame();

            textura = new Texture2D(imagen.texture.width, imagen.texture.height);
            currentRT = RenderTexture.active;
            renderTexture = RenderTexture.GetTemporary(imagen.texture.width, imagen.texture.height, 32);
            Graphics.Blit(imagen.texture, renderTexture);

            RenderTexture.active = renderTexture;
            textura.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
            textura.Apply();

            RenderTexture.active = currentRT;
            RenderTexture.ReleaseTemporary(renderTexture);

            bytes = textura.EncodeToPNG();

            // guardar imagen como png en el ordenador
            //ubicacion = Application.dataPath + "/../fotos/" + System.DateTime.Now.ToString("yyyy-MM-dd-THH-mm-ss") + ".png";
            //System.IO.File.WriteAllBytes(ubicacion, bytes);

            // enviar imagen
            client.Publish(topic, bytes);
        }
    }


}
