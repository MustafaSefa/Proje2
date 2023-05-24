using UnityEngine;
using Random = UnityEngine.Random;

public class Soldier_Spawner : MonoBehaviour
{
    public GameObject SoldierPrefab;
    public Transform[] spawnPoint;
    public float interval;
    void Start()
    {
        InvokeRepeating("Spawn",0.001f,interval);
    }
    private void Spawn()
    {
        int randPos = Random.Range(0, spawnPoint.Length);
        GameObject newSoldier = Instantiate(SoldierPrefab, spawnPoint[randPos].position, Quaternion.identity);
    }
}
