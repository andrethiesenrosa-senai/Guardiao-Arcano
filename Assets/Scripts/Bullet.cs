using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float velocidade = 8f;
    public bool isGoingRight = true;
    void Update()
    {
        Move();    
    }

    private void Move()
    {
        // Mover a bala na direção do booleano. 
        float direction;
        if (isGoingRight)
        {
            direction = 1f;
        } else
        {
            direction = -1f;
        }
        Vector3 movement = new Vector3(direction, 0, 0) * velocidade * Time.deltaTime;
        transform.Translate(movement, Space.World);


        // Destruir a Bala quando sair da tela. 
        if(Mathf.Abs(transform.position.x) > 14f)
        {
            Destroy(gameObject);
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(gameObject.CompareTag(collision.tag))
        {
            // Destroi a propria bala
            Destroy(gameObject);

            // Aqui vamos colocar o dano. 
            if(collision.tag == "Enemy")
            {
                collision.gameObject.GetComponent<Inimigo>().TakeDamage();
            } else if (collision.tag == "Player")
            {
                collision.gameObject.GetComponent<PlayerController>().TakeDamage();
            }
 
        }
    }
}
