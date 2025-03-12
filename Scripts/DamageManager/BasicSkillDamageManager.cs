using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class BasicSkillDamageManager : DamageManager
{
    private float damage = 0;
    private void Start()
    {
        damage = GameCtrl.Instance.PlayerCtrl.PlayerAttribute.damage + skillCtrl.Skill.damage;
    }
    protected override void LoadCollider()
    {
        if (this.boxCollider != null) return;
        this.boxCollider = transform.GetComponent<BoxCollider>();
        this.boxCollider.isTrigger = true;
        this.boxCollider.center = new Vector3 (0.2f, 0, 0);
        this.boxCollider.size = new Vector3(0.9f, 0.9f, 0);
        Debug.Log(transform.name + ": LoadCollider", gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent.name == "Player") return;
        this.SendDamage(other.gameObject, damage);
    }
}
