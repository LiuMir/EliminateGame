using System;
using System.Collections.Generic;
using UnityEngine;

public class UIHelper
{
    //创建少量的子节点
    public static void AutoSetScrooll<T>(GameObject content, List<T> datas, Action<int, GameObject, T> action)
    {
        int childCount = content.transform.childCount;
        int dataCount = datas.Count;
        int maxNum = Math.Max(childCount, dataCount);
        GameObject cell = content.transform.GetChild(0).gameObject;
        for (int i = 0; i < maxNum; i++)
        {
            int index = i + 1;
            Transform tempCell = index > childCount ? null : content.transform.GetChild(i);
            if (index <= dataCount)
            {
                if (null == tempCell)
                {
                    tempCell = UnityEngine.Object.Instantiate(cell).transform;
                    tempCell.SetParent(content.transform, false);
                }
                tempCell.gameObject.SetActive(true);
                action?.Invoke(i, tempCell.gameObject, datas[i]);
            }
            else
            {
                tempCell?.gameObject.SetActive(false);
            }
        }
    }

}