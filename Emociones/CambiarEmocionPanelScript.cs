using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CambiarEmocionPanelScript : MonoBehaviour
{

    public EmocionesCaraScript emocionesCaraScript;
    Dropdown dropdown_emocion;

    void Start() {
        dropdown_emocion = GetComponent<Dropdown>();
        dropdown_emocion.value = OpcionesScript._emocion;
    }


    // Update is called once per frame
    public void CambiarEmocion(int emocion)
    {
        if(emocionesCaraScript!=null) {
            OpcionesScript._emocion = emocion;
            emocionesCaraScript.InitCara();
        }
    }
}
