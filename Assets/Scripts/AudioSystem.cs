using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSystem : MonoBehaviour
{

    public static AudioSystem instance;
    public GlobalAudioClips globalAudioClips;
    [SerializeField] private Sound prefabSound;
    [SerializeField] private Button buttonAudio;
    [SerializeField] private Sound background;
    static List<Sound> sounds;
    private static bool isPlayAudio = true;
    private IEnumerator Start()
    {
        sounds = new List<Sound>();
        yield return new WaitForEndOfFrame();
        var  audiosystems =FindObjectsOfType<AudioSystem>();
        if(audiosystems.Length > 1)
        {
            Destroy(audiosystems[1].gameObject);
        }
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        if (isPlayAudio)
        {
            buttonAudio.image.sprite = MenuLibrary.instance.GlobalSprites.soundOn;
            GetComponent<AudioSource>().enabled = true;
           //var s =  CreateAuido(globalAudioClips.backGround);
           // s.audioSource.loop = true;
        }
        else
        {
            GetComponent<AudioSource>().enabled = false;
            buttonAudio.image.sprite = MenuLibrary.instance.GlobalSprites.soundOff;
        }
        //buttonAudio.onClick.AddListener(SetActiveSounds);
        
    }

    public void SetActiveSounds()
    {
        if (isPlayAudio)
        {
            isPlayAudio = false;
            //var s = FindObjectsOfType<Sound>();
            //if(s.Length > 0)
            //sounds.AddRange(s);
            foreach (var item in sounds)
            {
                if (item)
                {
                    Destroy(item.gameObject);
                }
            }
           
            sounds.Clear();
            buttonAudio.image.sprite = MenuLibrary.instance.GlobalSprites.soundOff;
            GetComponent<AudioSource>().enabled = false;
        }
        else
        {
            GetComponent<AudioSource>().enabled = true;
            isPlayAudio = true;
            //var s =CreateAuido(globalAudioClips.backGround);
            //s.audioSource.loop = true;
            buttonAudio.image.sprite = MenuLibrary.instance.GlobalSprites.soundOn;
        }
        CreateAuido(globalAudioClips.buttonClick);
    }

    public Sound CreateAuido(AudioClip clip)
    {
        if (isPlayAudio)
        {
            Debug.Log(clip.length + " длина аудио");
            var sound = GameObject.Instantiate(prefabSound, transform);
            sounds.Add(sound);
            sound.Play(clip);
            Destroy(sound.gameObject, clip.length);
            return sound;
        }
        else
            return null;
    }
    public Sound CreateAuido(AudioClip clip,float volume)
    {
        if (isPlayAudio)
        {
            Debug.Log(clip.length + " длина аудио");
            var sound = GameObject.Instantiate(prefabSound, transform);
            sound.audioSource.volume = volume;
            sounds.Add(sound);
            sound.Play(clip);
            Destroy(sound.gameObject, clip.length);
            return sound;
        }
        else
            return null;
    }
}
