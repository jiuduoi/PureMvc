using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BagPanelView : MonoBehaviour
{
    public GameObject parent;
    public GameObject Item;
    public Image image;
    public Text _name;
    public Text _hp;    

    
    public void SetHp(int hp)
    {
        _hp.text = "HP:" + hp;
    }

    public void SetName(string name)
    {
        _name.text = name;
    }

    public void SetImage(string iconPath)
    {
        image.sprite = Resources.Load<Sprite>("Goods/" + iconPath);
    }
}
