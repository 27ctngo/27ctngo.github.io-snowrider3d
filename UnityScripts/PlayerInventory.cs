using UnityEngine;

/*
PlayerInventory.cs - simple example to receive presents
Attach to player object
*/
public class PlayerInventory : MonoBehaviour
{
    public int presents = 0;

    public void AddPresents(int amount) {
        presents += amount;
        Debug.Log($"[PlayerInventory] Added presents: {amount}. Total: {presents}");
    }
}
