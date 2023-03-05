using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MenuLibrary : MonoBehaviour
{
    public static MenuLibrary instance;
    public GlobalSprites GlobalSprites;
    public GlobalSkybox GlobalSkybox; 
    private void Awake()
    {
       List<MenuLibrary> menuLibrary = FindObjectsOfType<MenuLibrary>().ToList();
        if(menuLibrary.Count > 1)
        {
            Destroy( menuLibrary.Last().gameObject);
        }
        
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        
    }
}
