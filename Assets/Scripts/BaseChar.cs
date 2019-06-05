using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseChar : MonoBehaviour, IChar
{
    private IBaseMng<IChar, int> m_Mng;
    public IBaseMng<IChar, int> Mng { get { return m_Mng; } }

    public void SetMng(IBaseMng<IChar, int> mng)
    {
        m_Mng = mng;
    }

    public void Notify(int uniqueIdx, int msg)
    {
        Mng.Update(uniqueIdx, msg);
    }    
}