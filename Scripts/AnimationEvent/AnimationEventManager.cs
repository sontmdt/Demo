using UnityEngine;
public class AnimationEventManager : MonoBehaviour
{
    [SerializeField] protected SkillCtrl skillCtrl;
    private void Reset()
    {
        this.LoadSkillCtrl();
    }
    private void LoadSkillCtrl()
    {
        if (this.skillCtrl != null) return;
        this.skillCtrl = transform.parent.GetComponent<SkillCtrl>();
        Debug.Log(transform.name + ": LoadSkillCtrl", gameObject);
    }
}
