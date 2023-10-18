using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject currentPlant;
    public Sprite currentPlantSprite;
    public Transform tiles;

    public LayerMask tileMask;
    // kiem tra GameObject Gird

    public int suns;
    //dien so mat troi mua cay

    public TextMeshProUGUI sunText;
    // hien thi diem so

    public LayerMask sunMask;
    //xac nhan layer anh nang

    public AudioClip plantSFX;
    private AudioSource source;

    public AudioSource sunSource;
    public AudioClip sunClip;



    private void Start()
    {
        source = GetComponent<AudioSource>();
    }
    public void Win()
    {

        if (SceneManager.GetActiveScene().buildIndex + 1 > SceneManager.sceneCountInBuildSettings - 1)
        {
            SceneManager.LoadScene(0);
            return;
        }
        PlayerPrefs.SetInt("levelSave", SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void BuyPlant(GameObject plant, Sprite sprite)
    {
        currentPlant = plant;
        currentPlantSprite = sprite;
    }
    private void Update()
    {
        sunText.text = suns.ToString();
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, tileMask);

        foreach (Transform tile in tiles)
            tile.GetComponent<SpriteRenderer>().enabled = false;

        if (hit.collider && currentPlant)
        {
            hit.collider.GetComponent<SpriteRenderer>().sprite = currentPlantSprite;
            hit.collider.GetComponent<SpriteRenderer>().enabled = true;

            if (Input.GetMouseButtonDown(0) && !hit.collider.GetComponent<Tile>().hasPlant)
            {
                Plant(hit.collider.gameObject);
            }
        }
        RaycastHit2D sunHit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, sunMask);
        if (sunHit.collider)
        {
            if (Input.GetMouseButtonDown(0))
            {
                sunSource.pitch = Random.Range(0.9f, 1.1f);
                sunSource.PlayOneShot(sunClip);

                suns += 25;
                //cong dien so khi an anh nang
                Destroy(sunHit.collider.gameObject);
            }

        };
        void Plant(GameObject hit)
        {
            source.PlayOneShot(plantSFX);
            GameObject plant = Instantiate(currentPlant, hit.transform.position, Quaternion.identity);
            hit.GetComponent<Tile>().hasPlant = true;
            plant.GetComponent<Plant>().tile = hit.GetComponent<Tile>();
            currentPlant = null;
            currentPlantSprite = null;
        }
    }
    private RaycastHit2D RaycastFromMouse(LayerMask mask)
    {
        return Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, mask);
    }
    
}
