
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
#if UNITY_EDITOR
using System.Reflection;
using UnityEditor;
#endif

[RequireComponent(typeof(CanvasScaler))]
public class AutoCanvasScaler : MonoBehaviour
{
    CanvasScaler m_cs = null;
#if UNITY_EDITOR
    private float lastwidth = 0f;
    private float lastheight = 0f;
    AutoCanvasScaler()
    {
        EditorApplication.update += Update;     //编辑器模式，确保拉伸时自动设置对齐方式
    }
#endif

    void Awake()
    {
        m_cs = GetComponent<CanvasScaler>();
        CheckHW();
    }

    void CheckHW()
    {
        //处理非开发比例模式的屏幕时的CanvasScaler参数缩放
        
        if (m_cs)
        {
            if (this.enabled)
            {
                float dev_base = m_cs.referenceResolution.x / m_cs.referenceResolution.y + 0.0001f;
                if (Screen.width * 1.0f / Screen.height > dev_base) //扁屏的情况，matchWidthOrHeight 要为 1  即match Height
                {
                    m_cs.matchWidthOrHeight = 1;
                }
                else
                {
                    m_cs.matchWidthOrHeight = 0;
                }
            }
        }
        else
        {
            if(this.Equals(null))
            {
#if UNITY_EDITOR
                EditorApplication.update -= Update;
#endif
            }
            else
            {
                m_cs = GetComponent<CanvasScaler>();
            }
        }
    }

#if UNITY_EDITOR
    void Update()
    {
        if (lastwidth != Screen.width || lastheight != Screen.height)
        {
            CheckHW();
            lastwidth = Screen.width;
            lastheight = Screen.height;
        }
        
    }

    ~AutoCanvasScaler()
    {
        EditorApplication.update -= Update;
    }

#endif
}
