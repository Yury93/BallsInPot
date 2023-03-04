using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button3D : MonoBehaviour
{
    public bool IsBlockClick { get; private set; }
    public Action<Button3D> OnSelect;

    public void BlockClick(bool result)
    {
        IsBlockClick = result;
    }
    public void Select()
    {
        
        if (IsBlockClick) return;
        OnSelect?.Invoke(this);
        Debug.Log("Select" + " " + gameObject.name);
    }
}
