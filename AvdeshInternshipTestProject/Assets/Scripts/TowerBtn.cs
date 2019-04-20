using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TowerBtn : MonoBehaviour {

    public string info;
    public Image image;
    public Sprite sprite;
    public TextMeshProUGUI text;

    private int priceChecker = 0;

    public void setChecker(int a)
    {
        priceChecker = a;
    }

    public int getChecker()
    {
        return priceChecker;
    }

    [SerializeField]
    private GameObject towerObject;
    [SerializeField]
    private Sprite dragSprite;

    public int towerPrice;

    public GameObject TowerObject
    {
        get
        {
            return towerObject;
        }
    }
	
    public void setInfo()
    {
        text.SetText(info);
        image.sprite = sprite;
    }

    public Sprite DragSprite
    {
        get
        {

            return dragSprite;
        }
    }

    public int TowerPrice
    {
        get
        {
            return towerPrice;
        }
    }
}
