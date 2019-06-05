using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewHPComparer : IComparer<NewChar>
{
    public int Compare(NewChar x, NewChar y)
    {
        if (x==null)
        {
            if (y == null)
                return 0;
            else
                return -1;
        }
        else
        {
            if (y == null)
                return 1;
            else
            {
                return x.hp.CompareTo(y.hp);
            }
        }
    }
}
