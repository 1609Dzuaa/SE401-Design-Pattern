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
    BaseState _state;

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
        _state?.Update();
    }

    private void FixedUpdate()
    {
        CheckGround();
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
}
