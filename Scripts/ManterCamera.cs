using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManterCamera : MonoBehaviour
{
    public Transform posicaoCamera;

    private void Update()
    {
        transform.position = posicaoCamera.position;
    }
}
