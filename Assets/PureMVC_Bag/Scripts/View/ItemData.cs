using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemData : MonoBehaviour
{
    public PlayerDataModel data;
    public Text count;
    public Text _name;
    public Image image;

   

    public void UpdataItem(PlayerDataModel model)
    {
        
        data = model;
        RandomColor();
        if (data!=null)
        {
            count.text = data.count.ToString();
            _name.text = data.name;
        }
    }

    private void RandomColor()
    {
        image.sprite = Resources.Load<Sprite>("Goods/"+data.icon);
    }
}
