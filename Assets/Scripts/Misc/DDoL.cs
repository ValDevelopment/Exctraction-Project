using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DDoL : MonoBehaviour
{
    bool exists;
    // Start is called before the first frame update
    void Start()
    {
        if (!exists)
        {
            exists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}