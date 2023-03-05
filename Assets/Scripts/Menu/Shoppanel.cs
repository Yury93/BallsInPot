using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShopPanel : Window
{
    [SerializeField] private List<ProductShop> products;
    [SerializeField] private Menu menu;
    public override void Open()
    {
        base.Open();
        var globalAudio = AudioSystem.instance.globalAudioClips;
        AudioSystem.instance.CreateAuido(globalAudio.buttonClick);
            }
    public void Init()
    {
        products.ForEach(p => p.Init());
        products.ForEach(p => p.DeselectProduct());
        products.ForEach(p => p.OnClickProduct += SelectProduct);
        var activeProduct = products.FirstOrDefault(p => p.Id == PlayerPrefs.GetInt(p.activeProductPlayerPrefs));
        if (activeProduct) activeProduct.SelectProductShop();
    }

    private void SelectProduct(int idProduct)
    {
        var globalAudio = AudioSystem.instance.globalAudioClips;
        AudioSystem.instance.CreateAuido(globalAudio.buttonClick);

        products.ForEach(p => p.DeselectProduct());
        var selectedProduct = products.First(p => p.Id == idProduct);
        if (selectedProduct.isHasProduct)
        {
            selectedProduct.SelectProductShop();
        }
        else
        {
            
            selectedProduct.SelectProductShop();
            var activeProduct = products.FirstOrDefault(p => p.Id == PlayerPrefs.GetInt(p.activeProductPlayerPrefs));
            if (activeProduct) activeProduct.SelectProductShop();

            
        }
        menu.RefreshResourceInfo();
      
    }
    public override void Close()
    {
        base.Close();
        var globalAudio = AudioSystem.instance.globalAudioClips;
        AudioSystem.instance.CreateAuido(globalAudio.buttonClick);
    }
}
