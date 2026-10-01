using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float velocidade = 2f;
    void Update()
    {
        Move();
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
