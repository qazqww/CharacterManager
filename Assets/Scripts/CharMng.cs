using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharMng : IBaseMng<IChar, int>
{
    // 1. 캐릭터 매니저에 등록된 값은 중복되지 않은 유일한 값이 되어야 합니다.
    private Dictionary<int, IChar> m_charDic =new Dictionary<int, IChar>();

    // tableIdx값은 재활용 리스트를 구현할 때 사용할 값입니다.
    public IChar Add(int uniqueIdx, int tableIdx, IChar t)
    {
        t.SetMng(this);
        if (!m_charDic.ContainsKey(uniqueIdx))
            m_charDic.Add(uniqueIdx, t);

        return null;
    }

    public void Remove(int uniqueIdx)
    {
        if (m_charDic.ContainsKey(uniqueIdx))
            m_charDic.Remove(uniqueIdx);
    }

    public void Update(int uniqueIdx, int msg)
    {

    }
}