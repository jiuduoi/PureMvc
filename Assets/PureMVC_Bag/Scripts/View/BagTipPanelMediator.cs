using System;
using System.Collections;
using System.Collections.Generic;
using PureMVC.Interfaces;
using UnityEngine;

public class BagTipPanelMediator : PureMVC.Patterns.Mediator
{
    public new const string NAME = "BagTipPanelMediator";

    private BagTipPanelView View;

    PlayerDataModel model;

    PlayerProxy proxy;

    public BagTipPanelMediator(object viewComponent) : base(NAME, viewComponent)
    {
        View = ((GameObject)ViewComponent).GetComponent<BagTipPanelView>();
        proxy = Facade.RetrieveProxy(PlayerProxy.NAME) as PlayerProxy;
        View.user.onClick.AddListener(UserData);
        View.close.onClick.AddListener(ClosePanel);
    }

    /// <summary>
    /// 关闭Tip
    /// </summary>
    private void ClosePanel()
    {
       
        View.gameObject.SetActive(false);

    }

    /// <summary>
    /// 使用道具
    /// </summary>
    private void UserData()
    {
        View.gameObject.SetActive(false);

        SendNotification(MyFacade.REFRESH_BAG_DATA, model);

    }
    /// <summary>
    /// 添加事件侦听
    /// </summary>
    /// <returns></returns>
    public override IList<string> ListNotificationInterests()
    {
        IList<string> list = new List<string>() { MyFacade.REFRESH_TIP_UI};
        return list;
    }
    /// <summary>
    /// 事件监听
    /// </summary>
    /// <param name="notification"></param>
    public override void HandleNotification(INotification notification)
    {
        switch (notification.Name)
        {
            case MyFacade.REFRESH_TIP_UI:
                if (!View.isActiveAndEnabled)
                {
                    View.gameObject.SetActive(true);
                }
                model = notification.Body as PlayerDataModel;
                if(model!=null)
                {
                    View.SetName(model.name);
                    View.SetCount(model.count);
                    View.SetImage(model.icon);

                }
        
                break;
            default:
                break;
        }
    }
}
