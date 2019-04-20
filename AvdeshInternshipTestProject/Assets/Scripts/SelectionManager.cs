using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectionManager : MonoBehaviour
{
    RaycastHit2D hit;
    public List<Transform> selectedUnits = new List<Transform>();
    bool isDragging = false;
    public static bool moving = false;
    private Vector2 newPos;
    Vector3 mousePosition;

    private void OnGUI()
    {
        if (isDragging)
        {
            var rect = ScreenHelper.GetScreenRect(mousePosition, Input.mousePosition);
            ScreenHelper.DrawScreenRect(rect, new Color(0.8f, 0.8f, 0.95f, 0.1f));
            ScreenHelper.DrawScreenRectBorder(rect, 2f, Color.grey);
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mousePosition = Input.mousePosition;
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            newPos = worldPoint;
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);
            if (hit.collider.tag == "Player")
            {
                SelectUnits(hit.transform, Input.GetKey(KeyCode.LeftShift));
            }
            else
            {
                isDragging = true;
            }
            if (hit.collider.tag == "Ground")
            {
                for (int i = 0; i < selectedUnits.Count; i++)
                {
                    if (Vector2.Distance(selectedUnits[i].transform.position, newPos) != 0)
                    {
                        moving = true;
                    }
                }
            }
        }
        for (int i = 0; i < selectedUnits.Count; i++)
        {
            if (Vector2.Distance(selectedUnits[i].transform.position, newPos) == 0)
            {
                moving = false;
            }
            else
            {
                moving = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            soilderUnselect();
        }
        if (moving)
        {
            for (int i = 0; i < selectedUnits.Count; i++)
            {
                selectedUnits[i].transform.position = Vector2.MoveTowards(selectedUnits[i].transform.position, newPos, 5f * Time.deltaTime);
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            //DeselectUnits();
            foreach (var selectableObject in FindObjectsOfType<BoxCollider2D>())
            {
                if (IsWithinSelectionBounds(selectableObject.transform))
                {
                    SelectUnits(selectableObject.transform, true);
                }
            }
            isDragging = false;
        }
    }
    
    public void SelectUnits(Transform unit, bool isMultiSelect = false)
    {
        if (!isMultiSelect)
        {
            DeselectUnits();
        }if (unit.tag == "Player")
        {
            selectedUnits.Add(unit);
            unit.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }
        //unit.Find("Highlight").gameObject.SetActive(true);
    }
    public void DeselectUnits()
    {
        for (int i = 0; i < selectedUnits.Count; i++)
        {
            selectedUnits[i].transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
            //selectedUnits[i].Find("Highlight").gameObject.SetActive(false);             
        selectedUnits.Clear();
    }
    private bool IsWithinSelectionBounds(Transform transform)
    {
        if (!isDragging)
        {
            return false;
        }
        var camera = Camera.main;
        var viewportBounds = ScreenHelper.GetViewportBounds(camera, mousePosition, Input.mousePosition);
        return viewportBounds.Contains(camera.WorldToViewportPoint(transform.position));
    }

    public List <Transform> getList()
    {
        return selectedUnits;
    }

    public void soilderUnselect()
    {
        moving = false;
        DeselectUnits();
    }
}