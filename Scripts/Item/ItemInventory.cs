using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ItemInventory
{
    public Item item;
    public int itemCount;
    public int maxStack = 99;
    public int currentLevel = 0;
    public virtual ItemInventory Clone()
    {
        ItemInventory item = new ItemInventory
        {
            item = this.item,
            itemCount = this.itemCount,
            currentLevel = this.currentLevel,
            maxStack = this.item.itemDefaultMaxStack,
        };
        return item;
    }
    public virtual void UseItemFromInventory()
    {
        Debug.Log("Using " + item.itemName);
    }
    public virtual void UseMedicine()
    {
        if (item.itemCode == ItemCode.HpBottle) GameCtrl.Instance.PlayerCtrl.PlayerAttribute.HealHP(this.item.attribute);
        if (item.itemCode == ItemCode.MpBottle) GameCtrl.Instance.PlayerCtrl.PlayerAttribute.HealMP(this.item.attribute);
    }

    public void RemoveFromInventory()
    {
        GameCtrl.Instance.PlayerCtrl.Inventory.Remove(this);
    }

}
