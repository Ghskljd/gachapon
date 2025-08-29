using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "Character")]
public class Characters_SO : BaseScriptableObject
{
    public Rarity rarity;
    public string Name;
    public Sprite sprite;
    public bool unlocked;
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
