using UnityEngine;

public class SkillSlot : MonoBehaviour
{
    [SerializeField] private Transform skillIcon;
    [SerializeField] private Transform coolDownIcon;
    private PlayerSkill playerSkill;
    private float coolDownCurrent;
    private void Reset()
    {
        this.LoadIcon();
    }
    private void Start()
    {
        coolDownIcon.gameObject.SetActive(true);
        playerSkill = GameCtrl.Instance.PlayerCtrl.PlayerSkill;
        coolDownIcon.localScale = new Vector3(1, 0);
        SetUpSkillBar();
    }
    private void Update()
    {
        SkillBarCtrl.UpdateSkillBar();
    }
    private void LoadIcon()
    {
        if (this.skillIcon != null || this.coolDownIcon != null) return;
        this.skillIcon = transform.Find("SkillIcon");
        this.coolDownIcon = transform.Find("CoolDownIcon");
        Debug.Log(transform.name + ": LoadIcon", gameObject);
    }
    public void UseSkill()
    {
        coolDownIcon.gameObject.SetActive(true);
    }
    private void SetUpSkillBar()
    {
        SkillBarCtrl.onSkillChangeCallBack += UpdateSkillBar;
    }
    private void UpdateSkillBar()
    {
        if (coolDownIcon == null) return;//
        if (coolDownIcon.localScale.y < 0) return;
        ISkill skill = null;

        switch (transform.name)
        {
            case "SkillSlotOne":
                skill = playerSkill.NormalAttackSkill;
                break;
            case "SkillSlotTwo":
                skill = playerSkill.BasicSkill;
                break;
            case "SkillSlotThree":
                skill = playerSkill.DashSkill;
                break;
            case "SkillSlotFour":
                skill = playerSkill.UltimateSkill;
                break;
        }
        float cooldownProgress;
        if (skill != null && skill.lastUsedTime >= 0)
        {
            cooldownProgress = Mathf.Clamp((Time.time - skill.lastUsedTime) / skill.coolDown, 0f, 1f);
            if (cooldownProgress == coolDownCurrent) return;
            coolDownCurrent = cooldownProgress;
            coolDownIcon.localScale = new Vector3(1, 1 - cooldownProgress);
        }
    }

}
