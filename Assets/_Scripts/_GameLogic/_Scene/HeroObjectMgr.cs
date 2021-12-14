using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

//游戏中的英雄对象
// 包含英雄数据、英雄模型、英雄FSM
public  class HeroObject
{
    public GameObject HeroModel;
    private bool beCtrled = false; // 是否被摇杆控制

    public HeroObject()
    {
        CustomJoystick.UpdateJoystickPos += JoystickCtrlModelPos;
    }

    public void SetBeCtrledStatus(bool isCtrled)
    {
        beCtrled = isCtrled;
    }

    private void JoystickCtrlModelPos(Vector2 joystickPos)
    {
        if (beCtrled)
        {
            Quaternion q = Quaternion.LookRotation(new Vector3(joystickPos.x, 0, joystickPos.y));
            HeroModel.transform.rotation = q;
            HeroModel.transform.Translate(Vector3.forward * 150f * Time.deltaTime);
        }
    }
}

/// <summary>
/// 游戏中英雄对象管理类 负责英雄对象的增(创建)、删(销毁)、获取
/// </summary>
public class HeroObjectMgr:Singleton<HeroObjectMgr>
{
    private List<HeroObject> allHeroObjects = new List<HeroObject>(); // TODO 暂时先用list 后续采用dic<唯一ID,HeroObject>

    public void Add(HeroObject heroObject)
    {
        allHeroObjects.Add(heroObject);
    }

    public void CreateAllHeroObjects()
    {
        GameObject templete = null;
        Vector3 spawnPos = Vector3.zero;
        foreach (var item in allHeroObjects)
        {
            templete = AssetDatabase.LoadAssetAtPath<GameObject>(GameResPathData.Instance.GetPathByID(2));
            item.HeroModel = Object.Instantiate(templete);
            spawnPos.y = Random.Range(18, 20);
            item.HeroModel.transform.position = spawnPos;
            item.SetBeCtrledStatus(true);
        }
    }

}
