using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.U2D.IK;

public class PlayScreenButtonManager : MonoBehaviour
{
    
    public void ButtonManager(string BtnName)
    {


        switch (BtnName)
        {
            case "Play":
                SceneManager.LoadScene(1);
                break;
        }
    }
}
