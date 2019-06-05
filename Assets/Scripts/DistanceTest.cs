using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceTest : MonoBehaviour
{
    // 접근 지정자를 public으로 해두면 유니티에 의해서 자동 할당이 됩니다.
    public List<Transform> m_sphereList;

    private DistanceComparer m_distanceComparer = new DistanceComparer();

    void Start()
    {
        GameObject obj =  GameObject.FindGameObjectWithTag("Player");
        m_distanceComparer.SetTarget(obj.transform);

        m_sphereList.AddRange(GetComponentsInChildren<Transform>(true));
        m_sphereList.Sort(m_distanceComparer);

        for(int i = 0; i< m_sphereList.Count; ++ i )
            Debug.Log(m_sphereList[i].position.magnitude);
    }

    void Update()
    {
        if (m_sphereList.Count > 0 && m_distanceComparer != null)
            m_sphereList.Sort(m_distanceComparer);
    }
}