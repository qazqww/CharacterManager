using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpTest : MonoBehaviour
{
    // 접근 지정자를 public으로 해두면 유니티에 의해서 자동 할당이 됩니다.
    public List<BaseChar> m_sphereList;

    private HPComparer m_hPComparer = new HPComparer();
    void Start()
    {
        m_sphereList.AddRange(GetComponentsInChildren<BaseChar>(true));
        m_sphereList.Sort(m_hPComparer);

        for (int i = 0; i < m_sphereList.Count; ++i)
        {
            //Debug.Log( m_sphereList[i].HP );
        }

    }

    void Update()
    {
        if (m_sphereList.Count > 0 && m_hPComparer != null)
            m_sphereList.Sort(m_hPComparer);
    }
}
