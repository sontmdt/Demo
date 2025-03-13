using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private Button removeButton;
    [SerializeField] public Text itemCountText;
    [SerializeField] private Text itemLevel;

    [SerializeField] private Transform removeCountPanel;
    [SerializeField] private Button increaseButton;
    [SerializeField] private Button decreaseButton;
    [SerializeField] private Button OKButton;
    [SerializeField] private Text count;

    private int removeCount = 0;

    private ItemInventory itemInventory;
    public ItemInventory ItemInventory => itemInventory;
    private void Update()
    {
        switch (transform.name)
        {
            case "InventorySlotOne":
                if (Input.GetKeyDown(KeyCode.Alpha1)) UseItem();
                break;
            case "InventorySlotTwo":
                if (Input.GetKeyDown(KeyCode.Alpha2)) UseItem();
                break;
            case "InventorySlotThree":
                if (Input.GetKeyDown(KeyCode.Alpha3)) UseItem();
                break;
            case "InventorySlotFour":
                if (Input.GetKeyDown(KeyCode.Alpha4)) UseItem();
                break;
            case "InventorySlotFive":
                if (Input.GetKeyDown(KeyCode.Alpha5)) UseItem();
                break;
        }
    }
    private void Awake()
    {
        this.LoadIcon();
        this.LoadButton();
        this.LoadText();
        this.LoadGameObject();
    }
    private void Reset()
    {
        this.LoadIcon();
        this.LoadButton();
        this.LoadText();
        this.LoadGameObject();
    }
    private void LoadIcon()
    {
        if (this.icon != null) return;
        this.icon = transform.Find("ItemButton/Icon").GetComponent<Image>();
        Debug.Log(transform.name + ": LoadIcon", gameObject);
    }
    private void LoadButton()
    {
        if (this.removeButton != null || this.increaseButton != null || this.decreaseButton != null) return;
        this.removeButton = transform.Find("RemoveButton").GetComponent<Button>();
        this.increaseButton = transform.Find("RemoveButton/RemoveCount/IncreaseButton").GetComponent<Button>();
        this.decreaseButton = transform.Find("RemoveButton/RemoveCount/DecreaseButton").GetComponent<Button>();
        this.OKButton = transform.Find("RemoveButton/RemoveCount/OKButton").GetComponent<Button>();
        Debug.Log(transform.name + ": LoadButton", gameObject);
    }
    private void LoadText()
    {
        if (this.itemCountText != null || this.itemLevel != null || this.count) return;
        this.itemCountText = transform.Find("ItemCount/Count").GetComponent<Text>();
        this.itemLevel = transform.Find("ItemLevel").GetComponent<Text>();
        this.count = transform.Find("RemoveButton/RemoveCount/Count").GetComponent<Text>();
        Debug.Log(transform.name + ": LoadText", gameObject);
    }
    private void LoadGameObject()
    {
        if (this.removeCountPanel != null) return;
        this.removeCountPanel = transform.Find("RemoveButton/RemoveCount");
        this.removeCountPanel.gameObject.SetActive(false);
        Debug.Log(transform.name + ": LoadGameObject", gameObject);
    }
    public void AddItem(ItemInventory newItem)
    {
        itemInventory = newItem;
        if (icon == null) return;
        icon.sprite = itemInventory.item.itemIcon;
        icon.enabled = true;
        removeButton.interactable = true;
        itemCountText.enabled = true;
        itemCountText.text = itemInventory.itemCount.ToString();
        itemLevel.enabled = true;
        itemLevel.text = itemInventory.currentLevel.ToString();
    }

    public void ClearSlot()
    {
        itemInventory = null;
        if (icon == null) return;
        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;
        itemCountText.enabled = false;
        itemLevel.enabled = false;
    }

    public void OnRemoveButton()
    {
        //Inventory.Instance.Remove(item);
        this.removeCount = this.itemInventory.itemCount;
        this.count.text = removeCount.ToString();
        this.removeCountPanel.gameObject.SetActive(true);
    }
    public void OnIncreaseButton()
    {
        if (removeCount >= int.Parse(itemCountText.text)) return; 
        this.removeCount++;
        this.count.text = this.removeCount.ToString();
    }
    public void OnDecreaseButton()
    {
        if (removeCount == 0) return;
        this.removeCount--;
        this.count.text = this.removeCount.ToString();
    }
    public void OnOKButton()
    {
        GameCtrl.Instance.PlayerCtrl.Inventory.DeductItem(itemInventory.item.itemCode, removeCount);
        this.removeCountPanel.gameObject.SetActive(false);
    }
    public void DropItem()
    {

    }
    public void UseItem()
    {
        if (itemInventory == null) return;
        if (itemInventory.item.itemType == ItemType.Medicine)
        {
            itemInventory.UseMedicine();
            GameCtrl.Instance.PlayerCtrl.Inventory.DeductItem(itemInventory.item.itemCode, 1);
        }
    }
}
