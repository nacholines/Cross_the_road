using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject carPrefab;
    public Transform[] spawnPosition;
    public float spawnTime = Random.Range(3, 5);
    public Player player;

    void Start()
    {
        StartCoroutine(spawnCar(spawnTime, carPrefab, 2));
    }

    private IEnumerator spawnCar(float interval, GameObject car, int dontSpawn)
    {
        yield return new WaitForSeconds(interval);
        int ran = Random.Range(0, spawnPosition.Length);
        while (ran == dontSpawn)
        {
            ran = Random.Range(0, spawnPosition.Length);
        }
        dontSpawn = ran;
        Transform pos = spawnPosition[ran];
        CarMovement newCar = Instantiate(car, pos).GetComponent<CarMovement>();
        if (pos.position.x < 0)
        {
            newCar.SetDirection(true);
        }
        else
        {
            newCar.SetDirection(false);
        }
        StartCoroutine(spawnCar(interval, car, ran));
    }

    public Player SpawnPlayer()
    {
        Instantiate(player, Vector3.zero, Quaternion.identity);
        return player;
    }
}
