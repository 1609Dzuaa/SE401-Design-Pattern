using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : BaseState
{
    public override void Enter(PlayerStateManager context)
    {
        base.Enter(context);
        _stateManager.Anim.SetInteger("state", (int)EState.PlayerState.Run);
        Debug.Log("Run State");
    }

    public override void Exit()
    {
    }

    public override void Update()
    {
    }
}
