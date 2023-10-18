using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    private float speed;
    //dat ten bien gan toc do zombile di chuyen, public cho phep chia se tinh chinh o ngoai( tat la cong khai), float so thuc 1.1,1.2,2.2...
    //kieu float co the dai dien trong cac gia tri nam khoan 1,5 x 10 -45 den 3,4 x 10 38 
    private int health;
    //gan kha nang chui dung sat thuong khi bien mat, int so nguyen -1,2,3...kich thuoc kieu int thuong la 4 bytes (32 bits)...

    private int damage;
    //sat thuong
    private float range;
    //pham vi tan cong
    public ZombileType type;

    public LayerMask plantMask;

    private float eatCooldown;
    //an thoi gian hoi chieu

    private bool canEat = true;

    public Plant targetPlant;

    private AudioSource source;

    public AudioClip[] groans;
    //zombie gao

    public bool LastZombile;

    public bool dead;

    private void Start()
    {
        health = type.headth;
        speed = type.speeed;
        damage = type.damage;
        range = type.range;
        eatCooldown = type.eatCooldown;

        source = GetComponent<AudioSource>();
        //am thanh
        GetComponent<SpriteRenderer>().sprite = type.sprite;
        Invoke("Groan", Random.Range(1f, 20f));
    }

    void Groan()
    {
        source.PlayOneShot(groans[Random.Range(0, groans.Length)]);
    }
    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left, range, plantMask);
        if (hit.collider)
        {
            targetPlant = hit.collider.GetComponent<Plant>();
            Eat();
        }
    }
    void Eat()
    {
        if (!canEat || !targetPlant)
            return;
        canEat = false;

        Invoke("ResetEatCooldown", eatCooldown);
        targetPlant.Hit(damage);
    }
    void ResetEatCooldown()
    {
        canEat = true;
    }
    private void FixedUpdate()
    //provate(rieng tu)
    {
        if (!targetPlant)
            transform.position -= new Vector3(speed, 0, 0);
        //gan vao speed toc do di chuyen
    }
    public void Hit (int damage, bool freeze)
    {
        source.PlayOneShot(type.hitClips[Random.Range(0, type.hitClips.Length)]);
        //truyen am thanh vao ung vs zombieType
        health -= damage;
        if (freeze)
            Freeze();
        if (health <= 0)
        {
            if (LastZombile) // kiem tra tieu dien con zombie cuoi cung se qua man
                GameObject.Find("GameManager").GetComponent<GameManager>().Win();
            dead = true;
            GetComponent<SpriteRenderer>().sprite = type.deathSprite;
            Destroy(gameObject, 1);
        }
    }
    void Freeze()
    {
        CancelInvoke("UnFreeze");
        GetComponent<SpriteRenderer>().color = Color.blue;
        speed = type.speeed / 2;
        Invoke("UnFreeze", 5);
    }
    void Unfreeze()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
        speed = type.speeed;
    }
}
