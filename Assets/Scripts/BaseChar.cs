using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseChar : MonoBehaviour, IChar
{
    private IBaseMng<IChar, int> m_Mng;
    public IBaseMng<IChar, int> Mng { get { return m_Mng; } }

    FSM fsm;

    void Awake()
    {
        fsm = GetComponent<FSM>();
    }

    public virtual void Register()
    {
        fsm.Add(CharState.IDLE, EnterIdle, RunIdle, ExitIdle);
        fsm.Add(CharState.ATTACK, EnterAttack, RunAttack, ExitAttack);
        fsm.SetState(CharState.IDLE);
    }

    public void SetMng(IBaseMng<IChar, int> mng)
    {
        m_Mng = mng;
    }

    // ※옵저버 패턴, 이벤트가 발생했을 때 처리할 동작을 정의?
    public void Notify(int uniqueIdx, int msg)
    {
        IChar[] chars = Mng.Update(uniqueIdx, msg);
    }

    protected virtual void EnterIdle()
    {

    }

    protected virtual void RunIdle()
    {

    }

    protected virtual void ExitIdle()
    {

    }

    protected virtual void RunEnter()
    {

    }

    protected virtual void RunMove()
    {

    }

    protected virtual void EnterAttack()
    {

    }

    protected virtual void RunAttack()
    {

    }

    protected virtual void ExitAttack()
    {

    }
}