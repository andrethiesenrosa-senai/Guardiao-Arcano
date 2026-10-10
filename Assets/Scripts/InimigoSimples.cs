using UnityEngine;

public class InimigoSimples : Inimigo
{
    public GameObject coletavelVida;
    public GameObject coletavelEscudo;
    protected override void Start()
    {
        vida = 3;
        velocidade = 2f;

        base.Start();
    }

    protected override void Mover()
    {
        Vector3 movement = new Vector3(-1, 0, 0) * velocidade * Time.deltaTime;
        transform.Translate(movement, Space.World);

        Vector3 p = transform.position;
        p.x = Mathf.Clamp(p.x, 0, 14f);
        p.y = Mathf.Clamp(p.y, -4f, 4f);
        transform.position = p;
    }

    private void SortearColetavel()
    {
        if (Random.value >= 0.8f)
        {
            if (Random.value >= 0.8f)
            {
                Instantiate(coletavelVida, transform.position, Quaternion.identity);
            }
            else
            {
                Instantiate(coletavelEscudo, transform.position, Quaternion.identity);
            }
        }
    }

    protected override void Morrer()
    {
        base.Morrer();
        SortearColetavel();
    }

}
