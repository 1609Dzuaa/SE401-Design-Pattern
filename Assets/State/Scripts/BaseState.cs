using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseState
{
    protected PlayerStateManager _stateManager;

    public virtual void Enter(PlayerStateManager context)
    {
        _stateManager = context;
    }

    public abstract void Update();

    public abstract void Exit();
}
