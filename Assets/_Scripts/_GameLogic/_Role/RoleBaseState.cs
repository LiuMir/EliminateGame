using Debug = UnityEngine.Debug;

public abstract class RoleBaseState
{
    public int ID { get; protected set; }
    public RoleFSMMgr RoleFSMMgr;

    public RoleBaseState(RoleFSMMgr roleFSMMgr)
    {
        RoleFSMMgr = roleFSMMgr;
        SetStateID();
    }

    protected virtual void SetStateID() { ID = RoleStateID.RoleNoneStateID; }
    public virtual void OnEnter() { }
    public virtual void OnStay() { }
    public virtual void OnExit() { }
}

// 状态ID
public class RoleStateID
{
    public static readonly int RoleNoneStateID = 0;
    public static readonly int RoleAIStateID = 1;
    public static readonly int RoleControlledStateID = 2;
    public static readonly int RoleDeathStateID = 3;
}

// AI控制状态
public class RoleAIState : RoleBaseState
{
    public RoleAIState(RoleFSMMgr roleFSMMgr) : base(roleFSMMgr)
    {
    }

    public override void OnEnter()
    {
        base.OnEnter();
        Debug.LogError("RoleAIState OnEnter");
    }

    public override void OnExit()
    {
        base.OnExit();
        Debug.LogError("RoleAIState OnExit");
    }

    public override void OnStay()
    {
        base.OnStay();
        Debug.LogError("RoleAIState OnStay");
    }

    protected override void SetStateID()
    {
        base.SetStateID();
        ID = RoleStateID.RoleAIStateID;
    }
}

// 玩家操控状态
public class RoleControlledState : RoleBaseState
{
    public RoleControlledState(RoleFSMMgr roleFSMMgr) : base(roleFSMMgr)
    {
    }

    public override void OnEnter()
    {
        base.OnEnter();
        Debug.LogError("RoleControlledState OnEnter");
    }

    public override void OnExit()
    {
        base.OnExit();
        Debug.LogError("RoleControlledState OnExit");
    }

    public override void OnStay()
    {
        base.OnStay();
        Debug.LogError("RoleControlledState OnStay");
    }

    protected override void SetStateID()
    {
        base.SetStateID();
        ID = RoleStateID.RoleControlledStateID;
    }
}

// 死亡状态
public class RoleDeathState : RoleBaseState
{
    public RoleDeathState(RoleFSMMgr roleFSMMgr) : base(roleFSMMgr)
    {
    }

    public override void OnEnter()
    {
        base.OnEnter();
        Debug.LogError("RoleDeathState OnEnter");
    }

    public override void OnExit()
    {
        base.OnExit();
        Debug.LogError("RoleDeathState OnExit");
    }

    public override void OnStay()
    {
        base.OnStay();
        Debug.LogError("RoleDeathState OnStay");
    }

    protected override void SetStateID()
    {
        base.SetStateID();
        ID = RoleStateID.RoleDeathStateID;
    }
}
