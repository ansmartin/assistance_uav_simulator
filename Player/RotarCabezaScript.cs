using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotarCabezaScript : MonoBehaviour
{

    [Header("Cabeza")]
	public Transform head;

    private Transform camara;

    private float speed = 0.5f;



	/// <summary>Horizontal axis</summary>
    public float haxis { get; set; }

    /// <summary>Vertical Axis</summary>
    public float vaxis { get; set; }



    // Start is called before the first frame update
    void Start()
    {
        camara = transform.GetChild(8);  // esto es porque la camara se pone como el hijo numero 9 cuando se le añade al personaje

        ActualizarMaxRotacion();
    }


    // Máximo que puede rotar la cabeza del personaje
	private int max_arriba = 30, max_abajo = 35, max_dcha = 50, max_izq = 50, offset = 15;


	void ActualizarMaxRotacion(){
		//arriba y derecha son rotaciones negativas
		max_arriba = 360 - max_arriba;
		max_dcha = 360 - max_dcha;
	}


	public void RotarCabeza(){

		///////////////////////////////////////////////////////
		// Rotación de la cabeza
		///////////////////////////////////////////////////////
		haxis = Input.GetAxisRaw("HCam");
        vaxis = Input.GetAxisRaw("VCam");


		switch(haxis){
			case 0:
				break;
			case 1:
				// Girar hacia la derecha
				if(head.localRotation.eulerAngles.y > (max_dcha-offset) || head.localRotation.eulerAngles.y < max_izq){
					Vector3 v = new Vector3(0, 90 * speed * Time.deltaTime, 0);
					head.Rotate(v, Space.Self);
					camara.Rotate(v, Space.Self);

					ActualizarRotacionFinal();
				}
				break;
			case -1:
				// Girar hacia la izquierda
				if(head.localRotation.eulerAngles.y > max_dcha || head.localRotation.eulerAngles.y < (max_izq+offset)){
					Vector3 v = new Vector3(0, -90 * speed * Time.deltaTime, 0);
					head.Rotate(v, Space.Self);
					camara.Rotate(v, Space.Self);

					ActualizarRotacionFinal();
				}
				break;
			default:
				break;
		}


		switch(vaxis){
			case 0:
				break;
			case 1:
				// Mover hacia arriba
				if(head.localRotation.eulerAngles.x > max_arriba || head.localRotation.eulerAngles.x < (max_abajo+offset)){
					Vector3 v = new Vector3(-90 * speed * Time.deltaTime, 0, 0);
					head.Rotate(v, Space.Self);
					camara.Rotate(v, Space.Self);
					
					ActualizarRotacionFinal();

				}
				break;
			case -1:
				// Mover hacia abajo
				if(head.localRotation.eulerAngles.x > (max_arriba-offset) || head.localRotation.eulerAngles.x < max_abajo){
					Vector3 v = new Vector3(90 * speed * Time.deltaTime, 0, 0);
					head.Rotate(v, Space.Self);
					camara.Rotate(v, Space.Self);

					ActualizarRotacionFinal();
				}
				break;
			default:
				break;
		}



		/* if (Input.GetKey(KeyCode.W))
		{
			if(head.localRotation.eulerAngles.x > max_arriba || head.localRotation.eulerAngles.x < (max_abajo+offset)){
				Vector3 v = new Vector3(-90 * speed * Time.deltaTime, 0, 0);
				head.Rotate(v, Space.Self);
				camara.Rotate(v, Space.Self);
				
				ActualizarRotacionFinal();

			}
		}
		if (Input.GetKey(KeyCode.S))
		{
			if(head.localRotation.eulerAngles.x > (max_arriba-offset) || head.localRotation.eulerAngles.x < max_abajo){
				Vector3 v = new Vector3(90 * speed * Time.deltaTime, 0, 0);
				head.Rotate(v, Space.Self);
				camara.Rotate(v, Space.Self);

				ActualizarRotacionFinal();
			}
			
		}
		if (Input.GetKey(KeyCode.A))
		{
			if(head.localRotation.eulerAngles.y > max_dcha || head.localRotation.eulerAngles.y < (max_izq+offset)){
				Vector3 v = new Vector3(0, -90 * speed * Time.deltaTime, 0);
				head.Rotate(v, Space.Self);
				camara.Rotate(v, Space.Self);

				ActualizarRotacionFinal();
			}
			
		}
		if (Input.GetKey(KeyCode.D)) {
			if(head.localRotation.eulerAngles.y > (max_dcha-offset) || head.localRotation.eulerAngles.y < max_izq){
				Vector3 v = new Vector3(0, 90 * speed * Time.deltaTime, 0);
				head.Rotate(v, Space.Self);
				camara.Rotate(v, Space.Self);

				ActualizarRotacionFinal();
			}
			
		} */


        if(Input.GetButtonDown("Reset")) Restablecer();

		
    }

	void ActualizarRotacionFinal(){
		Vector3 finalRotation = head.localRotation.eulerAngles; //head.transform.eulerAngles;
		finalRotation.z = 0.0f;

		head.transform.localEulerAngles = finalRotation;
		camara.transform.localEulerAngles = finalRotation;

	}


    void Restablecer(){
        //devuelve la cabeza a su estado normal
        head.transform.localEulerAngles = camara.transform.localEulerAngles = Vector3.zero;
    }


}
