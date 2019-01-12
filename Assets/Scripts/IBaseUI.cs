using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public abstract class IBaseUI:MonoBehaviour
{
    public GameObject root;
    public  virtual void Show()
    {
        root.SetActive(true);
    }

    public virtual void Hide()
    {
        root.SetActive(false);
    }

}
