using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControleDeMenu : MonoBehaviour
{
    public CanvasGroup OptionPanel;

    public void Jogar()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = (currentSceneIndex + 1) % SceneManager.sceneCountInBuildSettings;

        SceneManager.LoadScene(nextSceneIndex);
    }

    public void Sair()
    {
        Application.Quit();
        Debug.Log("O Jogador saiu do jogo");
    }
}
