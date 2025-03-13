using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class WeaponDamageManager : DamageManager
{
    private float damage = 0;
    private void Start()
    {
        damage = GameCtrl.Instance.PlayerCtrl.PlayerAttribute.damage + skillCtrl.Skill.damage;
        //Debug.Log(damage);
    }
    protected override void LoadCollider()
    {
        if (this.boxCollider != null) return;
        this.boxCollider = transform.GetComponent<BoxCollider>();
        this.boxCollider.isTrigger = true;
        this.boxCollider.size = new Vector3(0.7f, 0.1f, 0f);
        Debug.Log(transform.name + ": LoadCollider", gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent.name == "Player") return;
        this.SendDamage(other.gameObject, damage);
        WeaponSpawner.Instance.RemoveWeapon(transform.parent);
    }
}
