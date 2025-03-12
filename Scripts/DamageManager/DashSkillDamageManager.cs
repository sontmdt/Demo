using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class DashSkillDamageManager : DamageManager
{
    //public BoxCollider boxCollider;
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
        this.boxCollider.center = new Vector3(0, 0.27f, 0);
        this.boxCollider.size = new Vector3(3f, 1.6f, 0f);
        Debug.Log(transform.name + ": LoadCollider", gameObject);
        this.boxCollider.enabled = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent.name == "Player") return;
        this.SendDamage(other.gameObject, damage);
    }
}
