using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataModel  
{
    public int id;
    public string name;
    public int count;
    public string icon;

   

    public PlayerDataModel(int id,string name, int count, string icon)
    {
        this.id = id;
        this.name = name;
        this.count = count;
        this.icon = icon;
    }
}
