using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ActionState
{
    Enter,
    Exit,
    Run
}

public class ActionTemplate : Action<ActionState>
{
    public override void Enter()
    {
        Call(ActionState.Enter);
    }

    public override void Exit()
    {
        Call(ActionState.Exit);
    }

    public override void Run()
    {
        Call(ActionState.Run);
    }
}
