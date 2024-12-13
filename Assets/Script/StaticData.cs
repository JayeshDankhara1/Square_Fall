using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticData 
{
    public static float Sound { 
        get
        {
           return PlayerPrefs.GetFloat("Sound", 0.0f);
        }
        set
        {
            PlayerPrefs.SetFloat("Sound", value);
            PlayerPrefs.Save();
        }
    }

    public static float Music {
        get
        {
            return PlayerPrefs.GetFloat("Music", 0.0f);
           
        }
        set
        {
            PlayerPrefs.SetFloat("Music", value);
            PlayerPrefs.Save();
        }
    }

    public static int MuteMusic {
        get
        {
            return PlayerPrefs.GetInt("MuteMusic", 0);
        }
        set
        {
            PlayerPrefs.SetInt("MuteMusic", value);
            PlayerPrefs.Save();

        }
    }

    public static int MuteSound
    {
        get
        {
            return PlayerPrefs.GetInt("MuteSound", 0);
        }
        set
        {
            PlayerPrefs.SetInt("MuteSound", value);
            PlayerPrefs.Save();

        }
    }

    public static int Score
    {
        get
        {
            return PlayerPrefs.GetInt("Score", 0);
        }
        set
        {
            PlayerPrefs.SetInt("Score", value);
            PlayerPrefs.Save();

        }
    }



}
