using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Campo : MonoBehaviour
{
    bool revelada, bomba;
   [SerializeField] Sprite[] spritesVazios;

    int indexI, indexJ;

    public int IndexI { get => indexI; set => indexI = value; }
    public int IndexJ { get => indexJ; set => indexJ = value; }
    public bool Bomba { get => bomba;}

    public  void Clicado()
    {

        Debug.Log("Clicado");
        if (!revelada) // ! para inverter a bool da variavel no caso o "revelado" fica falso
        {
            if (bomba)
            {
                // GameOver()
            }
            else
            {
                GetComponent<SpriteRenderer>().sprite = spritesVazios[GameManager.instance.ChecarEntorno(indexI, indexJ)]; 
            }
        }
    }

}
