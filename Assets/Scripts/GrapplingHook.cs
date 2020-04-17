using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingHook : MonoBehaviour
{
    [Header("Grappling hook stuff")]
    private DistanceJoint2D disjoint;

    public Vector2 mousePos;

    void Start()
    {
        disjoint = GetComponent<DistanceJoint2D>();
    }

    void Update()
    {
        //Mathf.Clamp(disjoint.distance, 2.5f, 5);
        disjoint.anchor = new Vector2(transform.position.x, transform.position.y);
        disjoint.connectedAnchor = mousePos;
    }

    private void OnMouseDown()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
