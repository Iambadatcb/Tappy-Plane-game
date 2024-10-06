using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject pipePrefab;
    public float spawnTime = 2;

    private float lastSpawnTime;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(pipePrefab);
    }

    // Update is called once per frame
    void Update()
    {
        if(lastSpawnTime + spawnTime <= Time.time)
        {
            Instantiate(pipePrefab);
            lastSpawnTime = Time.time;
        }
    }
}
