using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class ButtonAnimation: MonoBehaviour
{
    // Start is called before the first frame update

     Animation Ref_Animation ;


    public void Start()
    {
        Ref_Animation = Animation.instance;
    }

    public void ButtonClickAnimation(Transform Button,UnityAction EndAction)
    {
       // Debug.Log("Animation Start");
        if(Ref_Animation.IsClick) return;
       // Debug.Log("Animation Condtion Ok");
        Button.DOPunchScale(new Vector3(0.2f,0.2f,0.2f), 0.25f,2)
         .OnStart(()=> Ref_Animation.IsClick=true)
         .OnComplete(()=> {
             Button.localScale = Vector3.one;
             Ref_Animation.IsClick = false;
             EndAction?.Invoke();
         });
       
    }
}
