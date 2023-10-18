using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;
    //sat thuong
    public float speed;
    //toc do ra dan

    public bool freeze;
    //khoi tao kiem tra them chuc nang
    private void Start()
    {
        Destroy(gameObject, 10);
    }
    private void Update()
    {
        transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<Zombie>(out Zombie zombile))
        {
            zombile.Hit(damage, freeze);
            Destroy(gameObject);
        }
    }
}
