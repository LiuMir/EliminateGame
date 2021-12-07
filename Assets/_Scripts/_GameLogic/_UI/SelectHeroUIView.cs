using UnityEngine;
using UnityEngine.UI;

public class SelectHeroUIView : BaseUI
{
    private Button btnClose;
    private NodeHelper rootNodeHelper;
    private CustomInstanceGameObject markBookNode;
    private st_hero_basic_group_config groupConfig;
    public override void Awake()
    {
        base.Awake();
        rootNodeHelper = viewMono.GetComponent<NodeHelper>();
        btnClose = rootNodeHelper.GetNode("rd_BtnClose").GetComponent<Button>();
        markBookNode = rootNodeHelper.GetNode("rd_BookmarkList").GetComponent<CustomInstanceGameObject>();
    }

    public override void Show(BaseArgs Args = null)
    {
        base.Show(Args);
        groupConfig = HeroBasicGroup.Instance.GetAllData();
        UIUtility.SetAllToggleOff(markBookNode.GetComponent<ToggleGroup>());
        markBookNode.ITEM_MAX_COUNT = groupConfig.Datas.Count;
        markBookNode.Go();
    }

    public override void OnEnable()
    {
        base.OnEnable();
        UIEventMgr.AddListener<Button>(rootNodeHelper.GetNode("rd_BtnClose"), "onClick", (btn) => { btn.onClick.AddListener(CloseSelf); });
        UIEventMgr.AddListener<CustomInstanceGameObject>(rootNodeHelper.GetNode("rd_BookmarkList"), "m_pCallback", 
        (customInstance) =>
        {
            customInstance.m_pCallback += DrawMarkBook;
        });
    }

    public override void OnDisable()
    {
        base.OnDisable();
    }

    private void CloseSelf()
    {
        UIMgr.Instance.OnCloseUI(viewMono);
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
            Debug.LogError(data.Name);
        }
    }

}
