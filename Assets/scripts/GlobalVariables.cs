using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalVariables
{
    private static int kills;
    private static double startCountTime;
    private static bool FPSflag = true;

    public static int Kills
        {
            get
            {
                return kills;
            }
            set
            {
                kills = value;
            }
        }

    public static double StartCountTime
    {
        get
        {
            return startCountTime;
        }
        set
        {
            startCountTime = value;
        }
    }



    public static bool FPSFlag
        {
            get
            {
                return FPSflag;
            }
            set
            {
                FPSflag = value;
            }
        }
}


