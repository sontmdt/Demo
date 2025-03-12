using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbstract : MonoBehaviour
{
    [SerializeField] private PlayerCtrl playerCtrl;
    public PlayerCtrl PlayerCtrl => playerCtrl;

    private void Reset()
    {
        this.LoadPlayerCtrl();
    }
    private void LoadPlayerCtrl()
    {
        if (playerCtrl != null) return;
        this.playerCtrl = transform.parent.GetComponent<PlayerCtrl>();
        Debug.Log(transform.name + ": LoadPlayerCtrl", gameObject);
    }
}
