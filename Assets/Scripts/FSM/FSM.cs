using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CharState
{
    IDLE,
    MOVE,
    ATTACK,
    PATROL,
}

public class FSM : MonoBehaviour
{
    CharState curState = CharState.IDLE;

    Dictionary<CharState, ActionTemplate> actionDic = new Dictionary<CharState, ActionTemplate>();
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void ChangeState(CharState state)
    {
        actionDic[curState].Exit();
        curState = state;
        actionDic[curState].Enter();
    }

    public void SetState(CharState state)
    {
        curState = state;
        actionDic[curState].Enter();
    }

    public bool IsState(CharState state)
    {
        if (curState == state)
            return true;
        else
            return false;
    }

    public void Add(CharState state, System.Action Enter, System.Action Run, System.Action Exit)
    {
        if(!actionDic.ContainsKey(state))
        {
            ActionTemplate template = new ActionTemplate();
            template.Add(ActionState.Enter, Enter);            
            template.Add(ActionState.Run, Run);
            template.Add(ActionState.Exit, Exit);

            actionDic.Add(state, template);
        }
    }

    public void Clear()
    {
        actionDic.Clear();
    }

    public void Run()
    {
        if (actionDic.ContainsKey(curState))
            actionDic[curState].Run();
    }    
}
