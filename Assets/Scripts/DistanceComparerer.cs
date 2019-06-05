using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceComparer : IComparer<Transform>
{
    // 비교 대상이 되는 타겟입니다.
    private Transform m_target;

    public void SetTarget(Transform target)
    {
        m_target = target;
    }

    public int Compare(Transform x, Transform y)
    {
        if( x == null )
        {
            if (y == null)
                return 0;

            return -1; 
        }

        else
        {
           if( y == null )
                return 1;
           else
           {
                float distanceX = Vector3.Distance(m_target.position, x.position);
                float distanceY = Vector3.Distance(m_target.position, y.position);
                return distanceX.CompareTo(distanceY);
            }
        }
    }
}