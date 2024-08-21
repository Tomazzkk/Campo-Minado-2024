using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    Campo[,] campos;
   [SerializeField  ] GameObject campoPrefab;
    const int diametroDoCampo = 5;
    private void Start()
    {
        GerarCampoMinado();
    }
    #region
    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    void GerarCampoMinado()
    {
        campos = new Campo[diametroDoCampo, diametroDoCampo];

        for(int i = 0; i < diametroDoCampo; i++)
        {
            for (int j = 0; j < diametroDoCampo; j++)
            {  
            Campo campo = Instantiate(campoPrefab, new Vector2(i ,j ), Quaternion.identity).GetComponent<Campo>() ;
            campos[i, j] = campo; 
            campo.IndexI = i;
            campo.IndexJ = j;
            }   
        }
    }

    public int ChecarEntorno(int x, int y)
    {
        int quantBombas = 0;

        for(int i = -1; i < 3; i++)
        {
            for(int j = -1;j < 3; j++)

            {
                if (x+i < diametroDoCampo && y+j < diametroDoCampo && x+i >= 0 && y+j >= 0)
                {
                    if (campos[x + i, y + j].Bomba)
                    {

                        //é Bomba
                    } 
                }
            }
        }  

        if(quantBombas == 0)
        {

        }
        return quantBombas;
    }
}
