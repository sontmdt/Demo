using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttributeBar : MonoBehaviour
{
    [SerializeField] private EnemyAttribute enemyAttribute;
    [SerializeField] private Transform bar;
    private void Reset()
    {
        this.LoadEnemyAttribute();
        this.LoadBar();
    }
    private void LoadEnemyAttribute()
    {
        if (this.enemyAttribute != null) return;
        this.enemyAttribute = transform.parent.GetComponent<EnemyAttribute>();
        Debug.Log(transform.name + ": LoadEnemyAttribute", gameObject);
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
        if (enemyAttribute == null) return;
        if (transform.name == "HPBar") bar.localScale = new Vector3(enemyAttribute.GetHPPercent(), 1);
        //if (transform.name == "MPBar") bar.localScale = new Vector3(enemyAttribute.AttributeManager.GetMPPercent(), 1);

    }
}
