using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewComparer : IComparer<Transform>
{
    public int Compare(Transform x, Transform y)
    {
        if (x == null && y == null)
            return 0;

        else if (x == null)
            return -1;

        else if (y == null)
            return 1;

        else
        {
            if (x.position.magnitude > y.position.magnitude)
                return 1;
            else if (x.position.magnitude < y.position.magnitude)
                return -1;
            else
                return 0;
        }
    }
}
