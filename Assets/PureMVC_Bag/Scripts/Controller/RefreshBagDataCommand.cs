using System.Collections;
using System.Collections.Generic;
using PureMVC.Interfaces;
using UnityEngine;

public class RefreshBagDataCommand : PureMVC.Patterns.SimpleCommand
{
    public override void Execute(INotification notification)
    {
        PlayerDataProxy playerData = MyFacade.Instance.RetrieveProxy(PlayerDataProxy.NAME) as PlayerDataProxy;
        PlayerDataModel model = notification.Body as PlayerDataModel;
        //删除数据
        if (playerData.itemList.Contains(model))
        {
            playerData.Remove(model);
        }

        BagPaneMediator mediator = MyFacade.Instance.RetrieveMediator(BagPaneMediator.NAME) as BagPaneMediator;

        PlayerProxy proxy = MyFacade.Instance.RetrieveProxy(PlayerProxy.NAME) as PlayerProxy;
        proxy.AddPlayerData(model.count);

        mediator.RemoveItem(model.id);
    }
}
