using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Gacha Pool", menuName = "Gacha Pool")]
public class GachaPool : ScriptableObject
{
    public List<Characters_SO> Common_Characters_SOs;
    public List<Characters_SO> Uncommon_Characters_SOs;
    public List<Characters_SO> Rare_Characters_SOs;
    public List<Characters_SO> Ultra_Rare_Characters_SOs;
    public List<Characters_SO> Unicorn_Rare_Characters_SOs;
    public List<Characters_SO> Burnt_Rare_Characters_SOs;
}
