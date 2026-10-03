using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TMP_Text textoInimigo;

    private int pontosInimigoAtual = 0;
    private int pontosChefeAtual = 0;

    private int pontosInimigoAlvo = 25;
    private int pontosChefeAlvo = 1;

    private void Start()
    {
        AtualizarPlacar();
    }

    public void GanharPontoInimigo()
    {
        pontosInimigoAtual++;
        Debug.Log("Estou com " + pontosInimigoAtual + " pontos");
        AtualizarPlacar();

    }

    private void AtualizarPlacar()
    {
        string textoPontos = "Inimigos Derrotados: " + pontosInimigoAtual + "/" + pontosInimigoAlvo;
        textoInimigo.text = textoPontos;
    }

}
