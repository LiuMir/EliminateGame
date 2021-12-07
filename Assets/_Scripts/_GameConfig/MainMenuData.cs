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
