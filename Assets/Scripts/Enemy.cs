using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float velocidade = 2f;
    private int vida = 3;
    private GameManager gameManager;
    public GameObject bulletPrefab;
    public Transform origemTiro;
    public GameObject explosion;

    public GameObject coletavelVida;
    public GameObject coletavelEscudo;

    private void Start()
    {
        InvokeRepeating("Atirar", 1f, 1f);
        
        gameManager = FindFirstObjectByType<GameManager>();
    }
    void Update()
    {
        Move();
    }

    private void Atirar()
    {
        Instantiate(bulletPrefab, origemTiro.position, Quaternion.identity);
    }

    public void TakeDamage()
    {
        vida--;
        if (vida == 0)
        {
            gameManager.GanharPontoInimigo();
            
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
            SortearColetavel();
        }
    }

    private void SortearColetavel()
    {
        if(Random.value >= 0.8f)
        {
            if(Random.value >= 0.8f)
            {
                Instantiate(coletavelVida, transform.position, Quaternion.identity);
            } else {
                Instantiate(coletavelEscudo, transform.position, Quaternion.identity);
            }
        }
    }

    private void Move()
    {

        Vector3 movement = new Vector3(-1,0,0) * velocidade * Time.deltaTime;
        transform.Translate(movement, Space.World);

        Vector3 p = transform.position;
        p.x = Mathf.Clamp(p.x, 0, 14f);
        p.y = Mathf.Clamp(p.y, -4f, 4f);
        transform.position = p;

    }
}
