using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyFacade : PureMVC.Patterns.Facade
{

    public const string START_UP = "start_up";//开始游戏
    public const string REFRESH_BAG_ITEM = "refresh_bag_item";//刷新格子数据
    public const string REFRESH_BAG_UI = "refresh_bag_ui";//刷新UI
    public const string SHOW_TIP_BAG = "show_tip_bag";//显示二级面板
    public const string REFRESH_TIP_UI = "refresh_tip_ui";//刷新二级面板
    public const string REFRESH_BAG_DATA = "refresh_bag_data";//刷新格子数据
    

    /// <summary>
    /// 静态初始化
    /// </summary>
   static MyFacade()
    {
        m_instance = new MyFacade();
    }

    /// <summary>
    /// 获得单例
    /// </summary>
    /// <returns></returns>
    public static MyFacade GetInstance()
    {
        return m_instance as MyFacade;
    }
    /// <summary>
    /// 启动MVC
    /// </summary>
    public void Launch()
    {
        SendNotification(MyFacade.START_UP);
    }

    /// <summary>
    /// 初始化Controller
    /// </summary>
    protected override void InitializeController()
    {
        base.InitializeController();

        RegisterCommand(START_UP, typeof(StartupCommand));
        RegisterCommand(REFRESH_BAG_ITEM, typeof(RefreshBagItemCommand));
        RegisterCommand(SHOW_TIP_BAG, typeof(ShopTipBagCommand));
        RegisterCommand(REFRESH_BAG_DATA, typeof(RefreshBagDataCommand));

    }

    /// <summary>
    /// 初始化Model
    /// </summary>
    protected override void InitializeModel()
    {
        base.InitializeModel();
        RegisterProxy(new PlayerDataProxy(PlayerDataProxy.NAME));
        RegisterProxy(new PlayerProxy(PlayerProxy.NAME));
    }

    /// <summary>
    /// 初始化View
    /// </summary>
    protected override void InitializeView()
    {
        base.InitializeView();
    }

    /// <summary>
    /// 初始化Facade
    /// </summary>
    protected override void InitializeFacade()
    {
        base.InitializeFacade();
    }
}
