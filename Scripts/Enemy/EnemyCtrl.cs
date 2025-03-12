using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EnemyCtrl : MonoBehaviour
{
    [SerializeField] private EnemyAttribute enemyAttribute;
    public EnemyAttribute EnemyAttribute => enemyAttribute;

    [SerializeField] private Rigidbody _rigidbody;
    public Rigidbody _Rigidbody => _rigidbody;

    [SerializeField] private SphereCollider sphereCollider;

    [SerializeField] private Enemy enemy;
    public Enemy Enemy => enemy;

    [SerializeField] private EnemySkill enemySkill;
    public EnemySkill EnemySkill => enemySkill;
    private void Reset()
    {
        this.LoadRigidbody();
        this.LoadCollider();
        this.LoadEnemyAttribute();
        this.LoadEnemy();
        this.LoadEnemySkill();
    }
    private void LoadRigidbody()
    {
        if (this._rigidbody != null) return;
        this._rigidbody = transform.GetComponent<Rigidbody>();
        this._rigidbody.useGravity = false;
        this._Rigidbody.isKinematic = true;
        this._rigidbody.constraints = RigidbodyConstraints.FreezeRotationZ;
        Debug.Log(transform.name + ": LoadRigidbody", gameObject);
    }
    private void LoadCollider()
    {
        if (this.sphereCollider != null) return;
        this.sphereCollider = transform.GetComponentInChildren<SphereCollider>();
        this.sphereCollider.isTrigger = true;
        this.sphereCollider.radius = 0.7f;
        Debug.Log(transform.name + ": LoadCollider", gameObject);
    }
    private void LoadEnemyAttribute()
    {
        if (this.enemyAttribute != null) return;
        this.enemyAttribute = transform.GetComponentInChildren<EnemyAttribute>();
        Debug.Log(transform.name + ": LoadEnemyAttribute", gameObject);
    }
    private void LoadEnemy()
    {
        if (this.enemy != null) return;
        this.enemy = transform.GetComponent<Enemy>();
        Debug.Log(transform.name + ": LoadEnemy", gameObject);
    }
    private void LoadEnemySkill()
    {
        if (this.enemySkill != null) return;
        this.enemySkill = transform.GetComponentInChildren<EnemySkill>();
        Debug.Log(transform.name + ": LoadEnemySkill", gameObject);
    }
}
