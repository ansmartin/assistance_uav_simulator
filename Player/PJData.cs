using UnityEngine;

public struct PJData
{
    public double x;
    public double y;
    public double z;
    public double rot;


    public string SaveToJSON()
    {
        // guarda los valores con solo 2 cifras decimales
        x = (int)(x*100)/100.0;
        y = (int)(y*100)/100.0;
        z = (int)(z*100)/100.0;
        rot = (int)(rot*100)/100.0;

        return JsonUtility.ToJson(this);
    }
}
