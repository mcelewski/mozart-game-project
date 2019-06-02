using System.Collections;
using UnityEngine;

public class OveralMoving : MonoBehaviour
{
    
    [SerializeField] private float movingSpeed;
    [SerializeField] GameObject enemyGround;
    Vector3 finish = new Vector3(0, 0, -2000);
    ///<summary>
    /// Change platform moving speed
    ///</summary>
    // TODO: Add Property to UI
    public float EnemySpeed
    {
        get { return movingSpeed;}
        set { movingSpeed = value;}
    }
    void Update()
    {
        if (!IsNullReference())
        {
            StartMoving();
        }
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
