using UnityEngine;
using System.Collections.Generic;

/*
Sled.cs - example sled script
Attach to sled prefab. Modify to match your game's structure.
This example stores durability and upgrades per sled instance.
*/

public class Sled : MonoBehaviour
{
    public int durability = 100;
    public Dictionary<string,int> upgrades = new Dictionary<string,int>();
    private bool invulnerable = false;

    public void SetDurability(int d) {
        durability = d;
        Debug.Log("[Sled] SetDurability => " + durability);
    }

    public void SetInvulnerable(bool v) {
        invulnerable = v;
    }

    public void ApplyUpgrade(string name, int amount) {
        if (!upgrades.ContainsKey(name)) upgrades[name] = 0;
        upgrades[name] += amount;
        Debug.Log($"[Sled] Applied upgrade {name} +{amount}. Total: {upgrades[name]}");
    }

    // Example hook to decrease durability when taking damage
    public void TakeDamage(int dmg) {
        if (invulnerable) return;
        durability -= dmg;
        if (durability <= 0) {
            OnBroken();
        }
    }

    public void OnBroken() {
        Debug.Log("[Sled] Broken!");
        // implement behavior for broken sled
    }

    public void GiveToPlayer() {
        // implement logic to assign this sled to nearest player or spawn for all players
        Debug.Log("[Sled] GiveToPlayer called (implement assignment)");
    }
}
