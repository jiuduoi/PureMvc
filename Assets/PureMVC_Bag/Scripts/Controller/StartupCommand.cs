using System.Collections;
using System.Collections.Generic;
using PureMVC.Interfaces;
using UnityEngine;

public class StartupCommand : PureMVC.Patterns.SimpleCommand
{
    public override void Execute(INotification notification)
    {
        
        GameObject obj = GameObject.Instantiate(Resources.Load<GameObject>("BagPanel"));
        obj.transform.position = Vector3.zero;
        obj.transform.localScale = Vector3.one;
        obj.SetActive(false);

        Facade.RegisterMediator(new BagPaneMediator(obj));

        SendNotification(MyFacade.REFRESH_BAG_ITEM);
    }
}
