using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public enum EnemyStates { idle, shoot, wait };
    public EnemyStates myState;

    public GameObject player;
    public GameObject bullet;

    public Transform bulPoint;

    public EnemyHitBox myHitBox;

    public bool getPoint;

    public float bulletForce = 2f;

    public Vector3 shootPoint;

    void Start()
    {
        getPoint = true;
        myHitBox = GetComponentInChildren<EnemyHitBox>();
        myState = EnemyStates.idle;
        player = GameObject.FindGameObjectWithTag("Player");
    }


    void Update()
    {
        switch (myState)
        {
            case EnemyStates.idle:
                StartCoroutine(IdleState());
                break;
            case EnemyStates.shoot:
                ShootState();
                break;
            case EnemyStates.wait:
                WaitState();
                break;
            default:
                break;
        }
    }

    public IEnumerator IdleState()
    {
        yield return new WaitForSeconds(5f);
        myState = EnemyStates.shoot;
        getPoint = true;
        yield return null;
    }

    public void ShootState()
    {
        if (myHitBox.playerInRange)
        {
            if (getPoint)
            {
                shootPoint = player.transform.position;
                getPoint = false;
            }
            GameObject clone = Instantiate(bullet, bulPoint.position, Quaternion.identity, transform);
            Destroy(clone, 2f);
            myState = EnemyStates.idle;
        }
        else
        {
            myState = EnemyStates.idle;
        }
    }

    public void WaitState()
    {

    }
}
