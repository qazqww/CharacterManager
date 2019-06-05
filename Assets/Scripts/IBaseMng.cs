using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBaseMng<T, MSG>
{
    T Add(int uniqueIdx, int tableIdx, T t);
    void Remove(int uniqueIdx);
    void Update(int uniqueIdx, MSG msg);
}