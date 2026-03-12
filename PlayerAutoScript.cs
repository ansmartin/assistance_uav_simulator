using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.AI;

public class PlayerAutoScript : MonoBehaviour
{

    private int t_espera = 5;   // tiempo de espera hasta moverse a una nueva posición
	
	private bool asiento_cerca;
	private Vector3 asiento_position;
	private Quaternion asiento_rotation;
	
	private bool luz_cerca;
	private LamparaScript lampara;

	private Animator anim;


    private NavMeshAgent agent;
    private NavMeshPath path;
    public GameObject destinos;


    private bool nuevodestino; //calcular un nuevo destino
    private bool andar; //moverse hacia el nuevo destino
    private bool esperar;

    private int ndestinos; //numero de destinos
    private int destino_anterior = 0;
    private int destino_actual = 0;


    private int walk = Animator.StringToHash(nameof(walk)),
				stop = Animator.StringToHash(nameof(stop)),
				sit = Animator.StringToHash(nameof(sit)),
				up = Animator.StringToHash(nameof(up)),
				press = Animator.StringToHash(nameof(press));

    
    private RotarCabezaScript rts;

	
    void Start ()
    {
        anim = GetComponent<Animator>();
        rts = GetComponent<RotarCabezaScript>();
		
		asiento_cerca = false;
		luz_cerca = false;

        andar = true;
        nuevodestino = true;
        
        agent = GetComponent<NavMeshAgent>();

        ndestinos = destinos.transform.childCount;
        
    }


    void Update()
    {
        ///////////////////////////////////////////////////////
		// Girar la cabeza
		///////////////////////////////////////////////////////
		rts.RotarCabeza();


        if(andar){
            ///////////////////////////////////////////////////////
		    // Calcula un nuevo destino
		    ///////////////////////////////////////////////////////
            if(nuevodestino){
                 
                // no se repite el anterior destino
                while(destino_actual == destino_anterior){
                    destino_actual = Random.Range(0,ndestinos);
                    Debug.Log("nuevo destino desde "+destino_anterior+" a "+destino_actual);
                }
                destino_anterior = destino_actual;
                

                /*
                //modo secuencial
                destino_actual++;
                if(destino_actual==ndestinos) destino_actual =0;
                */

                //path = new NavMeshPath();
                //agent.CalculatePath(destinos.transform.GetChild(destino_actual).transform.position, path);
                //agent.SetPath(path);

                agent.SetDestination(destinos.transform.GetChild(destino_actual).transform.position);

                nuevodestino=false;
                
                //anim.Play("Walk");
                anim.SetBool(walk,true);

            }

            //anim.Play("Walk");

            ///////////////////////////////////////////////////////
		    // Al llegar al destino realiza la opción determinada y se espera un tiempo 
		    ///////////////////////////////////////////////////////
            if(!agent.pathPending)
            {
                if (agent.remainingDistance <= 0.5)
                {
                    //Debug.Log("haspath = "+agent.hasPath.ToString());
                    if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                    {
                        andar = false;
                        StartCoroutine(RealizarAccion());
                    }
                }
            }
        }
        
		
    }
	
	

    void OnTriggerEnter(Collider col){
		
        if (col.gameObject.CompareTag("asiento"))
		{
			
			asiento_cerca = true;
			asiento_position = col.transform.position;
			asiento_rotation = col.transform.rotation;
        }
		
		else if (col.gameObject.CompareTag("lamp"))
		{
			
            luz_cerca = true;
			lampara = col.transform.GetComponent<LamparaScript>();
        }
	}
	
	void OnTriggerExit(Collider col){
		
        if (col.gameObject.CompareTag("asiento"))
		{
			
			asiento_cerca = false;
        }
		
		else if (col.gameObject.CompareTag("lamp"))
		{
			
			luz_cerca = false;
        }
	}
	

    private IEnumerator RealizarAccion(){
        //anim.Play("Idle");
        anim.SetBool(walk,false);
        
        Debug.Log("a esperar");

        if(asiento_cerca){
            ///////////////////////////////////////////////////////
			// Sentarse
			///////////////////////////////////////////////////////
            agent.enabled = false;
            //anim.Play("Sit down");
            anim.SetTrigger(sit);
			transform.position = asiento_position;
			transform.rotation = asiento_rotation;

            yield return new WaitForSeconds(t_espera*2);

            ///////////////////////////////////////////////////////
			// Levantarse
			///////////////////////////////////////////////////////
            //anim.Play("Stand up");
            anim.SetTrigger(up);
            yield return new WaitForSeconds(1);
            agent.enabled = true;

        }
        else if(luz_cerca){
            ///////////////////////////////////////////////////////
			// Encender o apagar luz de la lampara
			///////////////////////////////////////////////////////
            transform.LookAt(new Vector3(lampara.transform.position.x, transform.position.y, lampara.transform.position.z)); 
            //anim.Play("Press");
            anim.SetTrigger(press);
			lampara.EncenderApagar();
            yield return new WaitForSeconds(t_espera/2);
            
        }
        else{
            yield return new WaitForSeconds(t_espera);
            
        }
            

        nuevodestino = true;
        andar = true;

    }


	private IEnumerator Wait(int segundos){
        yield return new WaitForSeconds(segundos);
    }


}
