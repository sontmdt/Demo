using UnityEngine;
public class PlayerMovement : PlayerAbstract
{
    [SerializeField] public float moveSpeed = 5f;
    [SerializeField] protected Vector3 targetPosition;
    [SerializeField] protected Vector2 movement;

    [SerializeField] private float stepDelay = 0.3f;
    private float stepTimer = 0f;
    protected void Update()
    {
        this.GetInput();
        this.MovementAnimation();
    }
    protected void FixedUpdate()
    {
        //this.GetTargetPosition();
        //this.LookAtTarget();
        this.Movement();
    }
    protected virtual void GetInput()
    {
        this.movement = InputManager.Instance.Movement;
    }
    protected virtual void MovementAnimation()
    {
        PlayerCtrl.Animator.SetFloat("Horizontal", this.movement.x);
        PlayerCtrl.Animator.SetFloat("Vertical", this.movement.y);
        PlayerCtrl.Animator.SetFloat("Speed", this.movement.sqrMagnitude);
    }
    protected virtual void Movement()
    {
        Vector2 movePos = PlayerCtrl._Rigidbody.position;
        PlayerCtrl._Rigidbody.MovePosition(movePos + movement * moveSpeed * Time.fixedDeltaTime);
        if (movement == Vector2.zero) return;
        stepTimer += Time.fixedDeltaTime;
        if (stepTimer >= stepDelay)
        {
            AudioManager.Instance.SoundAudio.PlayOneShot(AudioManager.Instance.moveSound);
            stepTimer = 0f;
        }
    }
    protected virtual void LookAtTarget()
    {
        Vector2 direction = (this.targetPosition - transform.parent.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.parent.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
    protected virtual void GetTargetPosition()
    {
        this.targetPosition = InputManager.Instance.MouseWorldPos;
        this.targetPosition.z = 0;
    }
}
