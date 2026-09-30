using UnityEngine;

public class Parallax : MonoBehaviour
{
    public float velocidade = 0.02f;
    Material mat;

    void Start()
    {
        mat = GetComponent<Renderer>().material;     
    }


    void Update()
    {
        mat.mainTextureOffset += Vector2.right * velocidade * Time.deltaTime;
    }
}
