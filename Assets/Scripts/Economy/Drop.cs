using UnityEngine;

public class Drop : MonoBehaviour {

    [Header("Read-Only")]
    [SerializeField] private float crystalChance;
    [SerializeField] private float soulChance;
    [SerializeField] private float noneChance;

    GameObject soulPrefab;
    GameObject crystalPrefab;

    int sumWeigth;

    [Header("Customize Drop")]
    [Range(0, 100)]
    [SerializeField] private int crystalWeigth;
    [Range(0, 100)]
    [SerializeField] private int soulWeigth;
    [Range(0, 100)]
    [SerializeField] private int noneWeigth;
    [SerializeField] private int dropAmount;

    private void GetSumWeigth()
    {
        sumWeigth = crystalWeigth + soulWeigth + noneWeigth;
    }

    public void DropResource()
    {
        GetSumWeigth();
        int randomNum = Random.Range(0, sumWeigth);

        if (randomNum <= crystalWeigth)
        {
            TextPopup.CreateSoul(transform.position, dropAmount);
            CrystalManager.Instance.IncreaseCrystal(dropAmount);
        }

        else if (randomNum > crystalWeigth && randomNum <= soulWeigth + crystalWeigth)
        {
            TextPopup.CreateCrystal(transform.position, dropAmount);
            SoulManager.Instance.IncreaseSoul(dropAmount);
        }
    }

    void OnValidate() {
        GetSumWeigth();
        crystalChance = (float)crystalWeigth / (float)sumWeigth;
        soulChance = (float)soulWeigth / (float)sumWeigth;
        noneChance = (float)noneWeigth / (float)sumWeigth;
    }

    


}