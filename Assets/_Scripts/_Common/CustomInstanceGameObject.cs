using System.Collections.Generic;
using UnityEngine;
/************************************************************************/
/* 实例化不定个数的对象                                                 */
/************************************************************************/
public class CustomInstanceGameObject : MonoBehaviour {
    [SerializeField]
    GameObject goTemplate = null;
    [SerializeField]
    Transform goParent = null;
    //已实例化的对象
    private List<GameObject> goList = new List<GameObject>();
    //记录被销毁的对象对应的索引
    List<int> waitDel = new List<int>();

    Vector2 startPos;//初始坐标

    private int m_count = 0;
    public int ITEM_MAX_COUNT
    {
        get { return m_count; }
        set
        {
            if(value == 0 && m_count!=0)
            {
                (this.goParent as RectTransform).anchoredPosition = startPos;
            }
            m_count = value;
//            if(m_count==0)
//            {
//#if UNITY_EDITOR
//                try
//                {
//#endif
//                    GameFramework.Log.Error(this.goParent.name + "此时ITEM_MAX_COUNT=" + ITEM_MAX_COUNT);
//                    (this.goParent as RectTransform).anchoredPosition = startPos;
//#if UNITY_EDITOR
//                }
//                catch(Exception e)
//                {
//                    GameFramework.Log.Error(this.name + " parent name="+ this.goParent.name+" "+e.ToString());
//                }
//#endif
//            }
        }
    }

    public delegate void NewScrollCallback(GameObject go, int index);   // 新物件添加的回调
    public NewScrollCallback m_pCallback = null;
    public delegate void LoadAllFinish();
    public LoadAllFinish m_loadFinish = null;

    GameObject goCachePool = null;
    void Awake()
    {
        if (goTemplate)
            goTemplate.SetActive(false);
        if (goParent == null)
        {
            goParent = this.transform;
        }
        //GameFramework.Log.Error(this.goParent.name + "awake获取坐标====== "+ (this.goParent as RectTransform).anchoredPosition.x);
        startPos = (this.goParent as RectTransform).anchoredPosition;
        CreateCachePool();
    }
    // Use this for initialization
    //void Start () {
    //    if (goTemplate)
    //        goTemplate.SetActive(false);
    //    if (goParent==null)
    //    {
    //        goParent = this.transform;
    //    }
    //    GameFramework.Log.Error(this.goParent.name + "获取坐标======");
    //    startPos = (this.goParent as RectTransform).anchoredPosition;
    //    CreateCachePool();
    //}

    // Update is called once per frame
    // 	void Update () {
    // 		
    // 	}

    void CreateCachePool()
    {
        if (goCachePool == null || goCachePool.Equals(null))
        {
            goCachePool = new GameObject();
            goCachePool.name = "cachePool";
            goCachePool.SetActive(false);
            goCachePool.transform.parent = transform;
            goCachePool.transform.localScale = Vector3.one;
            goCachePool.transform.localPosition = Vector3.zero;
        }
    }
    public void Go()
    {
        if (goCachePool == null || goCachePool.Equals(null))
            CreateCachePool();

        if (goTemplate)
            goTemplate.SetActive(false);

        if (null != goList)
        {
            //多余的节点移到缓存节点下
            for (int i = ITEM_MAX_COUNT; i < goList.Count; i++)
            {
                goList[i].transform.SetParent(goCachePool.transform);
            }
        }

        for(int i=0;i< ITEM_MAX_COUNT;i++)
        {
            GameObject go = null;
            if (i< goList.Count && goList[i]!=null)
            {
                go = goList[i];
                if(go.transform.parent != goParent)
                {
                    go.transform.SetParent(goParent);
                }
            }
            else
            {
                go = Instantiate(goTemplate) as GameObject;
                go.transform.SetParent(goParent);
                go.SetActive(true);
                go.name = i.ToString();
                go.transform.localScale = Vector3.one;
                goList.Add(go);
            }
            SetData(go, i);
        }
        if (m_loadFinish != null)
            m_loadFinish();
    }

    void SetData(GameObject go,int index)
    {
        if(m_pCallback!=null)
        {
            m_pCallback(go, index);
        }
    }

    public void AddOneData()
    {
        GameObject go = null;
        ITEM_MAX_COUNT++;
        int i = ITEM_MAX_COUNT - 1;
        if (i < goList.Count && goList[i] != null)
        {
            go = goList[i];
            if (go.transform.parent != goParent)
            {
                go.transform.SetParent(goParent);
            }
        }
        else
        {
            go = Instantiate(goTemplate) as GameObject;
            go.transform.SetParent(goParent);
            go.SetActive(true);
            go.name = i.ToString();
            go.transform.localScale = Vector3.one;
            goList.Add(go);
        }
        SetData(go, i);
    }

    public void DelOneData(GameObject go)
    {
        for(int i=0;i< goList.Count;i++)
        {
            GameObject one = goList[i];
            if (one == go)
            {
                goList.RemoveAt(i);
                ITEM_MAX_COUNT--;
                go.transform.SetParent(goCachePool.transform);
            }
            //var go = goList[index];
            //goList.RemoveAt(index);
            //goList.Add(go);
            //ITEM_MAX_COUNT--;
            //go.transform.SetParent(goCachePool.transform);
        }
    }

    public void clearAll()
    {
        if (null != goList)
        {
            for (int i = 0; i < goList.Count; i++)
            {
                Destroy(goList[i]);
            }
        }
        goList.Clear();

        this.ITEM_MAX_COUNT = 0;
    }
}
