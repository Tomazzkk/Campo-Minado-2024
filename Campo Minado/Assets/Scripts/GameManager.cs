using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    Campo[,] campos;
   [SerializeField  ] GameObject CampoPrefab;
    const int diametroDoCampo = 5;
    private void Start()
    {
        GerarCampoMinado();
    }
    void GerarCampoMinado()
    {
        campos = new Campo[diametroDoCampo, diametroDoCampo];

        for(int i = 0; i < diametroDoCampo; i++)
        {
            for (int j = 0; j < diametroDoCampo; j++)
            {  
            Campo campo = Instantiate(CampoPrefab, new Vector2(i ,j ), Quaternion.identity).GetComponent<Campo>() ;
            campos[i, j] = campo; 
            }   
        }
    }
}
