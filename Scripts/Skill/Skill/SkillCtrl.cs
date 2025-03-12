using UnityEngine;

public class SkillCtrl : MonoBehaviour
{
    [SerializeField] protected Skill skill;
    public Skill Skill => skill;

    [SerializeField] protected string attacker;
    public string Attacker => attacker;

    [SerializeField] protected DamageManager damageManager;
    public DamageManager DamageManager => damageManager;

    //[SerializeField] protected Despawn skillDespawn;
    //public Despawn SkillDespawn => skillDespawn;
    protected virtual void Reset()
    {
        this.LoadSkill();
        this.LoadDamageManager();
        //this.LoadSkillDespawn();
    }
    public void LoadSkill()
    {
        Skill[] allSkill = Resources.LoadAll<Skill>("Skills");
        foreach (Skill skillSO in allSkill)
        {  
            if (skillSO.name == transform.name)
            {
                skill = skillSO;
                return;
            }
        }
    }
    private void LoadDamageManager()
    {
        if (this.damageManager != null) return;
        this.damageManager = GetComponentInChildren<DamageManager>();
        Debug.Log(transform.name + ": LoadDamageManager", gameObject);
    }

}
