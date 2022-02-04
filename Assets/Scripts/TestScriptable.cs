using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "test scriptable", menuName = "ScriptableObjects/test")]
public class TestScriptable :ScriptableObject
{
    public string Name;
    [SerializeField]
    private AudioClip a;
        
}
