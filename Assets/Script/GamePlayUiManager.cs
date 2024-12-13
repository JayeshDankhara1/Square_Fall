using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

public class GamePlayUiManager : MonoBehaviour
{

    public static GamePlayUiManager instance;
    // Start is called before the first frame update

    [Header ("Audio_Clip")]
    public AudioClip BG_clip;
    public AudioClip Obstacl_Clip;
    public AudioClip UnObstcl_Clip;
    public AudioClip Click_Clip;
    [Space]
    [Header("Sprite")]
    
    public Sprite Obstacal_Sprite;
    public Sprite UnObsatacal_Sprite;




    public void Awake()
    {
         instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
