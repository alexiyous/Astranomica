using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Transform movePoint;
    public float moveInterval = 3f;
    public LayerMask stopLayer;

    private Coroutine moveCoroutine;
    private bool isMovingRight = true;

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
            // Check if there is an object with the "stopLayer" layer at the new movePoint position
            Collider2D hit = Physics2D.OverlapCircle(movePoint.position + (isMovingRight ? new Vector3(1f, 0f, 0f) : new Vector3(-1f, 0f, 0f)), 0.1f, stopLayer);
            if (hit != null)
            {
                movePoint.position += new Vector3(0f, -1f, 0f);
                isMovingRight = !isMovingRight;
                Vector3 scale = transform.localScale;
                scale.x *= -1;
                transform.localScale = scale;
            }
            else
            {
                movePoint.position += isMovingRight ? new Vector3(1f, 0f, 0f) : new Vector3(-1f, 0f, 0f);
            }
        }
    }

    // Stop the coroutine when the enemy is disabled
    private void OnDisable()
    {
        StopCoroutine(moveCoroutine);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);
    }
}
