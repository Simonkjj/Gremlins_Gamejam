using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabPoint : MonoBehaviour
{
    public LineRenderer myLine;

    public GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        myLine.GetComponent<LineRenderer>();
        myLine.SetPosition(0, player.transform.position);
        myLine.SetPosition(1, MousePos.mousePos);
    }

    // Update is called once per frame
    void Update()
    {
        myLine.SetPosition(0, player.transform.position);
    }
}
