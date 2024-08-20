using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Campo : MonoBehaviour
{
    bool revelada, bomba;
   [SerializeField] Sprite[] spritesVazios;

   public  void Clicado()
    {

        Debug.Log("Clicado");
        if (!revelada) // ! para inverter a bool da variavel
        {
            if (bomba)
            {
                // GameOver()
            }
            else
            {
               // GetComponent<SpriteRenderer>().sprite = spritesVazios[]; 
            }
        }
    }

}
