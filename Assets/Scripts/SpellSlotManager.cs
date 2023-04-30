using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SpellSlotManager : MonoBehaviour
{
    public List<string> currentMagic;
    public PlayerController player;

    public Image[] elementSlots; // array of Image UI elements representing the magic element slots
    public Sprite slot;
    public Sprite fireSprite; // sprite for the fire magic element
    public Sprite waterSprite; // sprite for the water magic element
    public Sprite lightningSprite; // sprite for the lightning magic element


    private void Start()
    {
        currentMagic = new List<string>(3);
    }

    public void AddMagicElement(string elementType)
    {
        if (currentMagic.Count < 3)
        {
            Debug.Log("Amaan");
            currentMagic.Add(elementType);
            UpdateUI();
            CheckForSpells();
        }
    }

    private void UpdateUI()
    {
        for (int i = 0; i < elementSlots.Length; i++)
        {
            if (i < currentMagic.Count)
            {
                // set the image of the slot to the appropriate magic element sprite based on the corresponding element in the list
                if (currentMagic[i] == "Fire")
                {
                    elementSlots[i].sprite = fireSprite;
                }
                else if (currentMagic[i] == "Water")
                {
                    elementSlots[i].sprite = waterSprite;
                }
                else if (currentMagic[i] == "Lightning")
                {
                    elementSlots[i].sprite = lightningSprite;
                }
            }
        }
    }

    public void CheckForSpells()
    {

        if (currentMagic.Count < 3)
        {
            return;
        }

        player.allSlotReady = true;
        int countFireType = currentMagic.Count(x => x == "Fire");
        int countWaterType = currentMagic.Count(x => x == "Water");
        int countLightningType = currentMagic.Count(x => x == "Lightning");

        if (countFireType >= 3)
        {
            player.canCastFire = true;
            Debug.Log("bisa cast api");
        }
        else if (countWaterType >= 3)
        {
            player.canCastWater = true;
            Debug.Log("bisa cast water");
        }
        else if (countLightningType >= 3)
        {
            player.canCastLightning = true;
            Debug.Log("bisa cast petir");
        }

        if (currentMagic.Count == 3 && currentMagic.Skip(1).Any(e => e != currentMagic[0]))
        {
            Debug.Log("list total 3 & semua berbeda");
            player.canCastNothing = true;
            Debug.Log("bisa cast Nothing");
        }

    }

    public void DeleteSlotUI()
    {
        foreach (Image image in elementSlots)
        {
            image.sprite = slot;
        }
    }
}
