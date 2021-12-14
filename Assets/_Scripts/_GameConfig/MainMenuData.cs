using System.Collections.Generic;
using System.Text;

// 主菜单配置表
public class MainMenuData : DataReadBase<st_main_menu_config, MainMenuData>
{
    public override string GetFilPath()
    {
        return @"E:\UnityDemo\EliminateGame\Assets\_Res\_Config\st_main_menu.bytes";
    }
}

// 英雄分组配置表
public class HeroBasicGroupData : DataReadBase<st_hero_basic_group_config, HeroBasicGroupData>
{
    public override string GetFilPath()
    {
        return @"E:\UnityDemo\EliminateGame\Assets\_Res\_Config\st_hero_basic_group.bytes";
    }
}

// 英雄数据配置表
public class HeroBasicData: DataReadBase<st_hero_basic_config, HeroBasicData>
{
    private readonly Dictionary<int, List<st_hero_basic_data>> allDatas = new Dictionary<int, List<st_hero_basic_data>>();

    public override string GetFilPath()
    {
        return @"E:\UnityDemo\EliminateGame\Assets\_Res\_Config\st_hero_basic.bytes";
    }

    public List<st_hero_basic_data> GetDatasByGroup(int Group)
    {
        if (allDatas.Count <= 0)
        {
            foreach (var item in GetAllData().Datas)
            {
                if (!allDatas.TryGetValue(item.Group, out List<st_hero_basic_data> items))
                {
                    items = new List<st_hero_basic_data>();
                    allDatas.Add(item.Group, items);
                }
                items.Add(item);
            }
        }
        allDatas.TryGetValue(Group, out List<st_hero_basic_data> datas);
        return datas;
    }

}

// 战斗场景配置表
public class BattleSceneData : DataReadBase<st_battle_scene_config, BattleSceneData>
{
    private readonly Dictionary<int, st_battle_scene_data> allDatas = new Dictionary<int, st_battle_scene_data>();

    public st_battle_scene_data GetDataByID(int id)
    {
        if (allDatas.Count <= 0)
        {
            foreach (var item in this.GetAllData().Datas)
            {
                if (!allDatas.ContainsKey(item.ID))
                {
                    allDatas.Add(item.ID, item);
                }
            }
        }
        allDatas.TryGetValue(id, out st_battle_scene_data data);
        return data;
    }

    public override string GetFilPath()
    {
        return @"E:\UnityDemo\EliminateGame\Assets\_Res\_Config\st_battle_scene.bytes";
    }
}

// 游戏资源路径配置
public class GameResPathData: DataReadBase<st_game_res_path_config, GameResPathData>
{
    private string[] resFileExtension = {".prefab" };
    private StringBuilder stringBuilder = new StringBuilder();

    private readonly Dictionary<int, st_game_res_path_data> allDatas = new Dictionary<int, st_game_res_path_data>();

    public st_game_res_path_data GetDataByID(int id)
    {
        if (allDatas.Count <= 0)
        {
            foreach (var item in this.GetAllData().Datas)
            {
                if (!allDatas.ContainsKey(item.ID))
                {
                    allDatas.Add(item.ID, item);
                }
            }
        }
        allDatas.TryGetValue(id, out st_game_res_path_data data);
        return data;
    }

    public string GetPathByID(int id)
    {
        st_game_res_path_data data = GetDataByID(id);
        stringBuilder.Clear();
        stringBuilder.AppendFormat("Assets/{0}{1}", data.Path, resFileExtension[data.Type - 1]);
        return stringBuilder.ToString();
    }

    public override string GetFilPath()
    {
        return @"E:\UnityDemo\EliminateGame\Assets\_Res\_Config\st_game_res_path.bytes";
    }
}
