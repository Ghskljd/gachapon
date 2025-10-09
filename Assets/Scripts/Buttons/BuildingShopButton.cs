using UnityEngine;

public class BuildingShopButton : BuildingButtonsUI
{
    [SerializeField]
    private Transform BuyingBuildingWindow;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Awake()
    {
        base.Awake();
    }
    protected override void Start()
    {
        base.Start();
        BuyingBuildingWindow = GameManager.Instance.BuildingMenu;
    }

    // Update is called once per frame
    void Update()
    {

    }

    protected override void OnMouseDown()
    {
        base.OnMouseDown();
        BuyingBuildingWindow.gameObject.SetActive(true);
    }
}
