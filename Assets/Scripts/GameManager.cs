using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TMP_Text textoInimigo;

    private int pontosInimigoAtual = 0;
    private int pontosChefeAtual = 0;

    private int pontosInimigoAlvo = 25;
    private int pontosChefeAlvo = 1;

    public GameObject Enemy;
    public GameObject Boss;

    private void Start()
    {
        AtualizarPlacar();
        InvokeRepeating("SpawnEnemy", 0f, 3f);
        
    }


    public void GanharPontoInimigo()
    {
        pontosInimigoAtual++;
        AtualizarPlacar();
        if (pontosInimigoAtual == pontosInimigoAlvo)
        {
            CancelInvoke("SpawnEnemy");
            SpawnBoss();
        }
    }

    public void GanharPontoChefe()
    {
        pontosChefeAtual++;
        if(pontosChefeAlvo == pontosChefeAtual)
        {
            Invoke(nameof(LoadVitoria), 2f);
        }
    }

    private void LoadVitoria()
    {
        SceneManager.LoadScene("Vitoria");
    }

    private void LoadDerrota()
    {
        SceneManager.LoadScene("Derrota");
    }

    private void AtualizarPlacar()
    {
        string textoPontos = "Inimigos Derrotados: " + pontosInimigoAtual + "/" + pontosInimigoAlvo;
        textoInimigo.text = textoPontos;
    }

    private void SpawnEnemy()
    {
        var position = new Vector3(12f, Random.Range(-3.25f, 3.25f), 0);
        var enemy = Instantiate(Enemy, position, Enemy.transform.rotation);
        
    }

    private void SpawnBoss()
    {
        var position = new Vector3(12f, 0, 0);
        var enemy = Instantiate(Boss, position, Quaternion.identity);
    }

}
