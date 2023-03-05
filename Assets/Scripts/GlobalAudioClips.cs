using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="AudioClips", menuName = "Property/AudioClips")]
public class GlobalAudioClips : ScriptableObject
{
    public AudioClip backGround, buttonClick, potClick, ballClick, addReward, win, los;
}
