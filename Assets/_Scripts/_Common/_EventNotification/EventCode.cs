using System.Collections.Generic;

public enum EventCode
{
    NewUIUpdateDataMsg = 1,
}

// 为了让EventCode作为字典key不会出现装箱、拆箱 
// 原理 把默认的比较方法替换成EventCodeComparer
public class EventCodeComparer : IEqualityComparer<EventCode>
{
    public bool Equals(EventCode x, EventCode y)
    {
        return x == y;
    }

    public int GetHashCode(EventCode eventCode)
    {
        return (int)eventCode;
    }
}