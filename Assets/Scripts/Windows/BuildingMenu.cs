using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BuildingMenu : WindowUI
{
    void Awake()
    {
        gameObject.SetActive(false);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnEnable()
    {
        DisplayBuildings();
    }

    private void DisplayBuildings()
    {
        List<BuildingSO> buildings = BuildingsManager.Instance.AllBuildings_SO;
        foreach (BuildingSO building in buildings)
        {
            Transform createdBuilding = Instantiate(DisplayUIPrefab);

            UnityEngine.UI.Image imageSprite = createdBuilding.GetComponent<UnityEngine.UI.Image>();
            TMP_Text text = createdBuilding.GetComponentInChildren<TMP_Text>();
            BuildingDisplay buildingDisplay = createdBuilding.GetComponent<BuildingDisplay>();

            imageSprite.sprite = building.sprite;
            text.text = "$" + building.cost.ToString();
            buildingDisplay.SetID(building.ID);

            createdBuilding.transform.SetParent(ContentArea);
        }
    }

    public override void Exit()
    {
        foreach (Transform child in ContentArea.transform)
        {
            Destroy(child.gameObject);
        }

        base.Exit();
    }
}
