using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBox : MonoBehaviour
{
    public DeathScript ds;

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == ("Player"))
        {
            ds.IsDead();
        }
    }
}
