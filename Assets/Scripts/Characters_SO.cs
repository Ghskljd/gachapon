using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "Character")]
public class Characters_SO : BaseScriptableObject, IComparable<Characters_SO>
{
    public Rarity rarity;
    public string Name;
    public Sprite sprite;
    public bool unlocked;

    public int CompareTo(Characters_SO other)
    {
        if (other == null) return 1;
        return rarity.CompareTo(other.rarity);
    }
}

public enum Rarity
{
    Common,
    Uncommon,
    Rare,
    UltraRare,
    UnicornRare,
    Burnt
}
