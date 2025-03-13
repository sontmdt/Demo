using UnityEngine;
[RequireComponent(typeof(SphereCollider))]
public class ItemPickup : MonoBehaviour
{
    [SerializeField] private ItemCtrl itemCtrl;
    [SerializeField] private SphereCollider sphereCollider;
    private void Reset()
    {
        this.LoadItemCtrl();
        this.LoadCollider();
    }
    private void Awake()
    {
        this.LoadItemCtrl();
        this.LoadCollider();
    }
    private void LoadItemCtrl()
    {
        if (this.itemCtrl != null) return;
        this.itemCtrl = transform.parent.GetComponent<ItemCtrl>();
        Debug.Log(transform.name + ": LoadItemCtrl", gameObject);
    }
    protected virtual void LoadCollider()
    {
        if (this.sphereCollider != null) return;
        this.sphereCollider = transform.GetComponentInChildren<SphereCollider>();
        this.sphereCollider.isTrigger = true;
        this.sphereCollider.radius = 0.15f;
        Debug.Log(transform.name + ": LoadCollider", gameObject);
    }
    protected virtual void OnTriggerEnter(Collider other)
    {
         if (other.transform.parent.name != "Player") return;
        int amountToPickUp = itemCtrl.ItemInventory.itemCount;
        int addedAmount = GameCtrl.Instance.PlayerCtrl.Inventory.AddItem(itemCtrl.ItemInventory.item.itemCode, itemCtrl.ItemInventory.itemCount);
        if (addedAmount >= amountToPickUp)
        {
            Destroy(transform.parent.gameObject);
        }
        else
        {
            itemCtrl.ItemInventory.itemCount -= addedAmount;
        }
    }
}
