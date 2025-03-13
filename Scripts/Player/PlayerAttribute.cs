using UnityEngine;

[RequireComponent (typeof(BoxCollider))]
public class PlayerAttribute : AttributeManager
{
    //private AttributeManager attributeManager;
    //public AttributeManager AttributeManager => attributeManager;

    //[SerializeField] protected int hpMax = 100;
    //[SerializeField] protected int mpMax = 100;
    //private void Start()
    //{
    //    attributeManager = new AttributeManager(hpMax, mpMax);
    //}
    [SerializeField] private BoxCollider boxCollider;
    private void Reset()
    {
        this.damage = 1;
        this.LoadCollider();
    }
    protected virtual void LoadCollider()
    {
        if (this.boxCollider != null) return;
        this.boxCollider = transform.GetComponentInChildren<BoxCollider>();
        this.boxCollider.isTrigger = true;
        this.boxCollider.size = new Vector3 (0.5f, 0.7f, 0);
        Debug.Log(transform.name + ": LoadCollider", gameObject);
    }
    private void Start()
    {
        this.hpMax = 100;
        this.mpMax = 100;
        this.Reborn();
        this.damage = 1;
    }
}
