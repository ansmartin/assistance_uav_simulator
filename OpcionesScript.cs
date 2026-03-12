
public static class OpcionesScript
{

    static int escena = 0;
    static int pj = 0;
    static int control = 0;
    static int emocion = 7;
    static int broker_option = 0;
    static string brokerHostname = "Localhost";
    static string[] ip_values = new string[4] { "161","67","100","32" };
    static int idioma = 0;   // 0 -> español, 1 -> english
    static bool postprocess = false;
    static bool debug = true;
    static int t_sim = 15;   // tiempo de simulación
    static int dist_seguridad = 100;  // distancia de seguridad



    public static int _escena{
        get{ return escena; }
        set{ escena = value; }
    }

    public static int _pj{
        get{ return pj; }
        set{ pj = value; }
    }

    public static int _control{
        get{ return control; }
        set{ control = value; }
    }

    public static int _emocion{
        get{ return emocion; }
        set{ emocion = value; }
    }

    public static int _broker_option{
        get{ return broker_option; }
        set{ broker_option = value; }
    }

    public static string _brokerHostname{
        get{ return brokerHostname; }
        set{ brokerHostname = value; }
    }

    public static string[] _ip_values{
        get{ return ip_values; }
        set{ ip_values = value; }
    }

    public static int _idioma{
        get{ return idioma; }
        set{ idioma = value; }
    }

    public static bool _postprocess{
        get{ return postprocess; }
        set{ postprocess = value; }
    }

    public static bool _debug{
        get{ return debug; }
        set{ debug = value; }
    }

    public static int _t_sim{
        get{ return t_sim; }
        set{ t_sim = value; }
    }

    public static int _dist_seguridad{
        get{ return dist_seguridad; }
        set{ dist_seguridad = value; }
    }



}
