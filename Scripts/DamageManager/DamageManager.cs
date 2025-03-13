using UnityEngine;
public class DamageManager : MonoBehaviour
{
    [SerializeField] protected SkillCtrl skillCtrl;
    [SerializeField] protected BoxCollider boxCollider;
    public BoxCollider BoxCollider => boxCollider;
    protected virtual void Reset()
    {
        this.LoadSkillCtrl();
        this.LoadCollider();
    }
    private void LoadSkillCtrl()
    {
        if (this.skillCtrl != null) return;
        this.skillCtrl = transform.parent.GetComponent<SkillCtrl>();
        Debug.Log(transform.name + ": LoadSkillCtrl", gameObject);
    }
    protected virtual void LoadCollider()
    {
        //
    }
    protected void SendDamage(GameObject obj, float damage)
    {
        //EnemyAttribute enemyAttribute = obj.transform.GetComponent<EnemyAttribute>();
        AttributeManager attributeManager = obj.transform.GetComponent<AttributeManager>();
        //if (enemyAttribute == null) return;
        //enemyAttribute.CauseDamage(damage);
        if (attributeManager == null) return;
        attributeManager.CauseDamage(damage);
    }
}
