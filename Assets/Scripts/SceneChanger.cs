using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void Scene1() {
        SceneManager.LoadScene("Créditos");
    }

    public void Scene2() {
        SceneManager.LoadScene("Mapa");
    }

    public void Scene3() {
        SceneManager.LoadScene("Menu Inicial");
    }

    public void Scene4() {
        SceneManager.LoadScene("Personagem");
    }

    public void Scene5() {
        SceneManager.LoadScene("Cenário");
    }

    public void Quit() {
        Application.Quit();
    }
}
