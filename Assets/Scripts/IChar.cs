using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IChar
{
    IBaseMng<IChar, int> Mng { get; }
    void SetMng(IBaseMng<IChar, int> mng);
    void Notify(int uniqueIdx, int msg);
}