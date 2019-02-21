using System.Collections;
using UnityEngine;

public class OveralMoving : MonoBehaviour
{
    [SerializeField] GameObject enemyGround;
    [SerializeField] private float movingSpeed;
    Vector3 finish = new Vector3(0, 0, -2000);
    void Update()
    {
        if (!IsNullReference())
            StartMoving();
    }

    void StartMoving()
    {
        enemyGround.transform.position = Vector3.MoveTowards(transform.position, finish, movingSpeed);
    }

    bool IsNullReference()
    {
        return enemyGround == null;
    }
}
