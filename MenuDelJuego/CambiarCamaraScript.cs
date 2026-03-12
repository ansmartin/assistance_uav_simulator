using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambiarCamaraScript : MonoBehaviour
{

    public GameObject[] camaras;


    public void CambiarCamara(int opcion){

        for(int i=0; i<camaras.Length; i++){
            if(opcion == i)
                camaras[i].SetActive(true);
            else
                camaras[i].SetActive(false);
        }
        
    }

 


}
