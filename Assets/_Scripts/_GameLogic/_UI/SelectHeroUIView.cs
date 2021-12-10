using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectHeroUIView : BaseUI
{
    private Button btnClose;
    private NodeHelper rootNodeHelper;
    private CustomInstanceGameObject markBookNode;
    private CustomInstanceGameObject heroListContent;
    private st_hero_basic_group_config groupConfig;
    private List<st_hero_basic_data> curShowHeroDatas;
    public override void Awake()
    {
        base.Awake();
        rootNodeHelper = viewMono.GetComponent<NodeHelper>();
        btnClose = rootNodeHelper.GetNode("rd_BtnClose").GetComponent<Button>();
        markBookNode = rootNodeHelper.GetNode("rd_BookmarkList").GetComponent<CustomInstanceGameObject>();
        heroListContent = rootNodeHelper.GetNode("rd_Content").GetComponent<CustomInstanceGameObject>();


        UIEventMgr.AddListener<Button>(rootNodeHelper.GetNode("rd_BtnClose"), "onClick", (btn) => { btn.onClick.AddListener(CloseSelf); });
        UIEventMgr.AddListener<Button>(rootNodeHelper.GetNode("rd_BtnNext"), "onClick", (btn) => { btn.onClick.AddListener(NextStep); });
        UIEventMgr.AddListener<CustomInstanceGameObject>(rootNodeHelper.GetNode("rd_BookmarkList"), "m_pCallback",
        (customInstance) =>
        {
            customInstance.m_pCallback += DrawMarkBook;
        });
        UIEventMgr.AddListener<CustomInstanceGameObject>(rootNodeHelper.GetNode("rd_Content"), "m_pCallback", (customInstance) =>
        {
            customInstance.m_pCallback += DrawHeroCellInfo;
        });
    }

    public override void Show(BaseArgs Args = null)
    {
        base.Show(Args);
        groupConfig = HeroBasicGroupData.Instance.GetAllData();
        UIUtility.SetAllToggleOff(markBookNode.GetComponent<ToggleGroup>());
        markBookNode.ITEM_MAX_COUNT = groupConfig.Datas.Count;
        markBookNode.Go();
    }

    public override void OnEnable()
    {
        base.OnEnable();
    }

    public override void OnDisable()
    {
        base.OnDisable();
    }

    private void CloseSelf()
    {
        UIMgr.Instance.OnCloseUI(viewMono);
    }

    private void NextStep()
    {
        CloseSelf();
        UIMgr.Instance.OnShowUI("GameActing");
        BattleSceneMgr.Instance.CreateBattleSceneById(1);// TODO 先简单的加载一个
    }

    private void DrawMarkBook(GameObject gameObject, int index)
    {
        NodeHelper nodeHelper = gameObject.GetComponent<NodeHelper>();
        Toggle toggle = gameObject.GetComponent<Toggle>();
        st_hero_basic_group_data data =  groupConfig.Datas[index];
        nodeHelper.GetNode("rd_txtName").GetComponent<Text>().text = data.Name;
        UIEventMgr.AddListener<Toggle>(gameObject, "onValueChanged", (tgl) =>
        {
            tgl.onValueChanged.AddListener((isOn) =>
            {
                MarkBookToggle(isOn, index);
            });
        });
        toggle.isOn = (index == 0);
    }

    private void MarkBookToggle(bool isOn, int index)
    {
        if (isOn)
        {
            st_hero_basic_group_data data = groupConfig.Datas[index];
            curShowHeroDatas = HeroBasicData.Instance.GetDatasByGroup(data.Group);
            if (null != curShowHeroDatas)
            {
                UIUtility.SetAllToggleOff(heroListContent.GetComponent<ToggleGroup>());
                heroListContent.ITEM_MAX_COUNT = curShowHeroDatas.Count;
                heroListContent.Go();
            }
        }
    }

    private void DrawHeroCellInfo(GameObject gameObject, int index)
    {
        UIUtility.SetUIEntry(gameObject, index);
        st_hero_basic_data data = curShowHeroDatas[index];
        NodeHelper nodeHelper = gameObject.GetComponent<NodeHelper>();
        nodeHelper.GetNode("rd_txtName").GetComponent<Text>().text = data.Name;

        UIEventMgr.AddListener<Toggle>(gameObject, "onValueChanged", (tgl) =>
        {
            tgl.onValueChanged.AddListener((isOn) =>
            {
                ClickHeroCell(isOn, tgl);
            });
        });
    }

    private void ClickHeroCell(bool isOn, Toggle tgl)
    {
        if (isOn)
        {
            int index = UIUtility.GetUIEntry(tgl.gameObject);
            st_hero_basic_data data = curShowHeroDatas[index];
        }
    }

}
