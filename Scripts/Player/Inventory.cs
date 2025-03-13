using System.Collections.Generic;
using UnityEngine;
using System;
//Note
//
public class Inventory : MonoBehaviour
{
    [SerializeField] protected int maxSlot = 5;
    [SerializeField] protected List<ItemInventory> items;
    public List<ItemInventory> Items => items;
    public static event Action onItemChangedCallback;

    public virtual int AddItem(ItemCode itemCode, int addCount)
    {
        Item item = Item.FindByItemCode(itemCode);
        if (item.isDefaultItem) return 0;
        ItemInventory itemExist;
        int newCount;
        int itemMaxStack;
        int addMore;
        int addRemain = addCount;
        int addedTotal = 0;
        for (int i = 0; i < this.maxSlot; i++)
        {
            itemExist = this.GetItemNotFullStack(itemCode);
            if (itemExist == null)
            {
                if (this.IsInventoryFull()) return addedTotal;
                itemExist = this.CreateEmptyItem(item);
                this.items.Add(itemExist);
            }
            newCount = itemExist.itemCount + addRemain;
            itemMaxStack = itemExist.maxStack;
            if (newCount > itemMaxStack)
            {
                newCount = itemMaxStack;
                addMore = itemMaxStack - itemExist.itemCount;
                addRemain -= addMore;
                addedTotal += addMore;
            }
            else
            {
                addedTotal += addRemain;
                addRemain = 0;
            }
            itemExist.itemCount = newCount;
            onItemChangedCallback?.Invoke();
            if (addRemain == 0) break;
        }
        return addedTotal;
    }
    protected virtual ItemInventory GetItemNotFullStack(ItemCode itemCode)
    {
        foreach (ItemInventory item in this.items)
        {
            if (item.item.itemCode != itemCode) continue;
            if (IsFullStack(item)) continue;
            return item;
        }
        return null;
    }
    protected virtual bool IsInventoryFull()
    {
        return items.Count >= this.maxSlot;
    }
    protected virtual ItemInventory CreateEmptyItem(Item item)
    {
        ItemInventory itemInventory = new ItemInventory
        {
            item = item,
            maxStack = item.itemDefaultMaxStack,
        };
        return itemInventory;
    }
    protected virtual bool IsFullStack(ItemInventory itemInventory)
    {
        if (itemInventory == null) return true;
        return itemInventory.itemCount >= itemInventory.maxStack;
    }


    //
    public void Remove(ItemInventory item)
    {
        this.items.Remove(item);
        onItemChangedCallback?.Invoke();
    }
    public bool DeductItem(ItemCode itemCode, int deductCount)
    {
        ItemInventory itemInventory;
        int deduct;
        for (int i = this.Items.Count - 1; i >= 0; i--)
        {
            itemInventory = this.Items[i];
            if (itemInventory.item.itemCode != itemCode) continue;
            if (deductCount > itemInventory.itemCount)
            {
                deduct = itemInventory.itemCount;
                deductCount -= itemInventory.itemCount;
            }
            else
            {
                deduct = deductCount;
                deductCount = 0;
            }
            itemInventory.itemCount -= deduct;
            onItemChangedCallback?.Invoke();
        }
        this.ClearEmptySlot();
        return true;
    }
    protected virtual void ClearEmptySlot()
    {
        ItemInventory itemInventory;
        for (int i = 0; i < this.items.Count; i++)
        {
            itemInventory = this.items[i];
            if (itemInventory.itemCount == 0) this.items.RemoveAt(i);
            onItemChangedCallback?.Invoke();
        }
    }
}