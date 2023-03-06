using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Yandex : MonoBehaviour
{
    
    [SerializeField] TextMeshProUGUI userName;
    [SerializeField] RawImage userPhoto;
    [DllImport("__Internal")]
    private static extern void Hello();
    [DllImport("__Internal")]
    private static extern void GiveMeUserInfo();


   

    public void SetName(string name)
    {
        if (name == "") name = "Player 4321";
        userName.text = name;
        Debug.Log("получено имя пользователя");
    }
    public void SetPhoto(string url)
    {
        StartCoroutine(DownloadImage(url));
        Debug.Log("получено фото пользователя");
    }
    IEnumerator DownloadImage(string mediaUrl)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(mediaUrl);
        yield return request.SendWebRequest();
        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
            Debug.Log(request.error);
        else
            userPhoto.texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
    }

    // Update is called once per frame
    public void HelloButton()
    {
        Hello();
        GiveMeUserInfo();
    }
}
