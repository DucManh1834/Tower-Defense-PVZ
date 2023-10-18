using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunFlower : MonoBehaviour
{
    public GameObject sunObject;
    public float Cooldown;
    private void Start()
    {
        InvokeRepeating("SpawnSun", Cooldown, Cooldown);
    }
    void SpawnSun()
    {
        GameObject mySun = Instantiate(sunObject, new Vector3(transform.position.x + Random.Range(-0.5f, 0.5f), transform.position.y + Random.Range(0f, 0.5f), 0), Quaternion.identity);
        mySun.GetComponent<Sun>().dropToYPos = transform.position.y - 1;
    }
}
