using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPComparer : IComparer<BaseChar>
{
    public int Compare(BaseChar x, BaseChar y)
    {
        if (x == null)
        {
            if (y == null)
                return 0;

            return -1;
        }

        else
        {
            if (y == null)
                return 1;
            else
            {
                //return x.HP.CompareTo(y.HP);
                return 0;
            }
        }
    }
}
