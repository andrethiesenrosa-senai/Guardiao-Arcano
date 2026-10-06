using UnityEngine;
using UnityEngine.UI;

public class HudVida : MonoBehaviour
{
    public Sprite vidaCheia;
    public Sprite vidaVazia;
    public Image[] images = new Image[5];


    public void AtualizaVida(int vidadohud)
    {
        for (int i = 0; i < images.Length; i++)
        {
            //if(i < vidadohud)
            //{
            //    images[i].sprite = vidaCheia;
            //} else
            //{
            //    images[i].sprite = vidaVazia;
            //}
            images[i].sprite = i < vidadohud ? vidaCheia : vidaVazia;
        }
        Debug.Log("Vida do jogador: " + vidadohud);
    }

}
