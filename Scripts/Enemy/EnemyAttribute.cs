using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class EnemyAttribute : AttributeManager
{
    [SerializeField] private SphereCollider sphereCollider;
    public float score;
    private void Reset()
    {
        this.LoadCollider();
    }
    private void Start()
    {
        this.score = 10;
        this.Reborn();
    }
    private void Update()
    {
        if (this.IsDead())
        {
            GameManager.Instance.score += score;
            this.hp = this.hpMax;
            BasicEnemySpawner.Instance.RemoveEnemy(transform.parent.name, transform.parent);
        }
    }
    protected virtual void LoadCollider()
    {
        if (this.sphereCollider != null) return;
        this.sphereCollider = transform.GetComponentInChildren<SphereCollider>();
        this.sphereCollider.isTrigger = true;
        this.sphereCollider.radius = 0.5f;
        Debug.Log(transform.name + ": LoadCollider", gameObject);
    }

}
