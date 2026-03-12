using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayoutScript : MonoBehaviour
{
    [Header("RectTransforms de los paneles")]
    // scripts RectTransform de los paneles a modificar
    public RectTransform rt_principal;
    public RectTransform rt_sec;
    public RectTransform rt_b;


    // clase anidada para tener varios paneles con diferentes valores
    class Panel{
        public float x_min, y_min, x_max, y_max;

        public Panel(float mx, float Mx, float my, float My){
            x_min = mx;
            x_max = Mx;
            y_min = my;
            y_max = My;
        }

        public Vector2 GetMins(){
            return new Vector2(x_min, y_min);
        }

        public Vector2 GetMaxs(){
            return new Vector2(x_max, y_max);
        }
    }


    // posiciones paneles layout 1
    private Panel pr_1 = new Panel(0.02f, 0.63f, 0.09f, 0.94f);     // panel principal
    private Panel s_1 = new Panel(0.68f, 0.98f, 0.09f, 0.94f);     // panel secundario
    private Panel b_1 = new Panel(0.645f, 0.665f, 0.17f, 0.85f);   // panel botones


    // posiciones paneles layout 2
    private Panel pr_2 = new Panel(0.37f, 0.98f, 0.09f, 0.94f);     // panel principal
    private Panel s_2 = new Panel(0.02f, 0.32f, 0.09f, 0.94f);     // panel secundario
    private Panel b_2 = new Panel(0.335f, 0.355f, 0.17f, 0.85f);   // panel botones




    public void CambiarLayout(int option){
        
        switch(option){
            // layout 1
            case 0 :
                MoverPanel(rt_principal, pr_1);
                MoverPanel(rt_sec, s_1);
                MoverPanel(rt_b, b_1);
                break;
            // layout 2
            case 1 :
                MoverPanel(rt_principal, pr_2);
                MoverPanel(rt_sec, s_2);
                MoverPanel(rt_b, b_2);
                break;
        }
        
    }


    void MoverPanel(RectTransform rt, Panel p){
        rt.anchorMin = p.GetMins();
        rt.anchorMax = p.GetMaxs();
    }

   

}
