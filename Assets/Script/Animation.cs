using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Animation : MonoBehaviour
{
    #region varibal
    public bool IsClick = false;
    #endregion

    #region Refarance Script
    public static Animation instance;
    #endregion

    #region Unity Function
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion

    #region Function
    public void Fade(Image image, float End, float Start, float DurationTime)
    {

        image.DOFade(End, DurationTime).From(DurationTime);

    }
  
    public void Scale(Transform transform, float DurationTime, Vector3 End, Vector3 Start, Ease ease = Ease.Unset, UnityAction EndAction = null)
    {
        transform.DOScale(End, DurationTime)
            .From(Start)
            .SetEase(ease)
            .OnComplete(() =>
            {
                EndAction?.Invoke();
            }
            );
    }

    public void ButtonClickAnimation(Transform Button, UnityAction EndAction)
    {
        
        if (IsClick) return;
        Button.DOPunchScale(new Vector3(0.2f, 0.2f, 0.2f), 0.25f, 2)
         .OnStart(() => IsClick = true)
         .OnComplete(() =>
         {
             Button.localScale = Vector3.one;
             IsClick = false;
             EndAction?.Invoke();
         });
    }


    public void PopupAnimation(bool Action, GameObject MainParant_GameObject, Image AlpathBg, Transform MainBg_tranform)
    {
        if (Action) { MainParant_GameObject.SetActive(true); }
        Fade(AlpathBg, Action ? 0.8f : 0, Action ? 0 : 08f, 0.1f);
        Scale(MainBg_tranform, 0.2f, Action ? Vector3.one : Vector3.zero, Action ? Vector3.zero : Vector3.one, Action ? Ease.OutBack : Ease.InBack,
            EndAction: () =>
            {
                if (!Action)
                {
                    MainParant_GameObject.SetActive(false);
                }
            });
    }
}

#endregion