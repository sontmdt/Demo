using UnityEngine;

public class SkillUI : MonoBehaviour
{
    [SerializeField] protected GameObject skillUI;
    [SerializeField] protected Transform skillsParent;
    private void Reset()
    {
        this.LoadSkillUI();
        this.LoadSkillsParent();
    }
    private void LoadSkillUI()
    {
        if (this.skillUI != null) return;
        this.skillUI = GameObject.Find("SkillUI");
        Debug.Log(transform.name + ": LoadSkillUI", gameObject);
    }
    private void LoadSkillsParent()
    {
        if (this.skillsParent != null) return;
        this.skillsParent = transform.Find("SkillUI/SkillsParent");
        Debug.Log(transform.name + ": LoadSkillsParent", gameObject);
    }
}
