using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapple : MonoBehaviour
{
    public DistanceJoint2D rope;

    public bool checker;
    public bool mouseOverSomething;

    public float drawInRate;

    public LayerMask whatToGrappleOn;

    public GameObject grapplePoint;

    void Start()
    {
        grapplePoint.transform.position = transform.position;
        grapplePoint.SetActive(false);
        checker = true;
        mouseOverSomething = false;
        rope = GetComponent<DistanceJoint2D>();
        rope.enabled = false;
    }

    void Update()
    {
        // Shot rope on mouse position
        if (Input.GetMouseButtonDown(0) && checker && mouseOverSomething)
        {
            grapplePoint.SetActive(true);
            grapplePoint.transform.position = MousePos.mousePos;
            rope.autoConfigureDistance = true;
            rope.enabled = true;
            rope.connectedAnchor = MousePos.mousePos;
            rope.autoConfigureDistance = false;
            StartCoroutine(DrawPlayerIn());
            checker = false;
        }

        // Destroy rope
        else if (Input.GetMouseButtonDown(0))
        {
            StopCoroutine(DrawPlayerIn());
            grapplePoint.transform.position = transform.position;
            grapplePoint.SetActive(false);
            rope.enabled = false;
            checker = true;
        }
    }

    public IEnumerator DrawPlayerIn()
    {
        while(rope.distance >= 2)
        {
            rope.distance -= drawInRate;
            yield return new WaitForSeconds(.01f);
        }

        yield return null;
    }
}
