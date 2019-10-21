using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class RuntimeSet<T> : ScriptableObject
{
    #if UNITY_EDITOR
        [TextArea(3,10)]
        public string DeveloperDescription = "";
    #endif
    
    public List<T> items = new List<T>();
    
    public void Add(T type)
    {
        if (!items.Contains(type))
            items.Add(type);
    }

    public void Remove(T type)
    {
        if (items.Contains(type))
            items.Remove(type);
    }
}