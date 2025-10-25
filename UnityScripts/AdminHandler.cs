using UnityEngine;

/*
AdminHandler.cs
Attach this to a GameObject named "AdminHandler" in your Unity scene.
This script exposes public methods that can be called from WebGL using:
    gameInstance.SendMessage('AdminHandler','MethodName','optionalParameter');
It provides example implementations for:
 - GiveAllSleds
 - GiveInfinitePresents
 - ToggleInvulnerability
 - SetAllSledDurability (parameter: integer)
 - GiveUpgrade (parameter: "UpgradeName|amount")
You must implement Sled logic (Durability, Upgrades) in your game's Sled class and provide methods called here.
*/

public class AdminHandler : MonoBehaviour
{
    public bool invulnerable = false;

    // Called from JS: give all sleds to players or enable all sleds
    public void GiveAllSleds(string unused = "")
    {
        Debug.Log("[AdminHandler] GiveAllSleds called");
        var sleds = FindObjectsOfType<Sled>();
        foreach(var s in sleds) {
            s.GiveToPlayer(); // implement in Sled
        }
    }

    public void GiveInfinitePresents(string unused = "")
    {
        Debug.Log("[AdminHandler] GiveInfinitePresents called");
        // Example: set all present spawners to high spawn or set player inventory
        var players = FindObjectsOfType<PlayerInventory>();
        foreach(var p in players) {
            p.AddPresents(999999);
        }
    }

    public void ToggleInvulnerability(string unused = "")
    {
        invulnerable = !invulnerable;
        Debug.Log("[AdminHandler] ToggleInvulnerability => " + invulnerable);
        var sleds = FindObjectsOfType<Sled>();
        foreach(var s in sleds) {
            s.SetInvulnerable(invulnerable);
        }
    }

    public void SetAllSledDurability(string arg)
    {
        int dur = 100;
        int.TryParse(arg, out dur);
        Debug.Log("[AdminHandler] SetAllSledDurability => " + dur);
        var sleds = FindObjectsOfType<Sled>();
        foreach(var s in sleds) {
            s.SetDurability(dur);
        }
    }

    // param format: "UpgradeName|amount"
    public void GiveUpgrade(string arg)
    {
        Debug.Log("[AdminHandler] GiveUpgrade => " + arg);
        if(string.IsNullOrEmpty(arg)) return;
        var parts = arg.Split('|');
        if(parts.Length < 2) return;
        string name = parts[0];
        int amount = 0;
        int.TryParse(parts[1], out amount);

        var sleds = FindObjectsOfType<Sled>();
        foreach(var s in sleds) {
            s.ApplyUpgrade(name, amount);
        }
    }
}
