using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : BaseState
{
    public override void Enter(PlayerStateManager context)
    {
        base.Enter(context);
        _stateManager.Anim.SetInteger("state", (int)EState.PlayerState.Jump);
        _stateManager.Rb2D.velocity = new Vector2(0f, _stateManager.JumpForce);
        Debug.Log("Jump State");
    }

    public override void Exit()
    {
    }

    public override void Update()
    {
        UpdateVelocity();

        if (CheckStateHelper.CheckIfCanFall(_stateManager.Rb2D.velocity.y, _stateManager.isOnGround))
            _stateManager.ChangeState(_stateManager.PlayerFall);
    }

    private void UpdateVelocity()
    {
        _stateManager.Rb2D.velocity = new Vector2(_stateManager.DirX * _stateManager.MoveSpeed,
            _stateManager.Rb2D.velocity.y);
    }
}
