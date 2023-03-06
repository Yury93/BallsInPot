using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Loader : MonoBehaviour
{
    public List<LocalisationEntity> localisation;
    public string pathLocalization;
    private void Start()
    {
        CreateLocalisation();
    }
    private void CreateLocalisation()
    {
        var path = Application.dataPath + pathLocalization;
        List<LocalisationEntity> languages;
       languages = CreateEntitiesFromExel<LocalisationEntity>(path).ToList();
       
        LocalizationSystem.Init(languages);


    }
    public static List<T> CreateEntitiesFromExel<T>(string path)
    {
        TextAsset txt = new TextAsset();
        txt = (TextAsset)Resources.Load(path, typeof(TextAsset));

        List<T> createdClasses = new List<T>();
        string tableData = txt.text;
        // Debug.Log(path);
        var list = CSVSerializer.ParseCSV(tableData, ',');
        var total = CSVSerializer.Deserialize<T>(list);
        createdClasses = total.ToList();

        return createdClasses;

    }
}
