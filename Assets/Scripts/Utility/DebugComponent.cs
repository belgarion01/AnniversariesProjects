using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugComponent : MonoBehaviour
{
    public void DebugVoid()
    {
        Debug.Log("Hit Test !");
    }
    
    public void DebugString(string debugMessage)
    {
        Debug.Log(debugMessage);
    }
}
