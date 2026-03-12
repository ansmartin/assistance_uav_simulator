using UnityEngine;

public struct ConfigInicial
{
    public int tsim;   // tiempo de simulación
    public int distseg;  // distancia de seguridad


    public string SaveToJSON()
    {
        return JsonUtility.ToJson(this);
    }

}
