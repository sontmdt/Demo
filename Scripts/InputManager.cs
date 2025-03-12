using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InputManager : Singleton<InputManager>
{
    [SerializeField] protected Vector3 mouseWorldPos;
    public Vector3 MouseWorldPos => mouseWorldPos;

    [SerializeField] protected float onAttack;
    public float OnAttack => onAttack;
    
    [SerializeField] protected Vector2 movement;
    public Vector2 Movement => movement;

    [SerializeField] protected bool useNormalAttackSkill;
    public bool UseNormalAttackSkill => useNormalAttackSkill;
    [SerializeField] protected bool useBasicSkill;
    public bool UseBasicSkill => useBasicSkill;
    [SerializeField] protected bool useDashSkill;
    public bool UseDashSkill => useDashSkill;
    [SerializeField] protected bool useUltimateSkill;
    public bool UseUltimateSkill => useUltimateSkill;
    protected override void Awake()
    {
        base.Awake();
    }
    private void Update()
    {
        this.GetInputMovement();
        this.GetMouseDown();
        this.GetMousePos();
        this.GetInputKeyboard();
    }
    //private void FixedUpdate()
    //{
        //this.GetMousePos();
    //}
    protected virtual void GetInputMovement()
    {
        this.movement.x = Input.GetAxisRaw("Horizontal");
        this.movement.y = Input.GetAxisRaw("Vertical");
    }
    protected virtual void GetMousePos()
    {
        this.mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    protected virtual void GetMouseDown()
    {
        this.onAttack = Input.GetAxis("Fire1");
        this.useNormalAttackSkill = Input.GetMouseButton(0);
        this.useBasicSkill = Input.GetMouseButtonDown(1);
    }
    protected virtual void GetInputKeyboard()
    {
        useDashSkill = Input.GetKeyDown(KeyCode.Space);
        useUltimateSkill = Input.GetKeyDown(KeyCode.R);
    }
}
