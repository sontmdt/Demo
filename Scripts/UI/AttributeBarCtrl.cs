using UnityEngine;
using System;
public class AttributeBarCtrl : MonoBehaviour
{
    public static event Action onAttributeChangeCallBack;
    public static void UpdateAttributeBar()
    {
        onAttributeChangeCallBack?.Invoke();
    }
}
