using UnityEngine;

[RequireComponent (typeof(SphereCollider))]
public class PlayerPickUp : MonoBehaviour 
{
    [SerializeField] private SphereCollider sphereCollider;
    private void Reset()
    {
        this.LoadCollider();
    }
    protected virtual void LoadCollider()
    {
        if (this.sphereCollider != null) return;
        this.sphereCollider = transform.GetComponentInChildren<SphereCollider>();
        this.sphereCollider.isTrigger = true;
        this.sphereCollider.radius = 0.5f;
        Debug.Log(transform.name + ": LoadCollider", gameObject);
    }
}
