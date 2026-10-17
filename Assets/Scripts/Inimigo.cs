using UnityEngine;

public abstract class Inimigo : MonoBehaviour
{
    protected float velocidade = 2f;
    protected int vida = 3;
    protected bool isDead = false;
    [SerializeField] protected GameObject bulletPrefab;
    [SerializeField] protected GameObject explosionPrefab;

    [SerializeField] protected Transform[] origemTiro;
    protected GameManager gameManager;

    protected virtual void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
        IniciarAtaque();
    }

    protected virtual void Update()
    {
        Mover();
    }

    protected abstract void Mover();
    protected virtual void Atirar()
    {
        for (int i = 0; i < origemTiro.Length; i++)
        {
            Instantiate(bulletPrefab, origemTiro[i].position, Quaternion.identity);
        }

    }

    protected virtual void IniciarAtaque()
    {
        InvokeRepeating("Atirar", 3f, 1f);
    }

    public virtual void TakeDamage()
    {
        vida--;
        if(vida <= 0)
        {
            Morrer();
        }
    }

    protected virtual void Morrer()
    {
        if (isDead) return;
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
        MarcarPonto();
        isDead = true;
    }

    protected virtual void MarcarPonto()
    {
        gameManager.GanharPontoInimigo();
    }
}
