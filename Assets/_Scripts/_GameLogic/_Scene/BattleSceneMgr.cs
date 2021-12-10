using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BattleSceneMgr:Singleton<BattleSceneMgr>
{

    private st_battle_scene_data sceneData;
    private string scenePath;
    private GameObject battleScene;
    // 场景初始化
    public void Init()
    {

    }

    public void CreateBattleSceneById(int id)
    {
        sceneData = BattleSceneData.Instance.GetDataByID(id);
        scenePath = GetPath(sceneData.Path);
        battleScene = AssetDatabase.LoadAssetAtPath<GameObject>(scenePath);
        battleScene = Object.Instantiate<GameObject>(battleScene);
        battleScene.transform.localPosition = Vector3.zero;
    }

   public void RemoveBattleScene()
    {
        if (null != battleScene)
        {
            Object.Destroy(battleScene);
        }
    }

    private string GetPath(string configPath)
    {
        return "Assets/" + configPath;
    }

}
