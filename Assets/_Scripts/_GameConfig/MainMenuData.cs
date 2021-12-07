using System.Collections.Generic;

public class MainMenuData : DataReadBase<st_main_menu_config, MainMenuData>
{
    public override string GetFilPath()
    {
        return @"E:\UnityDemo\EliminateGame\Assets\_Res\_Config\st_main_menu.bytes";
    }
}

public class HeroBasicGroup : DataReadBase<st_hero_basic_group_config, HeroBasicGroup>
{
    public override string GetFilPath()
    {
        return @"E:\UnityDemo\EliminateGame\Assets\_Res\_Config\st_hero_basic_group.bytes";
    }
}

public class HeroBasic: DataReadBase<st_hero_basic_config, HeroBasic>
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
