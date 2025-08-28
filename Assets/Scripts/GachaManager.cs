using System;
using System.Collections.Generic;
using UnityEngine;

public class GachaManager : MonoBehaviour
{
    [SerializeField]
    private List<GachaPool> GachaBanners;
    private int indexOfGachaBanners;
    private GachaPool currentGachaPool;

    public event EventHandler<PulledCharacterArgs> PulledCharacter;

    void Awake()
    {
        indexOfGachaBanners = UnityEngine.Random.Range(0, GachaBanners.Count);
        InvokeRepeating("SwitchBanners", 0f, 5f * 60f * 60f);
    }

    void Start()
    {
        GameManager.Instance.PullClicked += OnPullClicked;
        PulledCharacter += GameManager.Instance.OnCharacterPulled;
    }

    private void SwitchBanners()
    {
        Debug.Log("switching banners");
        indexOfGachaBanners = (indexOfGachaBanners + 1) % GachaBanners.Count;
        currentGachaPool = GachaBanners[indexOfGachaBanners];
    }

    private void OnPullClicked(object sender, System.EventArgs e)
    {
        int randomNum = UnityEngine.Random.Range(1, 101);

        switch (randomNum)
        {
            default:
            case >= 1 and < 61:
                CommonPulled();
                break;
            case >= 61 and < 91:
                UncommonPulled();
                break;
            case >= 91 and < 98:
                RarePulled();
                break;
            case >= 98 and < 100:
                UltraRarePulled();
                break;
            case 100:
                UURPulled();
                break;
        }
    }

    private void CommonPulled()
    {
        int randomNum = UnityEngine.Random.Range(0, currentGachaPool.Common_Characters_SOs.Count);

        PulledCharacter?.Invoke(this, new PulledCharacterArgs
        {
            pulledCharacter = currentGachaPool.Common_Characters_SOs[randomNum]
        });
    }

    private void UncommonPulled()
    {
        int randomNum = UnityEngine.Random.Range(0, currentGachaPool.Uncommon_Characters_SOs.Count);

        PulledCharacter?.Invoke(this, new PulledCharacterArgs
        {
            pulledCharacter = currentGachaPool.Uncommon_Characters_SOs[randomNum]
        });
    }

    private void RarePulled()
    {
        int randomNum = UnityEngine.Random.Range(0, currentGachaPool.Rare_Characters_SOs.Count);

        PulledCharacter?.Invoke(this, new PulledCharacterArgs
        {
            pulledCharacter = currentGachaPool.Rare_Characters_SOs[randomNum]
        });
    }

    private void UltraRarePulled()
    {
        int randomNum = UnityEngine.Random.Range(0, currentGachaPool.Ultra_Rare_Characters_SOs.Count);

        PulledCharacter?.Invoke(this, new PulledCharacterArgs
        {
            pulledCharacter = currentGachaPool.Ultra_Rare_Characters_SOs[randomNum]
        });
    }

    private void UURPulled()
    {
        int randomNum = UnityEngine.Random.Range(0, 2);
        switch (randomNum)
        {
            default:
            case 0:
                int randomRangeUnicorn = UnityEngine.Random.Range(0, currentGachaPool.Unicorn_Rare_Characters_SOs.Count);
                PulledCharacter?.Invoke(this, new PulledCharacterArgs
                {
                    pulledCharacter = currentGachaPool.Unicorn_Rare_Characters_SOs[randomRangeUnicorn]
                });
                break;
            case 1:
                int randomRangeBurnt = UnityEngine.Random.Range(0, currentGachaPool.Burnt_Rare_Characters_SOs.Count);
                PulledCharacter?.Invoke(this, new PulledCharacterArgs
                {
                    pulledCharacter = currentGachaPool.Burnt_Rare_Characters_SOs[randomRangeBurnt]
                });
                break;
        }
    }

    private void OnDestroy()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.PullClicked -= OnPullClicked;
            PulledCharacter -= GameManager.Instance.OnCharacterPulled;
        }
    }
}
public class PulledCharacterArgs : EventArgs
{
    public Characters_SO pulledCharacter;
}
