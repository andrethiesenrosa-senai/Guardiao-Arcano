using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PlayerController : MonoBehaviour
{
    private float velocidade = 4f;
    private int vida = 5;
    private int vidaMaxima = 5;
    public GameObject bulletPrefab;
    public Transform posicaoSaidaTiro;
    private bool estaInvencivel = false;
    private bool estaComEscudo = false;
    private SpriteRenderer spriteRenderer;
    public SpriteRenderer escudo;

    public HudVida hudVida;

    private void Start()
    {
        escudo.enabled = estaComEscudo;
        AtualizarVida();
        spriteRenderer = GetComponent<SpriteRenderer>();
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
        if(estaComEscudo)
        {
            estaComEscudo = false;
            escudo.enabled = false;
            return;
        }
        if (estaInvencivel) return;
        vida--;
        AtualizarVida();
        StartCoroutine(AtivarInvencibilide());
        if (vida <= 0) {
            Destroy(gameObject);
            // TODO Carregar a Cena de Derrota.
        }
    }

    private IEnumerator AtivarInvencibilide()
    {
        // Ativamos a Bool de Invencibiliade
        estaInvencivel = true;
        // Criando uma nova cor para o Sprite com Transparência.
        Color transparente =
            new Color(
                spriteRenderer.color.r,
                spriteRenderer.color.g,
                spriteRenderer.color.b,
                0.5f);
        // Atribuindo a cor transparente no SpriteRenderer. 
        spriteRenderer.color = transparente;
        // Aguardo 3 segundos
        yield return new WaitForSeconds(3);
        // Altero Transparência de volta par 1f;
        transparente.a = 1f;
        // Atribuo novamente a cor para o SpriteRenderer
        spriteRenderer.color = transparente;
        // Perco a invencibilidade;
        estaInvencivel = false;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Coletavel"))
        {
            if (collision.GetComponent<Coletaveis>().TipoDeColetavel == TipoDeColetavel.Vida)
            {
                GanharVida();
            }
            if (collision.GetComponent<Coletaveis>().TipoDeColetavel == TipoDeColetavel.Escudo)
            {
                AtivarEscudo();
            }
            Destroy(collision.gameObject);
        }
    }

    private void AtivarEscudo()
    {
        // Mudar o estado do estaComEscudo para true;
        estaComEscudo = true;
        // Ativar a spriterenderer do escudo. 
        escudo.enabled = true;
        Debug.Log("Ativei o Escudo");
    }

    private void GanharVida()
    {
        if(vida < vidaMaxima)
        {
            vida++;
            AtualizarVida();
        }
        Debug.Log("Ganhei uma vida");
    }
}
