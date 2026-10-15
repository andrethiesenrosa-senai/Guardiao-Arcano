using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TMP_Text textoInimigo;

    private int pontosInimigoAtual = 0;
    private int pontosChefeAtual = 0;

    private int pontosInimigoAlvo = 3;
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
        Debug.Log("Estou com " + pontosInimigoAtual + " pontos");
        AtualizarPlacar();
        if (pontosInimigoAtual == pontosInimigoAlvo)
        {
            CancelInvoke("SpawnEnemy");
            SpawnBoss();
        }
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
