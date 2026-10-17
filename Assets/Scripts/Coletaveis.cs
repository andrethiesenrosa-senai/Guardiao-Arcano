using UnityEngine;

public enum TipoDeColetavel { Escudo, Vida };

public class Coletaveis : MonoBehaviour
{
    public TipoDeColetavel TipoDeColetavel;

    public float duracao;

    private void Start()
    {
        Destroy(gameObject, duracao);
    }

    private void Update()
    {
        transform.Translate(-1f * 4f * Time.deltaTime, 0, 0);
    }


}
