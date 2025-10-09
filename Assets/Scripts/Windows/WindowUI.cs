using UnityEngine;

public class WindowUI : MonoBehaviour
{
    [SerializeField]
    protected Transform DisplayUIPrefab;
    [SerializeField]
    protected Transform ContentArea;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public virtual void Exit()
    {
        gameObject.SetActive(false);
    }
}
