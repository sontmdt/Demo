using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerCtrl : MonoBehaviour
{
    [SerializeField] private Animator animator;
    public Animator Animator => animator;

    [SerializeField] private Rigidbody _rigidbody;
    public Rigidbody _Rigidbody => _rigidbody;

    //[SerializeField] private SphereCollider sphereCollider;

    [SerializeField] private PlayerMovement playerMovement;
    public PlayerMovement PlayerMovement => playerMovement;

    [SerializeField] private PlayerAttribute playerAttribute;
    public PlayerAttribute PlayerAttribute => playerAttribute;

    [SerializeField] private PlayerSkill playerSkill;
    public PlayerSkill PlayerSkill => playerSkill;

    [SerializeField] private Inventory inventory;
    public Inventory Inventory => inventory;
    private void Awake()
    {
        //base.Awake();
        this.LoadAnimator();
        this.LoadRigidbody();
        this.LoadPlayerMovement();
        this.LoadPlayerAttribute();
        this.LoadPlayerSkill();
        //DontDestroyOnLoad(this);
    }

    private void Reset()
    {
        this.LoadAnimator();
        this.LoadRigidbody();
        this.LoadPlayerMovement();
        this.LoadPlayerAttribute();
        this.LoadPlayerSkill();
        this.LoadInventory();
    }
    private void LoadRigidbody()
    {
        if (this._rigidbody != null) return;
        this._rigidbody = transform.GetComponent<Rigidbody>();
        this._rigidbody.useGravity = false;
        this._rigidbody.constraints = RigidbodyConstraints.FreezeRotationZ;
        Debug.Log(transform.name + ": LoadRigidbody", gameObject);
    }
    private void LoadAnimator()
    {
        if (this.animator != null) return;
        this.animator = transform.GetComponentInChildren<Animator>();
        Debug.Log(transform.name + ": LoadAnimator", gameObject);
    }
    private void LoadPlayerMovement()
    {
        if (this.playerMovement != null) return;
        this.playerMovement = transform.GetComponentInChildren<PlayerMovement>();
        Debug.Log(transform.name + ": LoadPlayerMovement", gameObject);
    }
    private void LoadPlayerAttribute()
    {
        if (this.playerAttribute != null) return;
        this.playerAttribute = transform.GetComponentInChildren<PlayerAttribute>();
        Debug.Log(transform.name + ": LoadPlayerAttribute", gameObject);
    }
    private void LoadPlayerSkill()
    {
        if (this.playerSkill != null) return;
        this.playerSkill = transform.GetComponentInChildren<PlayerSkill>();
        Debug.Log(transform.name + ": LoadPlayerSkill", gameObject);
    }
    private void LoadInventory()
    {
        if (this.inventory != null) return;
        this.inventory = transform.GetComponentInChildren<Inventory>();
        Debug.Log(transform.name + " LoadInventory", gameObject);
    }
}
