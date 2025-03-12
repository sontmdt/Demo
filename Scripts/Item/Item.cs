using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public ItemCode itemCode = ItemCode.NoItem;
    public ItemType itemType = ItemType.NoType;

    public string itemName = "New Item";  
    public Sprite itemIcon = null;          
    public bool isDefaultItem = false;
    public int itemDefaultMaxStack = 99;
    public int attribute = 0;

    public static Item FindByItemCode(ItemCode itemCode)
    {
        var profiles = Resources.LoadAll("Items", typeof(Item));
        foreach (Item profile in profiles)
        {
            if (profile.itemCode != itemCode) continue;
            return profile;
        }
        return null;
    }
}