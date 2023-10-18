using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicShooter : MonoBehaviour
{
    public GameObject bullet;
    //vien dan
    public Transform shootOrgin;
    //tam sinh dan ban ra
    public float cooldown;
    //thoi gian ra dan
    private bool canShoot;

    public float range;
    //pham vi
    public LayerMask shootMask;
    private GameObject target;

    public int health = 4;

    private AudioSource source;
    public AudioClip[] shootClips;
    //chi den layer mang ten target
    private void Start()
    {
        source = gameObject.AddComponent<AudioSource>();
        Invoke("ResetCooldown", cooldown);
    }
    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, range, shootMask);
        if (hit.collider)
        {
            target = hit.collider.gameObject;
            Shoot();
        }
    }
    void ResetCooldown()
    {
        canShoot = true;
    }
    void Shoot()
    {
        if (!canShoot)
            return;

        source.PlayOneShot(shootClips[Random.Range(0, shootClips.Length)]);

        canShoot = false;
        Invoke("ResetCooldown", cooldown);
        GameObject myBullet = Instantiate(bullet, shootOrgin.position, Quaternion.identity);

    }
}
