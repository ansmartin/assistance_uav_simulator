using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmocionesCaraScript : MonoBehaviour
{

    private SkinnedMeshRenderer smr;
    private Mesh m;

    int i;
    private int segundos = 10; // segundos que pasarán para que se cambie la cara

    private int emocion_actual = 0, emocion_anterior = 0;

    float valor; // valor de un blendshape de la cara actual
    int ncorrectos; // numero de valores correctos mientras la cara transiciona de emocion
    bool cambio=false; // si se está en proceso de transición de emoción o no

    IEnumerator autoemocion;


    public CambiarEmocionPanelScript cambiarEmocionPanel;


    //Dictionary<string, int>[] dic = new Dictionary<string, int>[6];

    void Awake(){
        cambiarEmocionPanel.emocionesCaraScript = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        smr = GetComponent<SkinnedMeshRenderer>();
        m = smr.sharedMesh;

        autoemocion = CambiarEmocion();

        InitCara();
    }

    //Update is called once per frame
    void Update()
    {
        if(cambio) TransicionCara();
    }


    public void InitCara(){
        int emocion = OpcionesScript._emocion;

        StopCoroutine(autoemocion);

        if(emocion == 7) {
            emocion_anterior = emocion_actual;
            StartCoroutine(autoemocion);
        }
        else {
            //CambiarValoresCara(emocion);
            emocion_actual = emocion;
            cambio = true;
        }
    }


    void CambiarValoresCara(int emocion){
        for (int i = 0; i < m.blendShapeCount; i++)
        {
            smr.SetBlendShapeWeight(i, DatosEmociones.data[emocion][i]);
        }
    }


    /// <summary>
    /// Restablece todos los valores blendshape a 0
    /// </summary>
    void ResetCara(){
        for (int i = 0; i < m.blendShapeCount; i++)
        {
            smr.SetBlendShapeWeight(i, 0);
        }
    }


    private IEnumerator CambiarEmocion(){
        
        for(;;){
            // no se repite la misma emoción para la cara
            while(emocion_actual == emocion_anterior){
                emocion_actual = Random.Range(0,7);
            }

            //CambiarValoresCara(emocion_actual);
            
            emocion_anterior = emocion_actual;

            cambio=true;
            
            yield return new WaitForSeconds(segundos);
        }
    }


    void TransicionCara(){
        ncorrectos=0;

        for (i = 0; i < m.blendShapeCount; i++)
        {   
            // valor de un blendshape de la cara actual
            valor = smr.GetBlendShapeWeight(i);

            // si el valor es igual aumenta el número de correctos
            if(valor == DatosEmociones.data[emocion_actual][i]){
                ncorrectos++;
            }
            else // si el valor es menor, aumenta en 1
            if(valor < DatosEmociones.data[emocion_actual][i]){
                valor++;
                smr.SetBlendShapeWeight(i, valor);
            }
            else{ // si el valor es mayor, disminuye en 1
                valor--;
                smr.SetBlendShapeWeight(i, valor);
            }
            
        }

        // termina el cambio de cara cuando todos los valores estén correctos
        if(ncorrectos == m.blendShapeCount) cambio=false;
    }


}
