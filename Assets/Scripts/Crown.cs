using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crown : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        if (InApp.Instance.HasCrown)
        {
            GetComponent<Renderer>().enabled = true;
        }
#endif
    }


}
