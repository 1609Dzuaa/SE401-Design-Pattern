using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    #region public but Hide in Inspector
    [HideInInspector] public IdleState PlayerIdle = new();
    [HideInInspector] public WalkState PlayerWalk = new();
    [HideInInspector] public RunState PlayerRun = new();
    [HideInInspector] public JumpState PlayerJump = new();
    [HideInInspector] public FallState PlayerFall = new();
    [HideInInspector] public SitState PlayerSit = new();
    [HideInInspector] public bool isRight, isOnGround;
    [HideInInspector] public float DirX, DirY;
    #endregion

    #region Editor Attribute
    public Transform GroundCheck;
    public BoxCollider2D Collider2D;
    public Animator Anim;
    public Rigidbody2D Rb2D;
    public float MoveSpeed, RunSpeed, JumpForce, GCheckDist;
    public LayerMask GroundLayer;
    #endregion

    #region State Pattern
    BaseState _state;
    #endregion

    #region State Machine
    int state;
    #endregion

    #region State Constant

    const int IDLE_STATE = 0;
    const int WALK_STATE = 1;
    const int RUN_STATE = 2;
    const int JUMP_STATE = 3;
    const int FALL_STATE = 4;
    const int SIT_STATE = 5;

    #endregion

    void Start()
    {
        ChangeState(PlayerIdle);
    }

    public void ChangeState(BaseState state)
    {
        _state?.Exit();
        _state = state;
        _state.Enter(this);
    }

    public void Flip()
    {
        if (isRight && DirX < 0f)
        {
            transform.Rotate(0f, 180f, 0f);
            isRight = !isRight;
        }
        else if (!isRight && DirX > 0f)
        {
            transform.Rotate(0f, 180f, 0f);
            isRight = !isRight;
        }
    }

    void Update()
    {
        ReadInput();
        Flip();
        //_state?.Update();
        UpdateLogic();
        UpdateAnimation();
    }

    private void FixedUpdate()
    {
        CheckGround();
        //UpdatePhysics(); //un-comment khi trình bày cách tiếp cận bthg
    }

    private void ReadInput()
    {
        DirX = Input.GetAxisRaw("Horizontal");
        DirY = Input.GetAxisRaw("Vertical");
    }

    private void CheckGround()
    {
        isOnGround = Physics2D.Raycast(GroundCheck.position, Vector2.down, GCheckDist, GroundLayer);
        //Debug.Log("isG: " + isOnGround);
    }

    #region No State Pattern

    private void UpdateAnimation()
    {
        if (state == SIT_STATE)
            Anim.SetInteger("state", (int)EState.PlayerState.Sit);
        else if (state == JUMP_STATE)
            Anim.SetInteger("state", (int)EState.PlayerState.Jump);
        else if (state == WALK_STATE)
            Anim.SetInteger("state", (int)EState.PlayerState.Walk);
        else if (state == IDLE_STATE)
            Anim.SetInteger("state", (int)EState.PlayerState.Idle);
        else if (state == FALL_STATE)
            Anim.SetInteger("state", (int)EState.PlayerState.Fall);
    }

    private void UpdatePhysics()
    {
        if (state != SIT_STATE && state != IDLE_STATE)
        {
           if (state == JUMP_STATE)
                Rb2D.velocity = new Vector2(DirX * MoveSpeed, JumpForce);
            else
                Rb2D.velocity = new Vector2(DirX * MoveSpeed, Rb2D.velocity.y);
        }
        else
        {
            Rb2D.velocity = Vector2.zero;
        }
    }

    private void UpdateLogic()
    {
        if (Input.GetKey(KeyCode.LeftShift) && isOnGround)
            SwitchState(SIT_STATE);
        else if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
            SwitchState(JUMP_STATE);
        else if (DirX != 0 && isOnGround)
            SwitchState(WALK_STATE);
        else if (!isOnGround && Rb2D.velocity.y < -0.1f)
            SwitchState(FALL_STATE);
        else if (isOnGround && Mathf.Abs(DirX) == 0 && Rb2D.velocity.y <= 0f)
            SwitchState(IDLE_STATE);
        //Debug.Log("state: " + state);
    }

    private void SwitchState(int State)
    {
        state = State;
        if (state == SIT_STATE)
            Collider2D.size = new Vector2(0.875f, 1.15f);
        else
            Collider2D.size = new Vector2(0.875f, 1.6875f);
        UpdatePhysics();
    }

    #endregion
}
