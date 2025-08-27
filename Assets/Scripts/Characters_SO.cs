using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "Character")]
public class Characters_SO : ScriptableObject
{
    public Rarity rarity;
    public string Name;
    public Sprite sprite;
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
