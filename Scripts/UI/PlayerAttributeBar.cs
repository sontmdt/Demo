using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttributeBar : MonoBehaviour
{
    [SerializeField] private PlayerAttribute playerAttribute;
    [SerializeField] private Transform bar;
    private void Reset()
    {
        this.LoadPlayerAttribute();
        this.LoadBar();
    }
    private void LoadPlayerAttribute()
    {
        if (this.playerAttribute != null) return;
        this.playerAttribute = transform.parent.GetComponent<PlayerAttribute>();
        Debug.Log(transform.name + ": LoadPlayerAttribute", gameObject);
    }
    private void LoadBar()
    {
        if (this.bar != null) return;
        this.bar = transform.Find("Bar");
        Debug.Log(transform.name + ": LoadBar", gameObject);
    }
    private void Start()
    {
        SetUpAttributeBar();
    }
    private void SetUpAttributeBar()
    {
        AttributeBarCtrl.onAttributeChangeCallBack += UpdateAttributeBar;
    }
    private void UpdateAttributeBar()
    {
        if (playerAttribute == null) return;
        if (transform.name == "HPBar") bar.localScale = new Vector3(playerAttribute.GetHPPercent(), 1);
        if (transform.name == "MPBar") bar.localScale = new Vector3(playerAttribute.GetMPPercent(), 1);

    }
}
