using UnityEngine;
using System;
public class SkillBarCtrl : MonoBehaviour
{
    public static event Action onSkillChangeCallBack;
    public static void UpdateSkillBar()
    {
        onSkillChangeCallBack?.Invoke();
    }
}
