using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManterMusica : MonoBehaviour
{
    public static ManterMusica instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
    }
}
