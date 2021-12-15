using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BagTipPanelView : MonoBehaviour
{
    public Image _icon;
    public Text _name;
    public Text count;
    public Button user;
    public Button close;

    public void SetName(string name)
    {
        _name.text = name;
    }

    public void SetCount(int num)
    {
        count.text = num.ToString();
    }

    public void SetImage(string inco)
    {
        _icon.sprite = Resources.Load<Sprite>("Goods/"+inco);
    }

}
