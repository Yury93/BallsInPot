using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShopPanel : Window
{
    [SerializeField] private List<ProductShop> products;
    private void Start()//перенести в инит
    {
        products.ForEach(p => p.Init());
        products.ForEach(p => p.DeselectProduct());
        products.ForEach(p => p.OnClickProduct += SelectProduct);
        var activeProduct = products.FirstOrDefault(p => p.Id == PlayerPrefs.GetInt(p.activeProductPlayerPrefs));
        if (activeProduct) activeProduct.SelectProductShop();
    }

    private void SelectProduct(int idProduct)
    {
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
    }
}
