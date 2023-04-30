using UnityEngine;

public class MagicElementPickups : MonoBehaviour
{
    private GameManager gameManager;
    private PlayerController player;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        player = FindObjectOfType<PlayerController>();
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (gameManager.pickedUp && (player.playerPickUpCounter <= 3))
            {
                gameManager.pickedUp = false;
                Destroy(gameObject);
            }
        }
    }

}
