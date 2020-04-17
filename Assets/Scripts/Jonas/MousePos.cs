using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePos : MonoBehaviour
{
    public Grapple myGrap;
    public static Vector2 mousePos;

    void Start()
    {
        myGrap = GetComponentInParent<Grapple>();
    }

    // Update is called once per frame
    void Update()
    {
        GetMousePos();
        MoveMeAround();
    }

    public void GetMousePos()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    public void MoveMeAround()
    {
        transform.position = mousePos;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            myGrap.mouseOverSomething = true;
        }
        else
        {
            myGrap.mouseOverSomething = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        myGrap.mouseOverSomething = false;
    }
}
