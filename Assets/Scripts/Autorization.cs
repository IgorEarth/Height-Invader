using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Autorization : MonoBehaviour
{
    [DllImport("__Internal")]

    private static extern void AuthExtern();

    public void AutorizationButton()
    {
        
        AuthExtern();
    }
}
