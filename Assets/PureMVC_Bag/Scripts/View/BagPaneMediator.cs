using System.Collections;
using System.Collections.Generic;
using PureMVC.Interfaces;
using UnityEngine;
using UnityEngine.UI;

public class BagPaneMediator : PureMVC.Patterns.Mediator
{
    public new const string NAME = "BagPaneMediator";

    private BagPanelView View;

    PlayerDataProxy playerData;

    PlayerProxy Player;

    private List<GameObject> ItemLists = new List<GameObject>();


    public BagPaneMediator(object viewComponent) : base(NAME, viewComponent)
    {
        View = ((GameObject)ViewComponent).GetComponent<BagPanelView>();
       
        playerData = Facade.RetrieveProxy(PlayerDataProxy.NAME) as PlayerDataProxy;
        Player= Facade.RetrieveProxy(PlayerProxy.NAME) as PlayerProxy;
      

    }

    /// <summary>
    /// 获得集合数量
    /// </summary>
    public int GetItemListsCount
    {
        get
        {
            return ItemLists.Count;
        } 
    }

    /// <summary>
    /// 实例化ITem
    /// </summary>
    /// <returns></returns>
    public GameObject InstanceItem()
    {
        GameObject obj= GameObject.Instantiate(View.Item, View.parent.transform, false);

        obj.GetComponent<Button>().onClick.AddListener(() =>
        {
            ItemData data = obj.GetComponent<ItemData>();
            SendNotification(MyFacade.SHOW_TIP_BAG, data.data);
        });
        return obj;
    }

    /// <summary>
    /// 返回指定下标德Item
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public GameObject GetItem(int index)
    {
        return ItemLists[index];
    }
    /// <summary>
    /// 添加Item
    /// </summary>
    /// <param name="item"></param>
    public void AddItem(GameObject item)
    {
        ItemLists.Add(item);
    }
    /// <summary>
    /// 按下表删除
    /// </summary>
    /// <param name="index"></param>
    public void RemoveItem(int index)
    {
        GameObject.Destroy(ItemLists[index]);
        ItemLists.Remove(ItemLists[index]);
    }
    /// <summary>
    /// 注册消息
    /// </summary>
    /// <returns></returns>
    public override IList<string> ListNotificationInterests()
    {
        IList<string> list = new List<string>() { MyFacade.REFRESH_BAG_UI };
        return list;
    }

    /// <summary>
    /// 添加侦听
    /// </summary>
    /// <param name="notification"></param>
    public override void HandleNotification(INotification notification)
    {
        switch (notification.Name)
        {

            case MyFacade.REFRESH_BAG_UI:
                if(!View.isActiveAndEnabled)
                {
                    View.gameObject.SetActive(true);
                }
                View.SetHp(Player.Player.hp);
                View.SetName(Player.Player.name);
                View.SetImage(Player.Player.icon);
                
                break;
        }
    }
}
