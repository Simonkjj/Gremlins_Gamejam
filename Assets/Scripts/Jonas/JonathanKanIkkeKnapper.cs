using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JonathanKanIkkeKnapper : MonoBehaviour
{
    public bool amIOn;
    private Image myIm;

    void Start()
    {
        myIm = GetComponent<Image>();
        amIOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        myIm.enabled = amIOn;
    }

    public void TurnBoolOn()
    {
        amIOn = !amIOn;
    }
}
