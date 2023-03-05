using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProductShop : MonoBehaviour
{
    [SerializeField] private int id;
    [SerializeField] private GameObject toogle;
    [SerializeField] private int price;
    [SerializeField] private Image resource;
    [SerializeField] private TextMeshProUGUI priceText;
    [SerializeField] private Button button;
    [SerializeField] public bool isHasProduct;
    public string hasProductPlayerPrefs = "hasProductPlayerPrefs";
    public string activeProductPlayerPrefs = "id";
    public int Id => id;
    public Action<int> OnClickProduct;
 
    public void Init()
    {
        priceText.text = "CTOИMОСТЬ: " + price;
        resource.sprite = MenuLibrary.instance.GlobalSprites.spriteGold;
        button.onClick.AddListener(Click);
        if (1 == Load()) isHasProduct = true;
    }
    public void Click()
    {
        OnClickProduct?.Invoke(id);
    }

    public void SelectProductShop()
    {
        if (RewardSystem.instance.GetGold.Count >= price && Load() == 0)
        {
            isHasProduct = true;
            var product = MenuLibrary.instance.GlobalSkybox.products.First(p => p.id == id);
            product.isHasProduct = true;
            MenuLibrary.instance.GlobalSkybox.ActiveSkybox = product.skybox;
            toogle.gameObject.SetActive(true);
            PlayerPrefs.SetInt(activeProductPlayerPrefs, id);
            Debug.Log("Покупка нового неба");
            Save();
        }
        else if (Load() == 1)
        {
            var product = MenuLibrary.instance.GlobalSkybox.products.First(p => p.id == id);
            MenuLibrary.instance.GlobalSkybox.ActiveSkybox = product.skybox;
            toogle.gameObject.SetActive(true);
            Debug.Log("выбор купленого неба");
            PlayerPrefs.SetInt(activeProductPlayerPrefs, id);
        }
        else
        {
            Debug.Log("НЕТ РЕСУРСОВ");
        }
    }
    public void DeselectProduct()
    {
        toogle.gameObject.SetActive(false);
    }
    public void Save()
    {
        PlayerPrefs.SetInt(hasProductPlayerPrefs, 1);
    }
    public int Load()
    {
       return PlayerPrefs.GetInt(hasProductPlayerPrefs);
    }
}
