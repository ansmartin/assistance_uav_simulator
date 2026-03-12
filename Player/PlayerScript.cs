using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerScript : MonoBehaviour {

    private float speed = 0.5f;
	private float walkspeed = 10;


	/// <summary>Horizontal axis</summary>
    public float haxis { get; set; }

    /// <summary>Vertical Axis</summary>
    public float vaxis { get; set; }





	//private Rigidbody rb;
	
	private bool asiento_cerca;
	private Vector3 asiento_position;
	private Quaternion asiento_rotation;
	private bool sentado, caminar;
	
	private bool luz_cerca;
	private LamparaScript lampara;

	private Animator anim;

	[Header("Panel canvas")]
	public GameObject panel;
	public Text m;

	[Header("Mensajes")]
	public Text m1;
	public Text m2;
	public Text m3;

	private string button = " [space]";

	[Header("IdiomasScript")]
	public IdiomasScript idiomas;


	private RotarCabezaScript rts;
	


	private int walk = Animator.StringToHash(nameof(walk)),
				stop = Animator.StringToHash(nameof(stop)),
				sit = Animator.StringToHash(nameof(sit)),
				up = Animator.StringToHash(nameof(up)),
				press = Animator.StringToHash(nameof(press));

	
	
    void Start ()
    {
        anim = GetComponent<Animator>();
		rts = GetComponent<RotarCabezaScript>();
		//rb = GetComponent<Rigidbody>();
		m.text = "";
		asiento_cerca = false;
		sentado = false;
		caminar = false;
		luz_cerca = false;

		

		// evento para actualizar el panel de acciones
		// (el player se suscribe al evento "ActualizarTextos". Cuando este se lance, se ejecuta el metodo "ActualizarPanelAcciones")
		idiomas.ActualizarTextos += ActualizarPanelAcciones;
    }

    void Update ()
    {	
		
		///////////////////////////////////////////////////////
		// Girar la cabeza
		///////////////////////////////////////////////////////
		rts.RotarCabeza();



		///////////////////////////////////////////////////////
		// Detener movimiento
		///////////////////////////////////////////////////////
		/* if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow)) {

			if(caminar){
				anim.SetBool(walk,false);
				//rb.velocity = Vector3.zero;
				//anim.SetTrigger(stop);
				Debug.Log("a pararse");
				caminar = false;
			}

		} */


		///////////////////////////////////////////////////////
		// Activar o desactivar opciones
		///////////////////////////////////////////////////////
		if (Input.GetButtonDown("Submit")) //.GetKeyDown(KeyCode.Space))
		{
			///////////////////////////////////////////////////////
			// Sentarse o levantarse
			///////////////////////////////////////////////////////
			if(asiento_cerca){
				sentado = !sentado;
				
				if (sentado){
					m.text = m2.text + button;
					//anim.Play("Sit down");
					//anim.IsInTransition(0);
					anim.SetTrigger(sit);
					transform.position = asiento_position;
					transform.rotation = asiento_rotation;
					
				}
				else{
					m.text = m1.text + button;
					//anim.Play("Stand up");
					anim.SetTrigger(up);
				}

				panel.SetActive(true);
				//anim.ResetTrigger(sit);
				//anim.ResetTrigger(up);
			}
			
			///////////////////////////////////////////////////////
			// Encender o apagar la luz de la lampara
			///////////////////////////////////////////////////////
			else if(luz_cerca){
				transform.LookAt(new Vector3(lampara.transform.position.x, transform.position.y, lampara.transform.position.z));
				//anim.Play("Press");
				anim.SetTrigger(press);
				lampara.EncenderApagar();
			}
			
			return;
		}
		else if (sentado) return;
		

		
		
		///////////////////////////////////////////////////////
		// Movimientos y giros
		///////////////////////////////////////////////////////
		haxis = Input.GetAxisRaw("Horizontal");
        vaxis = Input.GetAxisRaw("Vertical");
		
	
		switch(vaxis){
			case 0:
				// Parar
				if(caminar){
					anim.SetBool(walk,false);
					//rb.velocity = Vector3.zero;
					//anim.SetTrigger(stop);
					//Debug.Log("a pararse");
					caminar = false;
				}	
				break;
			case 1:
				// Moverse hacia delante
				transform.Translate(Vector3.forward * speed * Time.deltaTime);
				//rb.velocity = Vector3.forward * walkspeed;
				//rb.AddForce(Vector3.forward * speed);
				if(!caminar){
					anim.SetBool(walk,true);
					//anim.SetTrigger(walk);
					//Debug.Log("a caminar");
					caminar = true;
				}
				break;
			case -1:
				// Moverse hacia atrás
				transform.Translate(Vector3.back * speed * Time.deltaTime);
				//rb.velocity = Vector3.back * walkspeed;
				//rb.AddForce(Vector3.back * speed);
				if(!caminar){
					anim.SetBool(walk,true);
					//anim.SetTrigger(walk);
					//Debug.Log("a caminar");
					caminar = true;
				}
				break;
			default:
				break;
		}
	

		switch(haxis){
			case 0:
				break;
			case 1:
				// Girar hacia la derecha
				rotar(1);
				break;
			case -1:
				// Girar hacia la izquierda
				rotar(-1);
				break;
			default:
				break;
		}

        
		
		/* if (Input.GetKey(KeyCode.UpArrow)) {
			transform.Translate(Vector3.forward * speed * Time.deltaTime);
			if(!caminar){
				anim.SetBool(walk,true);
				//anim.SetTrigger(walk);
				Debug.Log("a caminar");
				caminar = true;
			}
		}
		
		else if (Input.GetKey(KeyCode.DownArrow)) {
			transform.Translate(Vector3.back * speed * Time.deltaTime);
			if(!caminar){
				anim.SetBool(walk,true);
				//anim.SetTrigger(walk);
				Debug.Log("a caminar");
				caminar = true;
			}
		}
		
		


		
		
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			rotar(-1);
		}

		if (Input.GetKey(KeyCode.RightArrow)) {
			rotar(1);
		} */
		
		
		//input_v = Input.GetAxisRaw("Vertical");
        //input_h = Input.GetAxisRaw("Horizontal");
        
		
		

		//Debug.Log($"{caminar}, {input_v}, {input_h}");
	}


	
	

/* 	void FixedUpdate(){

		if(input_v != 0){
			
			if(!caminar){
				anim.SetBool(walk,true);
				//anim.SetTrigger(walk);
				Debug.Log("a caminar");
				caminar = true;
			}

			transform.Translate(Vector3.forward * Time.deltaTime * input_v * speed);
			//rb.velocity = Vector3.forward * input_v * speed;
			//caminar = true;
			
		}
		else{

			if(caminar){
				anim.SetBool(walk,false);
				//rb.velocity = Vector3.zero;
				//anim.SetTrigger(stop);
				Debug.Log("a pararse");
				caminar = false;
			}

			//caminar = false;
			
		}
        
		if(input_h != 0){
			transform.Rotate(new Vector3(0, input_h * 90 * speed * Time.deltaTime, 0), Space.Self);
		}

	} */


	/* void LateUpdate(){
		if(anim.IsInTransition(0)) Debug.Log("is in transition");
	} */


	void rotar(int n){
		transform.Rotate(new Vector3(0, n * 90 * speed * Time.deltaTime, 0), Space.Self);

	}
	
	
	
    void OnTriggerEnter(Collider col){
		
        if (col.gameObject.CompareTag("asiento"))
		{
			panel.SetActive(true);
            m.text = m1.text + button;
			asiento_cerca = true;
			asiento_position = col.transform.position;
			asiento_rotation = col.transform.rotation;
        }
		
		else if (col.gameObject.CompareTag("lamp"))
		{
			panel.SetActive(true);
			m.text = m3.text + button;
            luz_cerca = true;
			lampara = col.transform.GetComponent<LamparaScript>();
        }
	}
	
	void OnTriggerExit(Collider col){
		
        if (col.gameObject.CompareTag("asiento"))
		{
			panel.SetActive(false);
            m.text = "";
			asiento_cerca = false;
        }
		
		else if (col.gameObject.CompareTag("lamp"))
		{
			panel.SetActive(false);
            m.text = "";
			luz_cerca = false;
        }
	}
	
	
	void ActualizarPanelAcciones(){
		if(asiento_cerca){
			if (sentado) m.text = m2.text + button;
			else m.text = m1.text + button;
		}
		else if(luz_cerca) 
			m.text = m3.text + button;
	}


}

