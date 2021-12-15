using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataProxy : PureMVC.Patterns.Proxy
{
    public new const string NAME = "PlayerDataProxy";

    public PlayerDataModel PlayerData;

    private static string[] REWARD_NAME = new string[] { "封海翔", "徐康瑞", "张玉豪", "杜宇", "白仁涛" };
    private static int[] REWARD_PRICE = new int[] { 10, 30, 50, 80, 120 };

    public List<PlayerDataModel> itemList = new List<PlayerDataModel>();

    public PlayerDataProxy(string name) :base (name)
    {
       
    }

    /// <summary>
    /// 创建背包
    /// </summary>
    /// <param name="count"></param>
    public void CreatBag(int count)
    {
        for (int i = 0; i < count; i++)
        {
            int id = i;
            string name = REWARD_NAME[Random.Range(0, REWARD_NAME.Length)];
            int count1 = REWARD_PRICE[Random.Range(0, REWARD_PRICE.Length)];
            string icon = Random.Range(1, 10).ToString();
            PlayerDataModel model = new PlayerDataModel(i,name, count1, icon);
            itemList.Add(model);
        }
    }

    public void Remove(PlayerDataModel model)
    {
        itemList.Remove(model);
        for (int i = model.id; i < itemList.Count; i++)
        {
            itemList[i].id--;
        }

    }

    public void Clera()
    {
        itemList.Clear();
    }
}
