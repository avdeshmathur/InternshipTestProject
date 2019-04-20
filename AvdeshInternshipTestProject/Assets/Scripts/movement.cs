using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    bool facingRight = false;
    public bool isSelected = false;
    Vector2 newPos;


    void Update()
    {

        if (transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled == true)
        {
            isSelected = true;
        }
        if (transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled == false)
        {
            isSelected = false;
        }
        Vector3 mousePosition = Input.mousePosition;
        Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);

        //if (Input.GetMouseButtonDown(0) /*&& hit.collider.tag == "Player"*/)

        if (Input.GetMouseButtonDown(0) && hit.collider.tag == "Ground" && isSelected || hit.collider.tag == "Path" || hit.collider.tag == "Rock" || hit.collider.tag == "Water" || hit.collider.tag == "Player")
        {
            newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (transform.position.x < newPos.x && facingRight) 
            {
                flip();
            }
            else if (transform.position.x > newPos.x && !facingRight)
            {
                flip();
            }
        }
    }


    public void flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}