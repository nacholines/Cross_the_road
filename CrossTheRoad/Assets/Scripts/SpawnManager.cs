using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject carPrefab;
    [SerializeField]
    private GameObject playerPrefab;
    public Transform[] spawnPosition;
    public float spawnTime;

    void Start()
    {
        StartCoroutine(spawnCar(spawnTime, carPrefab, 2));
        spawnTime = Random.Range(3, 5);
        SpawnStartCars(carPrefab);
        //TODO spawn two cars per line, in random x values
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

    private void SpawnStartCars(GameObject car)
    {
        float ypos = spawnPosition[0].position.y;
        Vector3 pos = new Vector3(-4, ypos, spawnPosition[0].position.z);
        CarMovement startCar1 = Instantiate(car, pos, Quaternion.identity).GetComponent<CarMovement>();
        startCar1.SetDirection(true);
        pos.x = 0;
        CarMovement startCar2 = Instantiate(car, pos, Quaternion.identity).GetComponent<CarMovement>();
        startCar2.SetDirection(true);

        ypos = spawnPosition[2].position.y;
        pos = new Vector3(-4, ypos, spawnPosition[2].position.z);
        CarMovement startCar3 = Instantiate(car, pos, Quaternion.identity).GetComponent<CarMovement>();
        startCar3.SetDirection(true);
        pos.x = 0;
        CarMovement startCar4 = Instantiate(car, pos, Quaternion.identity).GetComponent<CarMovement>();
        startCar4.SetDirection(true);

        Quaternion rotation = Quaternion.Euler(0, 180, 0);
        ypos = spawnPosition[1].position.y;
        pos = new Vector3(4, ypos, spawnPosition[1].position.z);
        CarMovement startCar5 = Instantiate(car, pos, rotation).GetComponent<CarMovement>();
        startCar3.SetDirection(true);
        pos.x = 1;
        CarMovement startCar6 = Instantiate(car, pos, rotation).GetComponent<CarMovement>();
        startCar4.SetDirection(true);
    }

    public Player SpawnPlayer()
    {
        return Instantiate(playerPrefab, Vector3.zero, Quaternion.identity).GetComponent<Player>();
    }
}
