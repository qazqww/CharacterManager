using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewHPTest : MonoBehaviour
{
    public List<NewChar> CharList;
    NewHPComparer newHPComparer = new NewHPComparer();

    void Start()
    {
        CharList.AddRange(GetComponentsInChildren<NewChar>());
        CharList.Sort(newHPComparer);
    }

    // Update is called once per frame
    void Update()
    {
        CharList.Sort(newHPComparer);
    }
}
