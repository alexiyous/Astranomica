using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpellSlotManager : MonoBehaviour
{
    public List<string> currentMagic;
    public PlayerController player;

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
            CheckForSpells();
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
}
