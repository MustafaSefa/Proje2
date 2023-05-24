using UnityEngine;

public class Turret_Spawner : MonoBehaviour
{
    public GameObject TurretPrefab;
    public Transform[] spawnPoint;
    public float interval;
    void Start()
    {
        InvokeRepeating("Spawn",0.5f,interval);
    }
    private void Spawn()
    {
        int randPos = Random.Range(0, spawnPoint.Length);
        GameObject newTurret = Instantiate(TurretPrefab, spawnPoint[randPos].position, Quaternion.identity);
    }
}
