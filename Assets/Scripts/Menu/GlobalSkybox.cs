using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
[CreateAssetMenu( fileName = "GlobalSkybox", menuName = "GlobalProperty/Skybox")]
public class GlobalSkybox : ScriptableObject
{
    [Serializable]
    public class ProductSkybox
    {
        [SerializeField] public int id;
        [SerializeField] public Material skybox;
        [SerializeField]public bool isHasProduct;//опхнаперемн
    }
    [SerializeField] public List<ProductSkybox> products;
    [SerializeField] public Material defaultSkybox;
    [SerializeField] public Material ActiveSkybox;
}
