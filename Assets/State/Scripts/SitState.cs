using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SitState : BaseState
{
    public override void Enter(PlayerStateManager context)
    {
        base.Enter(context);
        _stateManager.Anim.SetInteger("state", (int)EState.PlayerState.Sit);
        _stateManager.Rb2D.velocity = Vector2.zero;
        _stateManager.Collider2D.size = new Vector2(0.875f, 1.15f);
        Debug.Log("Sit State");
    }

    public override void Exit()
    {
        _stateManager.Collider2D.size = new Vector2(0.875f, 1.6875f);
    }

    public override void Update()
    {
        if (CheckIfCanIdle())
            _stateManager.ChangeState(_stateManager.PlayerIdle);
    }

    private bool CheckIfCanIdle()
    {
        return !Input.GetKey(KeyCode.LeftShift);
    }
}
