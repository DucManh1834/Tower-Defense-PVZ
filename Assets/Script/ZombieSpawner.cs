using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZombieSpawner : MonoBehaviour
{
    public Transform[] SpawnPoint;
    //gan vi tri sinh ra zombile
    public GameObject zombie;
    //game GameOject mang ten zombile
    public ZombieTypeProb[] zombileTypes;

    private List<ZombileType> probList = new List<ZombileType>();

    public int ZombieMax;
    //so luong zombie qua man
    public int ZombiesSpawned;
    //so zombie da ra
    public Slider progressBar;
    //thanh cong cu bao so zombie
    public float ZombieDelay = 5;
    //do tre zombie

    private void Start()
    {
        InvokeRepeating("SpawnZombile", 15, ZombieDelay);
        //goi ham random xuat hien zombile
        foreach (ZombieTypeProb zom in zombileTypes)
        {
            for (int i = 0; i < zom.probability; i++)
                probList.Add(zom.type);
        }
        progressBar.maxValue = ZombieMax;

    }
    private void Update()
    {
        progressBar.value = ZombiesSpawned;
    }

    void SpawnZombile()
    {
        if (ZombiesSpawned >= ZombieMax)
            return;

        ZombiesSpawned++;
        int r = Random.Range(0, SpawnPoint.Length);
        GameObject myZombile = Instantiate(zombie, SpawnPoint[r].position, Quaternion.identity);
        myZombile.GetComponent<Zombie>().type = probList[Random.Range(0, probList.Count)];
        if (ZombiesSpawned >= ZombieMax)
            myZombile.GetComponent<Zombie>().LastZombile = true;

    }
}
[System.Serializable]
public class ZombieTypeProb
{
    public ZombileType type;
    public int probability;
}
