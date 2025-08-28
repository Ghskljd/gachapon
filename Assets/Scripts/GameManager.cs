using System;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //this textmeshpro variable is just for testing purpose
    [SerializeField]
    private TMP_Text textMeshProGui;
    public static GameManager Instance { get; private set; }

    public event EventHandler<OnClickedArgs> BuildingClicked;
    public event EventHandler RemoveBuildingIcons;
    public event EventHandler PullClicked;

    void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("More than one GameManager instance!");
        }

        Instance = this;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            UnityEngine.Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            worldPos.z = 0f;

            if (Physics2D.OverlapPoint(worldPos) == null)
            {
                RemoveBuildingIcons?.Invoke(this, EventArgs.Empty);
            }
        }
    }

    public void OnClickedBuilding(object sender, OnClickedArgs args)
    {
        BuildingClicked?.Invoke(this, args);
    }

    public void OnPullClicked(object sender, System.EventArgs args)
    {
        //check if they have enough currency first
        PullClicked?.Invoke(this, EventArgs.Empty);
    }

    public void OnCharacterPulled(object sender, PulledCharacterArgs args)
    {
        Debug.Log("Just pulled: " + args.pulledCharacter.rarity + args.pulledCharacter.name);
        textMeshProGui.text = "Just pulled: " + args.pulledCharacter.rarity + args.pulledCharacter.name;
    }
}
