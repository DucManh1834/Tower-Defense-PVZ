using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class PlantSlot : MonoBehaviour
{
    public Sprite plantSprite;
    //noi chua hinh anh icon
    public GameObject plantObject;
    //noi nhan cay
    public int price;
    //noi diem so tuy chinh de mua icon
    public Image Icon;
    //noi chua icon
    public TextMeshProUGUI priveText;
    //noi chua diem so can thiet de mua icon
    private GameManager gms;
    private void Start()
    {
        gms = GameObject.Find("GameManager").GetComponent<GameManager>();
        GetComponent<Button>().onClick.AddListener(BuyPlant);
    }
    private void BuyPlant()
    {
        if (gms.suns >= price && !gms.currentPlant)
        {
            gms.suns -= price;
            gms.BuyPlant(plantObject, plantSprite);
        }

    }
    private void OnValidate()
    {
        if (plantSprite)
        {
            Icon.enabled = true;
            Icon.sprite = plantSprite;
            priveText.text = price.ToString();
        }
        else
        {
            Icon.enabled = false;
        }
    }
}
