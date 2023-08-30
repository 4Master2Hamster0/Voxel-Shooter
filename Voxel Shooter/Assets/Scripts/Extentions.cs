using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extentions
{
    public static GameObject GetRandObj(this List<GameObject> list){
        return list[Random.Range(0, list.Count)];
    }
}
