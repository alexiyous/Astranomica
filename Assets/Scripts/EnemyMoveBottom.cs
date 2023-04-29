using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveBottom : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Transform movePoint;
    public float moveInterval = 3f; 
    private Coroutine moveCoroutine; 

    // Start is called before the first frame update
    void Start()
    {
        movePoint.parent = null;
        moveCoroutine = StartCoroutine(MoveMovePoint());
    }

    // Coroutine to move the movePoint every moveInterval seconds
    private IEnumerator MoveMovePoint()
    {
        while (true)
        {
            yield return new WaitForSeconds(moveInterval);
            movePoint.position += new Vector3(0f, -1f, 0f);
        }
    }

    // Stop the coroutine when the enemy is disabled
    private void OnDisable()
    {
        if (moveCoroutine != null)
        {
            StopCoroutine(moveCoroutine);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);
    }
}

