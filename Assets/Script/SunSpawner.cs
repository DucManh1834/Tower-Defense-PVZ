using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunSpawner : MonoBehaviour
{
    public GameObject sunObject;
    private void Start()
    {
        SpawnSun();
    }
    void SpawnSun()
    {
        GameObject mySun = Instantiate(sunObject, new Vector3(Random.Range(-5f, 8f), 6, 0), Quaternion.identity);
        //vi tri roi anh nang
        mySun.GetComponent<Sun>().dropToYPos = Random.Range(2f, -3f);

        Invoke("SpawnSun", Random.Range(7, 14));
    }
}
