using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallState : BaseState
{
    public override void Enter(PlayerStateManager context)
    {
        base.Enter(context);
        _stateManager.Anim.SetInteger("state", (int)EState.PlayerState.Fall);
        Debug.Log("Fall State");
    }
    public override void Exit()
    {
    }
    public override void Update()
    {
        if (CheckIfCanIdle())
            _stateManager.ChangeState(_stateManager.PlayerIdle);
    }

    private bool CheckIfCanIdle()
    {
        return _stateManager.isOnGround;
    }
}
