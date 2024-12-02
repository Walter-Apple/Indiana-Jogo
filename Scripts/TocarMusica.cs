using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TocarMusica : MonoBehaviour
{
    [SerializeField] AudioSource musica;

    //public AudioClip Musica;
    
    private void Start()
    {
        //musica.clip = Musica;
        musica.Play();
    }
}
