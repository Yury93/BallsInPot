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
    public string[] hasProductPlayerPrefs = new string[4] { "0", "1", "2", "3" };
    public string activeProductPlayerPrefs = "id";
    public int Id => id;
    public Button Button => button;
    public Action<int> OnClickProduct;

 
    public void Init()
    {
        priceText.text = "CTOÈMÎÑÒÜ: " + price;
        resource.sprite = MenuLibrary.instance.GlobalSprites.spriteGold;
        button.onClick.AddListener(Click);
        if (id == Load()) isHasProduct = true;
    }
    public void Click()
    {
        OnClickProduct?.Invoke(id);
    }

    public void SelectProductShop()
    {
        Debug.Log(Load() + " /" + id);
        if (RewardSystem.instance.GetGold.Count >= price && Load() != id && isHasProduct == false)
        {
            isHasProduct = true;
            var product = MenuLibrary.instance.GlobalSkybox.products.First(p => p.id == id);
            product.isHasProduct = true;
            MenuLibrary.instance.GlobalSkybox.ActiveSkybox = product.skybox;
            toogle.gameObject.SetActive(true);
            PlayerPrefs.SetInt(activeProductPlayerPrefs, id);
            RewardSystem.instance.GetGold.TakeResource(price);
            Debug.Log("Ïîêóïêà íîâîãî íåáà");
            Save();
        }
        else if (Load() == id)
        {
            isHasProduct = true;
            var product = MenuLibrary.instance.GlobalSkybox.products.First(p => p.id == id);
            MenuLibrary.instance.GlobalSkybox.ActiveSkybox = product.skybox;
            toogle.gameObject.SetActive(true);
            Debug.Log("âûáîð êóïëåíîãî íåáà");
            PlayerPrefs.SetInt(activeProductPlayerPrefs, id);
            product.activeSkybox = true;
        }
        else
        {
            priceText.text = "HÅÒ ÇÎËÎÒÀ " ;
            Debug.Log("ÍÅÒ ÐÅÑÓÐÑÎÂ");
        }
    }
    public void DeselectProduct()
    {
        toogle.gameObject.SetActive(false);
        var product = MenuLibrary.instance.GlobalSkybox.products.First(p => p.id == id);
        product.activeSkybox = false;
    }
    public void Save()
    {
        PlayerPrefs.SetInt(hasProductPlayerPrefs[id], id);
    }
    public int Load()
    {
       return PlayerPrefs.GetInt(hasProductPlayerPrefs[id]);
    }
}
