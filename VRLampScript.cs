using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRLampScript : MonoBehaviour
{
    public bool luz_cerca = false;
    private LamparaScript lampara;

    public void Presionar(){
        if(luz_cerca)
            lampara.EncenderApagar();
    }

    void OnTriggerEnter(Collider col){
        Debug.Log(col.tag);
		
		if (col.gameObject.CompareTag("lamp")){
            luz_cerca = true;
			lampara = col.transform.GetComponent<LamparaScript>();
        }
	}
	
	void OnTriggerExit(Collider col){
		
        if (col.gameObject.CompareTag("lamp"))
		{
			//luz_cerca = false;
        }
	}
}
