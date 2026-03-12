using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputFieldScript : MonoBehaviour
{

    private InputField inputField;
    public int min, max;

    // Start is called before the first frame update
    void Start()
    {
        inputField = GetComponent<InputField>();
    }

    
    public void Ajustar(string s)
    {
        if(s != ""){
            int valor = int.Parse(s);

            if(min > valor) 
                inputField.text = min.ToString();
            else if(valor > max)
                inputField.text = max.ToString();
        }
        else 
            inputField.text = min.ToString();
        
    }

}
