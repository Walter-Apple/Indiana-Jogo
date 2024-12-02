using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//EditorSceneManager.OpenScene;

public class FimDeJogo : MonoBehaviour
{
    public void Reset()
    {
        SceneManager.LoadScene("Indiana");

    }
    public void Sair()
    {
        SceneManager.LoadScene("Menu");
    }
}
