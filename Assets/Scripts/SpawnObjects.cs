using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    public GameObject[] objs;
    public int random;
    public Transform[] spawnPos;

    private void Start()
    {
        SpawnBlocks();
    }
    void SpawnBlocks()
    {
        random = Random.Range(0, objs.Length);
        Instantiate(objs[1], spawnPos[1].transform.position, Quaternion.identity);
        Instantiate(objs[2], spawnPos[2].transform.position, Quaternion.identity);
        Instantiate(objs[3], spawnPos[3].transform.position, Quaternion.identity);
    }
}
