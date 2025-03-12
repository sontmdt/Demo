using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] protected GameObject inventoryUI;
    [SerializeField] protected Transform itemsParent;
    [SerializeField] private InventorySlot[] slots;

    private void Reset()
    {
        this.LoadItemsParent();
        this.LoadInventoryUI();
        this.LoadSlots();
    }
    private void LoadInventoryUI()
    {
        if (this.inventoryUI != null) return;
        this.inventoryUI = GameObject.Find("InventoryUI");
        Debug.Log(transform.name + ": LoadInventoryUI", gameObject);
    }
    private void LoadItemsParent()
    {
        if (this.itemsParent != null) return;
        this.itemsParent = transform.Find("InventoryUI/ItemsParent");
        Debug.Log(transform.name + ": LoadItemsParent", gameObject);
    }
    private void LoadSlots()
    {
        if (this.slots.Length > 0) return;
        this.slots = itemsParent.GetComponentsInChildren<InventorySlot>();
        Debug.Log(transform.name + ": LoadSlots", gameObject);
    }

    private void Start()
    {
        this.SetUpInventoryUI();
    }
    private void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }
    }
    private void SetUpInventoryUI()
    {
        inventoryUI.SetActive(false);
        Inventory.onItemChangedCallback += UpdateUI;
        //slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }
    private void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < GameCtrl.Instance.PlayerCtrl.Inventory.Items.Count)
            {
                slots[i].AddItem(GameCtrl.Instance.PlayerCtrl.Inventory.Items[i]);
                continue;
            }
            slots[i].ClearSlot();
        }
    }
}
