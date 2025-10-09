using System;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class BuildingsManager : MonoBehaviour
{
    public static BuildingsManager Instance { get; private set; }

    [SerializeField]
    public List<BuildingSO> AllBuildings_SO;
    public event EventHandler BuildingBought;
    public event EventHandler BuildingsManagerApplicationQuit;
    void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("ERROR: More than one buildings manager");
        }

        Instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        BuildingBought += UIManager.Instance.OnWindowChange;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public BuildingSO GetBuildingByID(string ID)
    {
        return AllBuildings_SO.Find(x => x.ID == ID);
    }

    public void InstantiateBuildings(string ID)
    {
        BuildingSO buildingSO = GetBuildingByID(ID);
        Transform building = Instantiate(buildingSO.BuildingPrefab);
        CookieShops cookieShops = building.GetComponent<CookieShops>();
        cookieShops.setTimeRate(buildingSO.time, buildingSO.rate);
        BuildingBought?.Invoke(this, EventArgs.Empty);
    }
}
