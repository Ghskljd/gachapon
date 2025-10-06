using UnityEngine;

public class PullOneButton : BuildingButtonsUI
{
    [SerializeField]
    private const int COST = 150;
    protected override void Awake()
    {
        base.Awake();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        GameManager.Instance.OnPullClicked(COST, 1);
    }
}
