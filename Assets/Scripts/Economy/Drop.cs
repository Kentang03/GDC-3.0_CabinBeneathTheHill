using UnityEngine;

public class Drop : MonoBehaviour {

    [Header("Customize Drop")]
    [Range(0, 1)][SerializeField] private float crystalChance = 1f;
    [SerializeField] private int crystalDropAmount = 1;

    [SerializeField] private int soulDropAmount = 1;

    GameObject soulPrefab;
    GameObject crystalPrefab;

    int sumWeigth;

    public void DropResource()
    {
        TextPopup.CreateSoul(transform.position, soulDropAmount);
        SoulManager.Instance.IncreaseSoul(soulDropAmount);

        float randomChance = GetRandomChance();

        if (randomChance < crystalChance)
        {
            TextPopup.CreateCrystal(transform.position, crystalDropAmount);
            CrystalManager.Instance.IncreaseCrystal(crystalDropAmount);
        }
    }

    private float GetRandomChance()
    {
        return Random.Range(0f, 1f);
    }
}