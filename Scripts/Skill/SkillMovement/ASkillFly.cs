using UnityEngine;

public class ASkillFly : MonoBehaviour
{
    [SerializeField] protected float moveSpeed = 1f;
    [SerializeField] protected Vector3 direction = Vector3.right;
    private void Update()
    {
        transform.parent.Translate(direction * moveSpeed * Time.deltaTime);
    }
    private void Reset()
    {
        ResetValue();
    }
    protected virtual void ResetValue()
    {
        //
    }
}
