using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MostrarControlDropdownScript : MonoBehaviour
{
    public GameObject linea;

    public void MostrarControl(int opcion){

        switch(opcion){
            case 0 :
                linea.SetActive(true);
                break;
            case 1 :
                linea.SetActive(true);
                break;
            case 2 :
                linea.SetActive(false);
                break;
        }
    }

}
