using System;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PlayerController : MonoBehaviour
{
    private float velocidade = 4f;
    private int vida = 5;
    public GameObject bulletPrefab;
    public Transform posicaoSaidaTiro;

    public HudVida hudVida;

    private void Start()
    {
        AtualizarVida();
    }
    void Update()
    {
        Move();
        Tiro();
    }

    private void Tiro()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bulletPrefab, posicaoSaidaTiro.position, Quaternion.identity);
        }
    }

    public void TakeDamage()
    {
        vida--;
        AtualizarVida();
        // TODO Atualizar o canvas de vida do jogador.
        
        if (vida <= 0) {
            Destroy(gameObject);
            // TODO Carregar a Cena de Derrota.
        }
    }

    private void Move()
    {
        // Pega o input do jogador e movimenta o Transform. 
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");
        Vector3 campledMovement = Vector3.ClampMagnitude(new Vector3(xAxis, yAxis, 0), 1);
        Vector3 movement = campledMovement * velocidade * Time.deltaTime;
        transform.Translate(movement);

        // Garante que o personagem não saia da tela. 
        Vector3 p = transform.position;
        p.x = Mathf.Clamp(p.x, -7f, 7f);
        p.y = Mathf.Clamp(p.y, -4f, 4f);
        transform.position = p;
    }

    private void AtualizarVida()
    {
        hudVida.AtualizaVida(vida);
    }
}
