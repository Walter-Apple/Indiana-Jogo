using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalizarJogo : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            int nextSceneIndex = (currentSceneIndex - 1) % SceneManager.sceneCountInBuildSettings;

            SceneManager.LoadScene(nextSceneIndex);
        }
    }
}
