using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

//游戏中的英雄对象
// 包含英雄数据、英雄模型、英雄FSM
public  class RoleObject
{
    public GameObject HeroModel;
    public RoleFSMMgr RoleFSMMgr;
    private bool beCtrled = false; // 是否被摇杆控制
    private Vector3 direVec;

    public RoleObject()
    {
        RoleFSMMgr = new RoleFSMMgr(RoleStateID.RoleAIStateID);
        CustomJoystick.UpdateJoystickPos += JoystickCtrlModelPos;
    }

    public void SetBeCtrledStatus(bool isCtrled)
    {
        beCtrled = isCtrled;
        if (isCtrled)
        {
            RoleFSMMgr.ChangeRoleState(RoleStateID.RoleControlledStateID);
        }
    }

    public void Destory()
    {
        RoleFSMMgr.Destory();
        RoleFSMMgr = null;
        CustomJoystick.UpdateJoystickPos -= JoystickCtrlModelPos;
        Object.Destroy(HeroModel);
        HeroModel = null;
    }

    private void JoystickCtrlModelPos(Vector2 joystickPos)
    {
        if (beCtrled)
        {
            direVec.x = joystickPos.x;
            direVec.y = 0;
            direVec.z = joystickPos.y;
            Quaternion q = Quaternion.LookRotation(direVec.normalized);
            HeroModel.transform.rotation = q;
            HeroModel.transform.Translate(direVec.normalized * 150f * Time.deltaTime, Space.World);
        }
    }
}

/// <summary>
/// 游戏中英雄对象管理类 负责英雄对象的增(创建)、删(销毁)、获取
/// </summary>
public class RoleObjectMgr:Singleton<RoleObjectMgr>
{
    private List<RoleObject> allRoleObjects = new List<RoleObject>(); // TODO 暂时先用list 后续采用dic<唯一ID,HeroObject>

    public void Add(RoleObject heroObject)
    {
        allRoleObjects.Add(heroObject);
    }

    public void CreateAllRoleObjects()
    {
        GameObject templete = null;
        Vector3 spawnPos = Vector3.zero;
        foreach (var item in allRoleObjects)
        {
            templete = AssetDatabase.LoadAssetAtPath<GameObject>(GameResPathData.Instance.GetPathByID(2));
            item.HeroModel = Object.Instantiate(templete);
            spawnPos.y = Random.Range(18, 20);
            item.HeroModel.transform.position = spawnPos;
            item.SetBeCtrledStatus(true);
        }
    }

    public void ClearAllRoleObjects()
    {
        foreach (var item in allRoleObjects)
        {
            item.Destory();
        }
        allRoleObjects.Clear();
    }

}
