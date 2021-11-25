using UnityEditor;
using UnityEngine;

public class GameMapMgr:Singleton<GameMapMgr>
{
    private Transform mapBlockContent;
    private string PlanePath = "Assets/_Res/_Map/GameMapRoot.prefab";
    private string blockPath = "Assets/_Res/_Map/Cube.prefab";
    private int centerColIndex = 4; // 靠近中间 往上的第一排
    private int centerRowIndex = 2; // 中间 那一列
    private int totalColNum = 10; // 最大行数 10*5 暂时写死（一般不会改动了） 后续可以自由调整
    private int totalRowNum = 5; // 最大列数 10*5 暂时写死（一般不会改动了） 后续可以自由调整
    private int blockSize = 10;//默认块为正方体 10*10*10
    private Vector3 blockPostion = Vector3.zero;
    private Vector3 blockScale = new Vector3(8, 1, 8);
    private bool isInited = false; // 是否已经初始化

    // 初始化
    public void Init()
    {
        if (isInited)
        {
            Debug.LogWarning("元素地图已经初始化！！！");
            return;
        }
        CreatePlane("");
        InitCreateBlock();
        InitMapEvent();
        isInited = true;
    }

    // 创建地表
    private void CreatePlane(string path)
    {
        GameObject template = AssetDatabase.LoadAssetAtPath<GameObject>(PlanePath);
        GameObject plane = Object.Instantiate(template);
        plane.transform.position = Vector3.zero;
        mapBlockContent = plane.transform.Find("BlockContent");
    }

    // 初始创建元素块
    private void InitCreateBlock()
    {
        GameObject template = AssetDatabase.LoadAssetAtPath<GameObject>(blockPath);
        for (int i = 0; i < totalColNum; i++)
        {
            for (int j = 0; j < totalRowNum; j++)
            {
                CreateOneBlock(i, j, template);
            }
        }
    }

    // 更新元素快
    private void UpdateBlock()
    {
        //TODO 规则如下：
        // 上面消除 由底部往上走
        // 下面消除 由上往下走
    }

    // 创建一个块
    private void CreateOneBlock(int col, int row, GameObject template)
    {
        GameObject block = Object.Instantiate(template);
        float x = (-(row - centerRowIndex)) * blockSize;
        float z = (-(col - centerColIndex)) * blockSize + (blockSize * 0.5f);
        blockPostion.Set(x, 0, z);
        block.transform.SetParent(mapBlockContent);
        block.transform.localPosition = blockPostion;
        block.transform.localScale = blockScale;
    }

    // 初始化事件
    private void InitMapEvent()
    {
        FingerGestureMgr.Instance.TapEvent += (tapGesture) =>
        {
        };

       FingerGestureMgr.Instance.DragEvent += (dragGesture) =>
        {
            //GameObject obj = FingerGestureMgr.Instance.PickGameObject(dragGesture, dragGesture.Position);
            //Debug.LogError(obj?.name);
        };

        FingerGestureMgr.Instance.FingerDownEvent += (FingerDownEvent) =>
        {

            //TODO 点中一个元素块时 高亮所有 洪水填充算出来的元素块
            // 并且选中第一个后才能进行连选
            Debug.LogError("lzh down name"+ FingerDownEvent.Selection?.name);
        };

        FingerGestureMgr.Instance.FingerUpEvent += (fingerUpEvent) =>{
            Debug.LogError("lzh FingerUpEvent");
        };
    }

}