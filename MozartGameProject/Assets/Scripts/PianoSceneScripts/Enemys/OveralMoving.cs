using System.Collections;
using UnityEngine;

public class OveralMoving : MonoBehaviour
{
    [SerializeField] GameObject enemyGround;

    void Start()
    {
        if(!IsNullReference())
            StartCoroutine(StartMoving());
        else
        {
            enemyGround = gameObject.GetComponent<GameObject>();
            Start();
        }
    }

    void Update()
    {
        if (!IsNullReference())
            StartCoroutine(StartMoving());
    }

    IEnumerator StartMoving()
    {
        yield return new WaitForSeconds(.2f);
        enemyGround.transform.localPosition = new Vector3(0,enemyGround.transform.localPosition.y,enemyGround.transform.localPosition.z -14 * Time.deltaTime);
    }

    bool IsNullReference()
    {
        return enemyGround == null;
    }
}
