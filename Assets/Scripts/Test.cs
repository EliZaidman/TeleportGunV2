using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField]
    private TestScriptable testScriptable;
    private void Start()
    {
        Debug.Log(testScriptable.Name);
    }
}
