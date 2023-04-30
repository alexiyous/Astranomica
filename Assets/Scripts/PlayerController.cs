using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool isMoving;
    private bool turnRight = true;
    public bool allSlotReady = false;
    public bool canCastFire = false;
    public bool canCastWater = false;
    public bool canCastLightning = false;
    public bool canCastNothing = false;
    public bool pickUpElements = false;

    private Vector2 origPos, targetPos;

    private float timeToMove = 0.2f;
    public float limitRight;
    public float limitLeft;

    public int playerPickUpCounter = 0;

    private Rigidbody2D playerRB;
    public SpellSlotManager slotManager;
    public GameManager gameManager;

    private void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerRB.position = transform.position;
    }


    // Update is called once per frame
    void Update()
    {
        PlayerMovementInput();

        if (allSlotReady)
        {
            if (Input.GetKeyUp(KeyCode.W))
            {
                CastingSpell();
                allSlotReady = false;
                playerPickUpCounter = 0;
                gameManager.canSpawnRandom = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            pickUpElements = true;
            playerPickUpCounter += 1;
        }
    }

    /// <summary>
    /// Change what player facing too
    /// </summary>
    private void TurnPlayerSide(bool side)
    {
        if (side)
        {
            transform.localScale = new Vector2(1f, 1f);
        } else
        {
            transform.localScale = new Vector2(-1f, 1f);
        }
    }

    /// <summary>
    /// Take input and execute movement
    /// </summary>
    private void PlayerMovementInput()
    {
        if (transform.position.x < limitRight)
        {
            if (Input.GetKeyDown(KeyCode.D) && !isMoving)
            {
                turnRight = true;
                TurnPlayerSide(turnRight);
                StartCoroutine(MovePlayer(Vector2.right));
            }
        }

        if (transform.position.x > limitLeft)
        {
            if (Input.GetKeyDown(KeyCode.A) && !isMoving)
            {
                turnRight = false;
                TurnPlayerSide(turnRight);
                StartCoroutine(MovePlayer(Vector2.left));
            }
        }
    }
    
    /// <summary>
    /// Move the player
    /// </summary>
    private IEnumerator MovePlayer(Vector2 direction)
    {
        isMoving = true;

        float elapsedTime = 0;

        origPos = playerRB.position;
        targetPos = origPos + direction;

        while (elapsedTime < timeToMove)
        {
            playerRB.MovePosition(Vector2.Lerp(origPos, targetPos, (elapsedTime / timeToMove)));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        playerRB.position = targetPos;

        isMoving = false;
    }


    public void CastingSpell()
    {
        if (canCastFire)
        {
            Debug.Log("FIRE!");
            canCastFire = false;
            slotManager.currentMagic.Clear();
            slotManager.DeleteSlotUI();
        }
        else if (canCastWater)
        {
            Debug.Log("Water");
            canCastWater = false;
            slotManager.currentMagic.Clear();
            slotManager.DeleteSlotUI();
        }
        else if (canCastLightning)
        {
            Debug.Log("Lightning");
            canCastLightning = false;
            slotManager.currentMagic.Clear();
            slotManager.DeleteSlotUI();
        }
        else if (canCastNothing)
        {
            Debug.Log("Nothing");
            canCastNothing = false;
            slotManager.currentMagic.Clear();
            slotManager.DeleteSlotUI();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (pickUpElements)
        {
            Debug.Log("Detect");
            if (collision.gameObject.CompareTag("FirePickUp"))
            {
                slotManager.AddMagicElement("Fire");
                pickUpElements = false;
                gameManager.pickedUp = true;
                Debug.Log(pickUpElements);
            }

            if (collision.gameObject.CompareTag("WaterPickUp"))
            {
                slotManager.AddMagicElement("Water");
                pickUpElements = false;
                gameManager.pickedUp = true;
            }

            if (collision.gameObject.CompareTag("LightningPickUp"))
            {
                slotManager.AddMagicElement("Lightning");
                pickUpElements = false;
                gameManager.pickedUp = true;
            }
        }
    }
}
