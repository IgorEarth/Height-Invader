using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;

public class InApp : MonoBehaviour
{

    [DllImport("__Internal")]
    private static extern void BuyCrown();
    [DllImport("__Internal")]
    private static extern void CheckCrown();

    public bool HasCrown;

    [SerializeField] TextMeshProUGUI _crownText;

    public static InApp Instance;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            CheckCrown();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void BuyCrownWithButton()
    {
        BuyCrown();
    }
    
    public void SetCrownTrue()
    {
        HasCrown = true;
        _crownText.text = "У тебя есть корона!";
    }
}
