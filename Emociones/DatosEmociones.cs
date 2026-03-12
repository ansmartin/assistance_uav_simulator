using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DatosEmociones
{
    enum emociones { neutral, sorpresa, asco, miedo, tristeza, ira, felicidad }

    //{"Angry", "Disgust", "Fear", "Happy", "Sad", "Surprise", "Neutral"}
    public static int[] traductor = new int[7] {5, 2, 3, 6, 4, 1, 0};

    public static int[][] data = new int[7][];

    //public static Dictionary<string, int>[] dic = new Dictionary<string, int>[6];

    static DatosEmociones(){

        data[(int)emociones.felicidad] = new int[50] {
            0,          //Blink_Left 
            0,          //Blink_Right
            0,          //BrowsDown_Left
            0,          //BrowsDown_Right
            0,          //BrowsIn_Left
            0,          //BrowsIn_Right
            0,          //BrowsOuterLower_Left
            0,          //BrowsOuterLower_Right
            60,          //BrowsUp_Left 
            60,          //BrowsUp_Right
            0,          //CheekPuff_Left 
            0,          //CheekPuff_Right
            100,          //EyesWide_Left 
            100,          //EyesWide_Right
            0,          //Frown_Left 
            0,          //Frown_Right
            0,          //JawBackward 
            0,          //JawForeward
            0,          //JawRotateY_Left 
            0,          //JawRotateY_Right
            0,          //JawRotateZ_Left 
            0,          //JawRotateZ_Right
            100,         //Jaw_Down
            0,          //Jaw_Left
            0,          //Jaw_Right
            0,          //Jaw_Up
            0,          //LowerLipDown_Left 
            0,          //LowerLipDown_Right
            0,          //LowerLipIn
            0,          //LowerLipOut
            0,          //Midmouth_Left
            0,          //Midmouth_Right
            0,          //MouthDown
            0,          //MouthNarrow_Left 
            0,          //MouthNarrow_Right
            0,          //MouthOpen
            65,         //MouthUp
            0,          //MouthWhistle_NarrowAdjust_Left 
            0,          //MouthWhistle_NarrowAdjust_Right
            0,          //NoseScrunch_Left 
            0,          //NoseScrunch_Right
            100,        //Smile_Left 
            100,        //Smile_Right
            0,        //Squint_Left 
            0,        //Squint_Right
            0,          //TongueUp
            0,          //UpperLipIn
            0,          //UpperLipOut  
            0,          //UpperLipUp_Left
            0           //UpperLipUp_Right
        };


        data[(int)emociones.sorpresa] = new int[50] {
            0,          //Blink_Left 
            0,          //Blink_Right
            0,          //BrowsDown_Left
            0,          //BrowsDown_Right
            0,          //BrowsIn_Left
            0,          //BrowsIn_Right
            0,          //BrowsOuterLower_Left
            0,          //BrowsOuterLower_Right
            100,          //BrowsUp_Left 
            100,          //BrowsUp_Right
            0,          //CheekPuff_Left 
            0,          //CheekPuff_Right
            300,          //EyesWide_Left 
            300,          //EyesWide_Right
            0,          //Frown_Left 
            0,          //Frown_Right
            0,          //JawBackward 
            0,          //JawForeward
            0,          //JawRotateY_Left 
            0,          //JawRotateY_Right
            100,          //JawRotateZ_Left 
            100,          //JawRotateZ_Right
            0,          //Jaw_Down
            0,          //Jaw_Left
            0,          //Jaw_Right
            0,          //Jaw_Up
            0,          //LowerLipDown_Left 
            0,          //LowerLipDown_Right
            0,          //LowerLipIn
            0,          //LowerLipOut
            0,          //Midmouth_Left
            0,          //Midmouth_Right
            0,          //MouthDown
            0,          //MouthNarrow_Left 
            0,          //MouthNarrow_Right
            50,          //MouthOpen
            0,          //MouthUp
            0,          //MouthWhistle_NarrowAdjust_Left 
            0,          //MouthWhistle_NarrowAdjust_Right
            0,          //NoseScrunch_Left 
            0,          //NoseScrunch_Right
            0,          //Smile_Left 
            0,          //Smile_Right
            0,          //Squint_Left 
            0,          //Squint_Right
            0,          //TongueUp
            0,          //UpperLipIn
            0,          //UpperLipOut  
            0,          //UpperLipUp_Left
            0           //UpperLipUp_Right
        };


        data[(int)emociones.asco] = new int[50] {
            0,          //Blink_Left 
            0,          //Blink_Right
            50,          //BrowsDown_Left
            50,          //BrowsDown_Right
            100,          //BrowsIn_Left
            100,          //BrowsIn_Right
            50,          //BrowsOuterLower_Left
            50,          //BrowsOuterLower_Right
            0,          //BrowsUp_Left 
            40,          //BrowsUp_Right
            0,          //CheekPuff_Left 
            0,          //CheekPuff_Right
            0,          //EyesWide_Left 
            0,          //EyesWide_Right
            0,          //Frown_Left 
            0,          //Frown_Right
            65,          //JawBackward 
            0,          //JawForeward
            0,          //JawRotateY_Left 
            0,          //JawRotateY_Right
            0,          //JawRotateZ_Left 
            0,          //JawRotateZ_Right
            0,          //Jaw_Down
            0,          //Jaw_Left
            0,          //Jaw_Right
            0,          //Jaw_Up
            0,          //LowerLipDown_Left 
            0,          //LowerLipDown_Right
            0,          //LowerLipIn
            0,          //LowerLipOut
            0,          //Midmouth_Left
            0,          //Midmouth_Right
            -30,          //MouthDown
            0,          //MouthNarrow_Left 
            0,          //MouthNarrow_Right
            0,          //MouthOpen
            0,          //MouthUp
            0,          //MouthWhistle_NarrowAdjust_Left 
            0,          //MouthWhistle_NarrowAdjust_Right
            150,          //NoseScrunch_Left 
            150,          //NoseScrunch_Right
            -10,          //Smile_Left 
            -30,          //Smile_Right
            100,          //Squint_Left 
            100,          //Squint_Right
            0,          //TongueUp
            0,          //UpperLipIn
            100,          //UpperLipOut  
            80,          //UpperLipUp_Left
            40           //UpperLipUp_Right
        };


        data[(int)emociones.miedo] = new int[50] {
            0,          //Blink_Left 
            0,          //Blink_Right
            0,          //BrowsDown_Left
            0,          //BrowsDown_Right
            100,          //BrowsIn_Left
            100,          //BrowsIn_Right
            100,          //BrowsOuterLower_Left
            100,          //BrowsOuterLower_Right
            0,          //BrowsUp_Left 
            0,          //BrowsUp_Right
            0,          //CheekPuff_Left 
            0,          //CheekPuff_Right
            250,          //EyesWide_Left 
            250,          //EyesWide_Right
            0,          //Frown_Left 
            0,          //Frown_Right
            0,          //JawBackward 
            0,          //JawForeward
            0,          //JawRotateY_Left 
            0,          //JawRotateY_Right
            0,          //JawRotateZ_Left 
            0,          //JawRotateZ_Right
            0,          //Jaw_Down
            0,          //Jaw_Left
            0,          //Jaw_Right
            0,          //Jaw_Up
            0,          //LowerLipDown_Left 
            0,          //LowerLipDown_Right
            0,          //LowerLipIn
            0,          //LowerLipOut
            0,          //Midmouth_Left
            0,          //Midmouth_Right
            0,          //MouthDown
            -100,          //MouthNarrow_Left 
            -100,          //MouthNarrow_Right
            30,          //MouthOpen
            -80,          //MouthUp
            0,          //MouthWhistle_NarrowAdjust_Left 
            0,          //MouthWhistle_NarrowAdjust_Right
            0,          //NoseScrunch_Left 
            0,          //NoseScrunch_Right
            -30,          //Smile_Left 
            -30,          //Smile_Right
            100,          //Squint_Left 
            100,          //Squint_Right
            0,          //TongueUp
            100,          //UpperLipIn
            100,          //UpperLipOut  
            0,          //UpperLipUp_Left
            0           //UpperLipUp_Right
        };


        data[(int)emociones.tristeza] = new int[50] {
            0,          //Blink_Left 
            0,          //Blink_Right
            100,          //BrowsDown_Left
            100,          //BrowsDown_Right
            100,          //BrowsIn_Left
            100,          //BrowsIn_Right
            200,          //BrowsOuterLower_Left
            200,          //BrowsOuterLower_Right
            0,          //BrowsUp_Left 
            0,          //BrowsUp_Right
            0,          //CheekPuff_Left 
            0,          //CheekPuff_Right
            0,          //EyesWide_Left 
            0,          //EyesWide_Right
            100,          //Frown_Left 
            100,          //Frown_Right
            0,          //JawBackward 
            0,          //JawForeward
            0,          //JawRotateY_Left 
            0,          //JawRotateY_Right
            0,          //JawRotateZ_Left 
            0,          //JawRotateZ_Right
            0,          //Jaw_Down
            0,          //Jaw_Left
            0,          //Jaw_Right
            0,          //Jaw_Up
            0,          //LowerLipDown_Left 
            0,          //LowerLipDown_Right
            0,          //LowerLipIn
            0,          //LowerLipOut
            0,          //Midmouth_Left
            0,          //Midmouth_Right
            0,          //MouthDown
            -50,          //MouthNarrow_Left 
            -50,          //MouthNarrow_Right
            0,          //MouthOpen
            0,          //MouthUp
            0,          //MouthWhistle_NarrowAdjust_Left 
            0,          //MouthWhistle_NarrowAdjust_Right
            0,          //NoseScrunch_Left 
            0,          //NoseScrunch_Right
            -30,          //Smile_Left 
            -30,          //Smile_Right
            100,          //Squint_Left 
            100,          //Squint_Right
            0,          //TongueUp
            0,          //UpperLipIn
            0,          //UpperLipOut  
            0,          //UpperLipUp_Left
            0           //UpperLipUp_Right
        };


        data[(int)emociones.ira] = new int[50] {
            0,          //Blink_Left 
            0,          //Blink_Right
            100,          //BrowsDown_Left
            100,          //BrowsDown_Right
            100,          //BrowsIn_Left
            100,          //BrowsIn_Right
            -100,          //BrowsOuterLower_Left
            -100,          //BrowsOuterLower_Right
            0,          //BrowsUp_Left 
            0,          //BrowsUp_Right
            0,          //CheekPuff_Left 
            0,          //CheekPuff_Right
            0,          //EyesWide_Left 
            0,          //EyesWide_Right
            100,          //Frown_Left 
            100,          //Frown_Right
            0,          //JawBackward 
            0,          //JawForeward
            0,          //JawRotateY_Left 
            0,          //JawRotateY_Right
            0,          //JawRotateZ_Left 
            0,          //JawRotateZ_Right
            0,          //Jaw_Down
            0,          //Jaw_Left
            0,          //Jaw_Right
            0,          //Jaw_Up
            100,          //LowerLipDown_Left 
            100,          //LowerLipDown_Right
            0,          //LowerLipIn
            0,          //LowerLipOut
            0,          //Midmouth_Left
            0,          //Midmouth_Right
            30,          //MouthDown
            -50,          //MouthNarrow_Left 
            -50,          //MouthNarrow_Right
            0,          //MouthOpen
            100,          //MouthUp
            0,          //MouthWhistle_NarrowAdjust_Left 
            0,          //MouthWhistle_NarrowAdjust_Right
            100,          //NoseScrunch_Left 
            100,          //NoseScrunch_Right
            -30,          //Smile_Left 
            -30,          //Smile_Right
            100,          //Squint_Left 
            100,          //Squint_Right
            0,          //TongueUp
            0,          //UpperLipIn
            0,          //UpperLipOut  
            20,          //UpperLipUp_Left
            20           //UpperLipUp_Right
        };


        data[(int)emociones.neutral] = new int[50] {
            0,          //Blink_Left 
            0,          //Blink_Right
            0,          //BrowsDown_Left
            0,          //BrowsDown_Right
            0,          //BrowsIn_Left
            0,          //BrowsIn_Right
            0,          //BrowsOuterLower_Left
            0,          //BrowsOuterLower_Right
            0,          //BrowsUp_Left 
            0,          //BrowsUp_Right
            0,          //CheekPuff_Left 
            0,          //CheekPuff_Right
            0,          //EyesWide_Left 
            0,          //EyesWide_Right
            0,          //Frown_Left 
            0,          //Frown_Right
            0,          //JawBackward 
            0,          //JawForeward
            0,          //JawRotateY_Left 
            0,          //JawRotateY_Right
            0,          //JawRotateZ_Left 
            0,          //JawRotateZ_Right
            0,          //Jaw_Down
            0,          //Jaw_Left
            0,          //Jaw_Right
            0,          //Jaw_Up
            0,          //LowerLipDown_Left 
            0,          //LowerLipDown_Right
            0,          //LowerLipIn
            0,          //LowerLipOut
            0,          //Midmouth_Left
            0,          //Midmouth_Right
            0,          //MouthDown
            0,          //MouthNarrow_Left 
            0,          //MouthNarrow_Right
            0,          //MouthOpen
            0,          //MouthUp
            0,          //MouthWhistle_NarrowAdjust_Left 
            0,          //MouthWhistle_NarrowAdjust_Right
            0,          //NoseScrunch_Left 
            0,          //NoseScrunch_Right
            0,          //Smile_Left 
            0,          //Smile_Right
            0,          //Squint_Left 
            0,          //Squint_Right
            0,          //TongueUp
            0,          //UpperLipIn
            0,          //UpperLipOut  
            0,          //UpperLipUp_Left
            0           //UpperLipUp_Right
        };



        /* 
        // Alegría
        dic[0].Add("Jaw_Down", 75);
        dic[0].Add("MouthUp", 100);
        dic[0].Add("Smile_Left", 150);
        dic[0].Add("Smile_Right", 150);
        dic[0].Add("Squint_Left", 100);
        dic[0].Add("Squint_Right", 100);

        // Sorpresa
        dic[1].Add("BrowsUp_Left", 150);
        dic[1].Add("BrowsUp_Right", 150);
        dic[1].Add("EyesWide_Left", 400);
        dic[1].Add("EyesWide_Right", 400);
        dic[1].Add("JawRotateZ_Left", 100);
        dic[1].Add("JawRotateZ_Right", 100);
        dic[1].Add("MouthOpen", 100);

        // Asco
        dic[2].Add("BrowsDown_Left", 50);
        dic[2].Add("BrowsDown_Right", 50);
        dic[2].Add("BrowsUp_Left", 100);
        dic[2].Add("BrowsUp_Right", 100);
        dic[2].Add("BrowsOuterLower_Left", 50);
        dic[2].Add("BrowsOuterLower_Right", 50);
        dic[2].Add("JawBackward", 80);
        dic[2].Add("NoseScrunch_Left", 100);
        dic[2].Add("NoseScrunch_Right", 100);
        dic[2].Add("Smile_Left", -30);
        dic[2].Add("Smile_Right", -30);
        dic[2].Add("Squint_Left", 100);
        dic[2].Add("Squint_Right", 100);
        dic[2].Add("UpperLipOut", 100);
        dic[2].Add("UpperLipUp_Left", 80);
        dic[2].Add("UpperLipUp_Right", 40);

        // Miedo
        dic[3].Add("BrowsDown_Left", 100);
        dic[3].Add("BrowsDown_Right", 100);
        dic[3].Add("BrowsIn_Left", 100);
        dic[3].Add("BrowsIn_Right", 100);
        dic[3].Add("BrowsOuterLower_Left", 200);
        dic[3].Add("BrowsOuterLower_Right", 200);
        dic[3].Add("EyesWide_Left", 200);
        dic[3].Add("EyesWide_Right", 200);
        dic[3].Add("MouthNarrow_Left", -50);
        dic[3].Add("MouthNarrow_Right", -50);
        dic[3].Add("MouthOpen", 70);
        dic[3].Add("MouthUp", -20);
        dic[3].Add("Smile_Left", -30);
        dic[3].Add("Smile_Right", -30);
        dic[3].Add("Squint_Left", 100);
        dic[3].Add("Squint_Right", 100);
        dic[3].Add("UpperLipIn", 100);
        dic[3].Add("UpperLipOut", 100);

        // Tristeza
        dic[4].Add("BrowsDown_Left", 100);
        dic[4].Add("BrowsDown_Right", 100);
        dic[4].Add("BrowsIn_Left", 100);
        dic[4].Add("BrowsIn_Right", 100);
        dic[4].Add("BrowsOuterLower_Left", 200);
        dic[4].Add("BrowsOuterLower_Right", 200);
        dic[4].Add("Frown_Left", 100);
        dic[4].Add("Frown_Right", 100);
        dic[4].Add("MouthNarrow_Left", -50);
        dic[4].Add("MouthNarrow_Right", -50);
        dic[4].Add("Smile_Left", -30);
        dic[4].Add("Smile_Right", -30);
        dic[4].Add("Squint_Left", 100);
        dic[4].Add("Squint_Right", 100);

        // Ira
        dic[5].Add("BrowsDown_Left", 100);
        dic[5].Add("BrowsDown_Right", 100);
        dic[5].Add("BrowsIn_Left", 100);
        dic[5].Add("BrowsIn_Right", 100);
        dic[5].Add("BrowsOuterLower_Left", -100);
        dic[5].Add("BrowsOuterLower_Right", -100);
        dic[5].Add("Frown_Left", 100);
        dic[5].Add("Frown_Right", 100);
        dic[5].Add("LowerLipDown_Left", 100);
        dic[5].Add("LowerLipDown_Right", 100);
        dic[5].Add("MouthDown", 30);
        dic[5].Add("MouthNarrow_Left", -50);
        dic[5].Add("MouthNarrow_Right", -50);
        dic[5].Add("MouthUp", 100);
        dic[5].Add("NoseScrunch_Left", 100);
        dic[5].Add("NoseScrunch_Right", 100);
        dic[5].Add("Smile_Left", -30);
        dic[5].Add("Smile_Right", -30);
        dic[5].Add("Squint_Left", 100);
        dic[5].Add("Squint_Right", 100);
        dic[5].Add("UpperLipUp_Left", 20);
        dic[5].Add("UpperLipUp_Right", 20); 
        */
    }

}
