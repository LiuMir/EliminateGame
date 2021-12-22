using System.Collections.Generic;
using Debug = UnityEngine.Debug;

public class RoleFSMMgr
{
    private Dictionary<int, RoleBaseState> RoleStatsList = new Dictionary<int, RoleBaseState>();

    public RoleBaseState PreRoleState;
    public RoleBaseState CurRoleState;

    public RoleFSMMgr(int RoleStateID)
    {
        AddAllState();
        ChangeRoleState(RoleStateID);
        MainEnter.UpdateEvent += Update;
    }

    private void AddAllState()
    {
        AddNewState(new RoleAIState(this));
        AddNewState(new RoleControlledState(this));
        AddNewState(new RoleDeathState(this));
    }

    public void AddNewState(RoleBaseState roleState)
    {
        if (!RoleStatsList.TryGetValue(roleState.ID, out RoleBaseState roleBaseState))
        {
            RoleStatsList.Add(roleState.ID, roleState);
        }
        else
        {
            Debug.LogError("[RoleFSMMgr]已经存在roleState->ID为: " + roleState.ID + " 的状态,状态类型为: " + roleBaseState.GetType().Name);
        }
    }

    public void ChangeRoleState(int RoleStateID)
    {
        if (RoleStatsList.TryGetValue(RoleStateID, out RoleBaseState nextRoleState))
        {
            PreRoleState = CurRoleState;
            CurRoleState?.OnExit();
            CurRoleState = nextRoleState;
            CurRoleState.OnEnter();
        }
        else
        {
            Debug.LogError("[RoleFSMMgr]不存在roleState->ID为: " + RoleStateID + " 的状态");
        }
    }

    public void Update()
    {
        CurRoleState?.OnStay();
    }

    public void Destory()
    {
        CurRoleState?.OnExit();
        MainEnter.UpdateEvent -= Update;
    }

}