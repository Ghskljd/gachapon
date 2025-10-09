using System;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class BuildingsManager : MonoBehaviour
{
    public static BuildingsManager Instance { get; private set; }

    [SerializeField]
    public List<BuildingSO> AllBuildings_SO;
    private List<BuildingSO> PlayersBuildings;
    public event EventHandler BuildingBought;
    public event EventHandler BuildingsManagerApplicationQuit;
    void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("ERROR: More than one buildings manager");
        }

        Instance = this;

        PlayersBuildings = SaveSystem.LoadBuildings() ?? new List<BuildingSO>();
        InstantiateLoadedBuildings();
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

    public void OnApplicationQuit()
    {
        BuildingsManagerApplicationQuit?.Invoke(this, EventArgs.Empty);
        SaveSystem.SaveBuildings(PlayersBuildings);
    }

    public BuildingSO GetBuildingByID(string ID)
    {
        return AllBuildings_SO.Find(x => x.ID == ID);
    }

    private void InstantiateLoadedBuildings()
    {
        foreach (BuildingSO buildingSO in PlayersBuildings)
        {
            Transform building = Instantiate(buildingSO.BuildingPrefab);
            CookieShops cookieShops = building.GetComponent<CookieShops>();
            cookieShops.setTimeRate(buildingSO.time, buildingSO.rate);
        }
    }

    public void InstantiateBuildings(string ID)
    {
        BuildingSO buildingSO = GetBuildingByID(ID);
        if (PlayersBuildings.Contains(buildingSO)) return;

        Transform building = Instantiate(buildingSO.BuildingPrefab);
        CookieShops cookieShops = building.GetComponent<CookieShops>();
        cookieShops.setTimeRate(buildingSO.time, buildingSO.rate);
        PlayersBuildings.Add(buildingSO);

        BuildingBought?.Invoke(this, EventArgs.Empty);
    }
}
