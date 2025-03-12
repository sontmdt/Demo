using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCtrl : MonoBehaviour
{
    [SerializeField] private ItemInventory itemInventory;
    public ItemInventory ItemInventory => itemInventory;
    public virtual void SetItemInventory(ItemInventory itemInventory)
    {
        this.itemInventory = itemInventory.Clone();
    }
}
