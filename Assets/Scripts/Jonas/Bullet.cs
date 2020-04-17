using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public EnemyScript myParent;

    void Start()
    {
        myParent = GetComponentInParent<EnemyScript>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, myParent.shootPoint, myParent.bulletForce);
    }
}
