using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkState : BaseState
{
    public override void Enter(PlayerStateManager context)
    {
        base.Enter(context);
        _stateManager.Anim.SetInteger("state", (int)EState.PlayerState.Walk);
        Debug.Log("Walk State");
    }

    public override void Exit()
    {

    }

    public override void Update()
    {
        UpdateVelocity();

        if (CheckStateHelper.CheckIfCanIdle(_stateManager.DirX, _stateManager.isOnGround))
            _stateManager.ChangeState(_stateManager.PlayerIdle);
        else if (CheckStateHelper.CheckIfCanJump())
            _stateManager.ChangeState(_stateManager.PlayerJump);
    }

    private void UpdateVelocity()
    {
        _stateManager.Rb2D.velocity = new Vector2(_stateManager.DirX * _stateManager.MoveSpeed,
            _stateManager.Rb2D.velocity.y);
    }
}
