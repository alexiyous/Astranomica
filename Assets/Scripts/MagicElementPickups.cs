using UnityEngine;

public class MagicElementPickups : MonoBehaviour
{
    public bool isFire;
    public bool isLightning;
    public bool isWater;

    private SpellSlotManager slotManager;

    private void Start()
    {
        slotManager = FindObjectOfType<SpellSlotManager>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Detect ad pickup");
            if (isFire)
            {
                slotManager.AddMagicElement("Fire");
            }
            else if (isWater)
            {
                slotManager.AddMagicElement("Water");
            }
            else if (isLightning)
            {
                slotManager.AddMagicElement("Lightning");
            }

        }
    }
}
