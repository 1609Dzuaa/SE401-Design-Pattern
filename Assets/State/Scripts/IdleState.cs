using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : BaseState
{
    public override void Enter(PlayerStateManager context)
    {
        base.Enter(context);
        _stateManager.Anim.SetInteger("state", (int)EState.PlayerState.Idle);
        _stateManager.Rb2D.velocity = Vector2.zero;
        Debug.Log("Idle State");
    }

    public override void Exit()
    {
        
    }

    public override void Update()
    {
        if (CheckStateHelper.CheckIfCanWalk(_stateManager.DirX, _stateManager.isOnGround))
            _stateManager.ChangeState(_stateManager.PlayerWalk);
        else if (CheckStateHelper.CheckIfCanJump())
            _stateManager.ChangeState(_stateManager.PlayerJump);
        else if (CheckStateHelper.CheckIfCanSit())
            _stateManager.ChangeState((_stateManager.PlayerSit));
    }
}
