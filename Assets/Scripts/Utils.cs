using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

using BreakInfinity;

public class Utils : MonoBehaviour
{
    public static List<T> CreateList<T>(int capacity)
    {
        return Enumerable.Repeat(default(T), capacity).ToList();
    }

    // add an upgrade button to the list if it exists, otherwise make it
    public static void UpgradeCheck<T>(List<T> list, int length) where T : new()
    {
        try
        {
            if (list.Count == 0)
                list = CreateList<T>(length);

            while(list.Count < length)
                list.Add(new T());
        }
        catch
        {
            list = CreateList<T>(length);
        }
    }
}