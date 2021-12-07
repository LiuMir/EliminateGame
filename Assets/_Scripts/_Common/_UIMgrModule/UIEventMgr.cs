using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 主要为了不重复添加ui监听事件 （配合缓存池环境使用）
/// </summary>
public class UIEventMgr
{
    private readonly Dictionary<int, List<string>> addedEventList = new Dictionary<int, List<string>>();

    public void AddListener<T>(GameObject gameObject, string eventName, Action<T> AddCall) where T:Component
    {
        if (addedEventList.TryGetValue(gameObject.GetInstanceID(), out List<string> eventNames) && eventNames.Contains(eventName))
        {
            return;
        }
        eventNames = eventNames ?? new List<string>();
        eventNames.Add(eventName);
        addedEventList.Add(gameObject.GetInstanceID(), eventNames);
        AddCall?.Invoke(gameObject.GetComponent<T>());
    }
}
