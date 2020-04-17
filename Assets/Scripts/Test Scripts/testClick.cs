using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class testClick : MonoBehaviour
{
    public GameObject Prefab;
    public bool isClicked;

    private void Start()
    {
        isClicked = false;
    }

    void Clicked()
    {
        isClicked = true;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && (isClicked == true))
        {
            Vector3 spawnPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            spawnPosition.z = 0.0f;
            GameObject objectInstance = Instantiate(Prefab, spawnPosition, Quaternion.Euler(new Vector3(0, 0, 0)));
        }
    }
}
