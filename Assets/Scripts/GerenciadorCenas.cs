using UnityEngine;
using UnityEngine.SceneManagement;

public class GerenciadorCenas : MonoBehaviour
{
    public void CarregarGameplay() => SceneManager.LoadScene("Gameplay");
    public void CarregarVitoria() => SceneManager.LoadScene("Vitoria");
    public void CarregarDerrota() => SceneManager.LoadScene("Dorretoa");
    public void CarregarMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
}
