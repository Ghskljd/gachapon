using UnityEngine;

[CreateAssetMenu(fileName = "New Building", menuName = "Buildings")]
public class BuildingSO : BaseScriptableObject
{
    public Transform BuildingPrefab;
    public Sprite sprite;
    public int cost;
    public float time;
    public int rate;
}
