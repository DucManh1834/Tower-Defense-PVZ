using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New ZombieType", menuName = "Zombie")]
public class ZombileType : ScriptableObject
{
    public int headth;

    public float speeed;

    public int damage;

    public float range = 0.5f;

    public float eatCooldown = 1f;

    public AudioClip[] hitClips;

    public Sprite sprite;
    public Sprite deathSprite;

}
