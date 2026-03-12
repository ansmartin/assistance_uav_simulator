using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MostrarIPScript : MonoBehaviour
{
    public GameObject ip;

    public void MostrarIP(int opcion){

        switch(opcion){
            case 0 :
                ip.SetActive(false);
                break;
            case 1 :
                ip.SetActive(true);
                break;
        }
    }

}
