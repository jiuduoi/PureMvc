using System.Collections;
using System.Collections.Generic;
using PureMVC.Interfaces;
using UnityEngine;

public class RefreshBagItemCommand : PureMVC.Patterns.SimpleCommand
{
    public override void Execute(INotification notification)
    {
        PlayerDataProxy data = Facade.RetrieveProxy(PlayerDataProxy.NAME) as PlayerDataProxy;

        if(data!=null)
        {
            data.Clera();

            data.CreatBag(20);

            BagPaneMediator mediator = Facade.RetrieveMediator(BagPaneMediator.NAME) as BagPaneMediator;

            bool newCreate = mediator.GetItemListsCount == 0;

            GameObject obj = null;
                
            for (int i = 0; i < data.itemList.Count; ++i)
            {
                if(newCreate)
                {
                    obj = mediator.InstanceItem();
                    obj.SetActive(true);
                }
                else
                {
                    obj = mediator.GetItem(i);
                }

                ItemData item = obj.GetComponent<ItemData>();

                if(item!=null)
                {
                    item.UpdataItem(data.itemList[i]);

                }

                mediator.AddItem(obj);

            }
            PlayerProxy proxy = Facade.RetrieveProxy(PlayerProxy.NAME) as PlayerProxy;

            if(proxy!=null)
            {
                proxy.InitPlayer();    
            }

            SendNotification(MyFacade.REFRESH_BAG_UI);


        }
    }
}
