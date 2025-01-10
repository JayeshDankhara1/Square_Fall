
using UnityEngine;

public class PrefabsObject : MonoBehaviour
{
    #region varibal
    public bool isActive = false;
    public bool IsFocediraction = false;
    public SpriteRenderer ObstaclSpriteRender;
    #endregion

    #region Refrance Script
    public GameObject Child;
    public Rigidbody2D Child_Rigidbody;
    public GamePlay Ref_GamePlay;
    #endregion
     
    #region Unity Function
    public void Start()
    {
        Ref_GamePlay = GamePlay.instance;
        IsFocediraction = Random.Range(-5,5)<0 ? true : false;
    }

    public void FixedUpdate()
    {
        if (!isActive) return;

         MoveObstacal();
    }
    #endregion

    #region Function
    public void Active()

    {
        transform.position= new Vector3(Random.Range(-1.80f,1.80f),6,0);
        Child.transform.localPosition = new Vector3(0,0,0);
        Child.tag = Random.Range(-5, 5) < 0 ? "Obstacl" : "Unobstacl";
        ObstaclSpriteRender.sprite = Child.CompareTag("Obstacl") ? Ref_GamePlay.Ref_GamePlayUiManager.Obstacal_Sprite : Ref_GamePlay. Ref_GamePlayUiManager.UnObsatacal_Sprite;
        Child.SetActive(true);
        isActive = true;

    }

    public void Deactive()
    {
        isActive = false;
        Child.SetActive(false);
    }

    public void MoveObstacal()
    {

        if (IsFocediraction)
        { Child_Rigidbody.AddForce(new Vector2(0.5f, 0)); }
        else
        { Child_Rigidbody.AddForce(new Vector2(-0.5f, 0)); }

    }
    #endregion
}
