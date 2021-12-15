using System.Collections;
using System.Collections.Generic;
using PureMVC.Interfaces;
using UnityEngine;

public class ShopTipBagCommand : PureMVC.Patterns.SimpleCommand
{
    public override void Execute(INotification notification)
    {
        BagTipPanelMediator mediator = Facade.RetrieveMediator(BagTipPanelMediator.NAME) as BagTipPanelMediator;
        if(mediator==null)
        {
            GameObject obj = GameObject.Instantiate(Resources.Load<GameObject>("BagTipPanel"));
            obj.transform.position = Vector3.zero;
            obj.transform.localScale = Vector3.one;
            mediator = new BagTipPanelMediator(obj);
            Facade.RegisterMediator(mediator);
        }
        
      
        SendNotification(MyFacade.REFRESH_TIP_UI, notification.Body);

    }

    
}
