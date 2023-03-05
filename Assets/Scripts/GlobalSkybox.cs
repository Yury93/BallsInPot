using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
[CreateAssetMenu( fileName = "GlobalSkybox", menuName = "GlobalProperty/Skybox")]
public class GlobalSkybox : ScriptableObject
{
    [SerializeField] private Material skybox1, skybox2, skybox3;
   [SerializeField] public Material defaultSkybox;
    [SerializeField] public Material ActiveSkybox;
}
