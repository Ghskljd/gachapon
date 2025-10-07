using UnityEngine;

public class PullOneButton : BuildingButtonsUI
{
    [SerializeField]
    private int COST = 150;
    protected override void Awake()
    {
        base.Awake();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {

    }

    protected override void OnMouseDown()
    {
        base.OnMouseDown();
        GameManager.Instance.OnPullClicked(COST, 1);
    }
}
