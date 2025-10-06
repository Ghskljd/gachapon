using System;
using System.Collections.Generic;
using UnityEngine;

public class GachaManager : MonoBehaviour
{
    public static GachaManager Instance { get; private set; }

    [SerializeField]
    private List<GachaPool> GachaBanners; //ALL OF THE GACHA BANNERS CREATED
    private int indexOfGachaBanners; //THE INDEX OF A GACHA BANNER
    private GachaPool currentGachaPool; //WHICH GACHA BANNER WE ARE ON

    void Awake()
    {
        if(Instance != null)
        {
            Debug.LogError("Error: More than one GachaManager");
        }
        else
        {
            Instance = this;
        }
        //Choose a random gacha banner
        indexOfGachaBanners = UnityEngine.Random.Range(0, GachaBanners.Count);
        //Courotine to switch banners every so often 
        InvokeRepeating("SwitchBanners", 0f, 5f * 60f * 60f);
    }

    void Start()
    {

    }

    //METHOD TO SWITCH BANNERS 
    private void SwitchBanners()
    {
        Debug.Log("switching banners");
        indexOfGachaBanners = (indexOfGachaBanners + 1) % GachaBanners.Count;
        currentGachaPool = GachaBanners[indexOfGachaBanners];
    }

    //EVENT METHOD TO GET CALLED WHEN PULL IS CLICKED
    public List<Characters_SO> OnPullClicked(int pulls)
    {
        List<Characters_SO> pulledCharacters = new List<Characters_SO>();
        for (int i = 0; i < pulls; i++)
        {
            int randomNum = UnityEngine.Random.Range(1, 101);
            switch (randomNum)
            {
                default:
                case >= 1 and < 61:
                    pulledCharacters.Add(CommonPulled());
                    break;
                case >= 61 and < 91:
                    pulledCharacters.Add(UncommonPulled());
                    break;
                case >= 91 and < 98:
                    pulledCharacters.Add(RarePulled());
                    break;
                case >= 98 and < 100:
                    pulledCharacters.Add(UltraRarePulled());
                    break;
                case 100:
                    pulledCharacters.Add(UURPulled());
                    break;
            }
        }

        return pulledCharacters;
    }

    private Characters_SO CommonPulled()
    {
        int randomNum = UnityEngine.Random.Range(0, currentGachaPool.Common_Characters_SOs.Count);

        return currentGachaPool.Common_Characters_SOs[randomNum];

    }

    private Characters_SO UncommonPulled()
    {
        int randomNum = UnityEngine.Random.Range(0, currentGachaPool.Uncommon_Characters_SOs.Count);

        return currentGachaPool.Uncommon_Characters_SOs[randomNum];

    }

    private Characters_SO RarePulled()
    {
        int randomNum = UnityEngine.Random.Range(0, currentGachaPool.Rare_Characters_SOs.Count);

        return currentGachaPool.Rare_Characters_SOs[randomNum];

    }

    private Characters_SO UltraRarePulled()
    {
        int randomNum = UnityEngine.Random.Range(0, currentGachaPool.Ultra_Rare_Characters_SOs.Count);

        return currentGachaPool.Ultra_Rare_Characters_SOs[randomNum];

    }

    private Characters_SO UURPulled()
    {
        int randomNum = UnityEngine.Random.Range(0, 2);
        switch (randomNum)
        {
            default:
            case 0:
                int randomRangeUnicorn = UnityEngine.Random.Range(0, currentGachaPool.Unicorn_Rare_Characters_SOs.Count);
                return currentGachaPool.Unicorn_Rare_Characters_SOs[randomRangeUnicorn];

            case 1:
                int randomRangeBurnt = UnityEngine.Random.Range(0, currentGachaPool.Burnt_Rare_Characters_SOs.Count);
                return currentGachaPool.Burnt_Rare_Characters_SOs[randomRangeBurnt];
        }
    }

    private void OnDestroy()
    {
    }
}

