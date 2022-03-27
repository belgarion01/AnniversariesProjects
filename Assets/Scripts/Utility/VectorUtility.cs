using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class VectorUtility
{
    public static float RandomFloat(this Vector2 v)
    {
        return Random.Range(v.x, v.y);
    }
}
