using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    protected void Reset()
    {
        if (GameCtrl.Instance.PlayerCtrl == null) Debug.Log("sdsdsd");
    }
    protected void Start()
    {
        if (GameCtrl.Instance.PlayerCtrl == null) Debug.Log("sdsdsd");
    }
}
