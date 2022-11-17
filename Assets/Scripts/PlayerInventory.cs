using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public int NumberOfShrooms { get; private set; }

    public void ShroomsCollected()
    {
        NumberOfShrooms++;
    }
}