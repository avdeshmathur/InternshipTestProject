using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class TowerManager : Singleton<TowerManager>
{

    public TowerBtn towerBtnPressed;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);
            if (hit.collider.tag == "Ground")
            {
                placeTower(hit);
            }
        }
        if (spriteRenderer.enabled)
        {
            followMouse();
        }
    }

    public void placeTower(RaycastHit2D hit)
    {
        if (!EventSystem.current.IsPointerOverGameObject() && towerBtnPressed != null)
        {
            if (towerBtnPressed.getChecker() <= GameManager.Instance.money)
            {
                GameObject newTower = Instantiate(towerBtnPressed.TowerObject);
                newTower.transform.position = new Vector2(transform.position.x, transform.position.y);
                buyTower(towerBtnPressed.TowerPrice);
                disableDragSprite();
                towerBtnPressed = null;
           }
        }
    }

    public void buyTower(int price)
    {
        GameManager.Instance.subMoney(price);
    }

    public void selectedTower(TowerBtn towerSelected)
    {
        if (towerSelected.towerPrice <= GameManager.Instance.money)
        {
            towerBtnPressed = towerSelected;
            towerBtnPressed.setChecker(towerSelected.towerPrice);
            enableDragSprite(towerBtnPressed.DragSprite);

        }else if (towerSelected.towerPrice > GameManager.Instance.money)
        {
            return;
        }
    }

    public void followMouse()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(transform.position.x, transform.position.y);
    }

    public void enableDragSprite(Sprite sprite)
    {
        spriteRenderer.enabled = true;
        spriteRenderer.sprite = sprite;
    }

    public void disableDragSprite()
    {
        spriteRenderer.enabled = false;
    }
}