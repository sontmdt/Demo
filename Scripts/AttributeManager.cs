using UnityEngine;
public class AttributeManager : MonoBehaviour
{
    protected float hp;
    public float HP => hp;
    protected float mp;
    [SerializeField] protected float hpMax;
    [SerializeField] protected float mpMax;
    public float damage;
    public void CauseDamage(float damageAmount)
    {
        hp -= damageAmount;
        if (hp < 0) hp = 0;
        AttributeBarCtrl.UpdateAttributeBar();
    }
    public void HealHP(float healHPAmount)
    {
        hp += healHPAmount;
        if (hp > hpMax) hp = hpMax;
        AttributeBarCtrl.UpdateAttributeBar();
    }
    public float GetHPPercent() { return (float)hp / hpMax; }
    public bool UseMana(float manaAmount)
    {
        if (mp < manaAmount) return false;
        mp -= manaAmount;
        if (mp < 0) mp = 0;
        AttributeBarCtrl.UpdateAttributeBar();
        return true;
    }
    public void HealMP(float healMPAmount)
    {
        mp += healMPAmount;
        if (mp > mpMax) mp = mpMax;
        AttributeBarCtrl.UpdateAttributeBar();
    }
    public float GetMPPercent() { return (float)mp / mpMax; }
    public void Reborn()
    {
        this.hp = this.hpMax;
        this.mp = this.mpMax;
    }
    public bool IsDead()
    {
        if (this.hp <= 0) return true;
        return false;
    }
}
