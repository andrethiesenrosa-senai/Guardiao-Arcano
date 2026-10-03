using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float velocidade = 2f;
    private int vida = 3;
    private GameManager gameManager;
    public GameObject bulletPrefab;
    public Transform origemTiro;

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
            Destroy(gameObject);
        }
    }

    private void Move()
    {

        Vector3 movement = new Vector3(-1,0,0) * velocidade * Time.deltaTime;
        transform.Translate(movement, Space.World);

        Vector3 p = transform.position;
        p.x = Mathf.Clamp(p.x, 0, 7f);
        p.y = Mathf.Clamp(p.y, -4f, 4f);
        transform.position = p;

    }
}
