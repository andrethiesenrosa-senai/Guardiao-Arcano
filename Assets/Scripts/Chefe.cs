using UnityEngine;

public class Chefe : Inimigo
{
    protected bool movimentoInicial = false;
    protected float time;
    private float valorMinimo = -2f;
    private float valorMaximo = 2f;
    private float direction = 1f;
    protected override void Start()
    {
        vida = 100;
        velocidade = 2f;
        base.Start();
    }

    protected override void MarcarPonto()
    {
        gameManager.GanharPontoChefe(); 
    }
    protected override void Mover()
    {
        if(!movimentoInicial)
        {
            Debug.Log("Movimento Inicila");
            transform.Translate(velocidade * -1 * Time.deltaTime, 0, 0);
            if(transform.position.x < 6f)
            {
                Debug.Log("Estou abaixo de 6?");
                movimentoInicial=true;
            }
        } 
        else
        {
            transform.Translate(0, velocidade * direction * Time.deltaTime, 0);
            if (transform.position.y > 2f )
            {
                direction = -1f; 
            }
            else if (transform.position.y < -2f )
            {
                direction = 1f; 
            }
        }
    }
}
