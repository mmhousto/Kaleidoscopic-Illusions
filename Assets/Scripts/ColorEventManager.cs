using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorEventManager: MonoBehaviour
{
    public delegate void OnColorChange();
    public static event OnColorChange onColorChange;


    public static void CallOnColorChange()
    {
        if (onColorChange != null) { onColorChange(); }
    }
}
