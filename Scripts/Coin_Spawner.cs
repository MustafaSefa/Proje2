using UnityEngine;
public class Coin_Spawner : MonoBehaviour
{
    public GameObject CoinPrefab;
    public Transform[] SpawnPoint;
    private void Start()
    {
        InvokeRepeating("Spawn", 0.0001f, 5.4f);
    }
    void Spawn()
    {
        for(int i = 0; i <= 20; i++)
        {
            Instantiate(CoinPrefab, SpawnPoint[i].position, Quaternion.identity);
        }
    }
}