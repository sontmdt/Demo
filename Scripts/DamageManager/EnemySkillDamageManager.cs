using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class EnemySkillDamageManager : DamageManager
{
    private float damage = 0;
    private void Start()
    {
        damage = skillCtrl.Skill.damage;
    }
    protected override void LoadCollider()
    {
        if (this.boxCollider != null) return;
        this.boxCollider = transform.GetComponent<BoxCollider>();
        this.boxCollider.isTrigger = true;
        this.boxCollider.center = new Vector3(-0.04f, -0.23f, 0);
        this.boxCollider.size = new Vector3(0.4f, 0.7f, 0);
        Debug.Log(transform.name + ": LoadCollider", gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent.name != "Player") return;
        this.SendDamage(other.gameObject, damage);
    }
}