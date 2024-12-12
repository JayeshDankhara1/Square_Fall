using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

public class ButtonAnimation : MonoBehaviour
{

  public void ButtonClick_Animation()
    {
      AnimationManager.PunchScale(transform, Vector3.one * 01.5f);
    }
}
