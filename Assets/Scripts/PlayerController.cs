using System;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PlayerController : MonoBehaviour
{
    private float velocidade = 4f;
    public GameObject bulletPrefab;
    public Transform posicaoSaidaTiro;
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

    private void Move()
    {
        // Pega o input do jogador e movimenta o Transform. 
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(xAxis, yAxis, 0).normalized * velocidade * Time.deltaTime;
        transform.Translate(movement);

        // Garante que o personagem não saia da tela. 
        Vector3 p = transform.position;
        p.x = Mathf.Clamp(p.x, -7f, 7f);
        p.y = Mathf.Clamp(p.y, -4f, 4f);
        transform.position = p;
    }
}
