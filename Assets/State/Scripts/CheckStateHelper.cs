using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CheckStateHelper
{
    public static bool CheckIfCanIdle(float directionX, bool isOnGround)
    {
        return Mathf.Abs(directionX) <= 0.1f && isOnGround;
    }

    public static bool CheckIfCanWalk(float directionX, bool isOnGround)
    {
        return directionX != 0 && isOnGround;
    }

    public static bool CheckIfCanJump()
    {
        return Input.GetKeyDown(KeyCode.S);
    }

    public static bool CheckIfCanFall(float yVelo, bool isOnGround)
    {
        return yVelo < 0f && !isOnGround;
    }

    public static bool CheckIfCanSit()
    {
        return Input.GetKeyDown(KeyCode.LeftShift);
    }
}
