using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLines : MonoBehaviour
{
    //public Material lineMat;

    public Vector3 mainPoint = new Vector3 (0,0,0);
    public List<Vector3> points;
    public bool init = false;

    //private Shader shader;

    //Material lineMat = new Material("Shader \"Lines/Colored Blended\" {" + "SubShader { Pass { " + "    Blend SrcAlpha OneMinusSrcAlpha " + "    ZWrite Off Cull Off Fog { Mode Off } " + "    BindChannels {" + "      Bind \"vertex\", vertex Bind \"color\", color }" + "} } }");

    // Start is called before the first frame update
    void Start()
    {
        if(OpcionesScript._debug) Destroy(this);

        init = true;

        //shader = Shader.Find("Lines/Colored Blended");
    }

    // Connect all of the `points` to the `mainPoint`
    void DrawConnectingLines()
    {

        Material lineMat = new Material("Shader \"Lines/Colored Blended\" {" + "SubShader { Pass { " + "    Blend SrcAlpha OneMinusSrcAlpha " + "    ZWrite Off Cull Off Fog { Mode Off } " + "    BindChannels {" + "      Bind \"vertex\", vertex Bind \"color\", color }" + "} } }");
        
        //Material lineMat = new Material(shader);


        if (init && points.Count > 0)
        {
            //GL.PushMatrix();
            lineMat.SetPass(0);
            //GL.LoadOrtho();
            // Loop through each point to connect to the mainPoint
            Vector3 previus = mainPoint;
            GL.Begin(GL.LINES);
            foreach (Vector3 point in points)
            {

                
                lineMat.SetPass(0);
                GL.Color(new Color(lineMat.color.r, lineMat.color.g, lineMat.color.b, lineMat.color.a));
                //GL.Color(Color.red);
                GL.Vertex3(previus.x, previus.y, previus.z);
                GL.Vertex3(point.x, point.y, point.z);
               
                previus = point;
            }
            GL.End();
            //GL.PopMatrix();
        }
    }

    // To show the lines in the game window whne it is running
    void OnPostRender()
    {
        DrawConnectingLines();
    }

    // To show the lines in the editor
    void OnDrawGizmos()
    {
        //DrawConnectingLines();
    }

    public void addPoint(Vector3 point)
    {
        //point.y = 1;
        points.Add(point);
    }
}
