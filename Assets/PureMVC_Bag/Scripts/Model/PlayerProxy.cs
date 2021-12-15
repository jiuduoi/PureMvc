using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProxy : PureMVC.Patterns.Proxy
{
    public new static string NAME = "Player";

    public PlayerModel Player;

    public PlayerProxy(string name) :base (name,null)
    {
        Player = new PlayerModel();
    }

    public void AddPlayerData(int num)
    {
        Player.hp += num;

        //发送更新的消息
        SendNotification(MyFacade.REFRESH_BAG_UI);
    }
    public void InitPlayer()
    {
        Player.name = "叶腾飞";
        Player.hp = 100;
        Player.icon = "10";
    }


}
