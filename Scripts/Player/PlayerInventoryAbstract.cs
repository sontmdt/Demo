using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventoryAbstract : MonoBehaviour
{
    [SerializeField] protected Inventory inventory;

    private void Reset()
    {
        LoadInventory();
    }

    protected virtual void LoadInventory()
    {
        if (this.inventory != null) return;
        this.inventory = transform.parent.GetComponent<Inventory>();
        Debug.LogWarning(transform.name + " LoadInventory", gameObject);
    }
}
