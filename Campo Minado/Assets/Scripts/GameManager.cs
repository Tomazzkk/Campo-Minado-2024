using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    Campo[,] campos;
   [SerializeField  ] GameObject campoPrefab;
    const int diametroDoCampo = 5;
    const  int numeroDeBombas = 10;
    private void Start()
    {
        GerarCampoMinado();
    }
    #region Singleton
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
        SpawmBomba();
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
                        quantBombas++;
                    } 
                }
            }
        }  

        if(quantBombas == 0)
        {
            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    if (x + i < diametroDoCampo && y + j < diametroDoCampo && x + i >= 0 && y + j >= 0)
                    {
                        campos[x + i, y + j].Clicado();
                    }
                }
            }
        }
        return quantBombas;
    }

    public void SpawmBomba()
    {
        int quantidadeDeBombas = 0;

        while (quantidadeDeBombas < numeroDeBombas)
        {
            int[] index = new int[2];
            index[0] = Random.Range(0, diametroDoCampo);
            index[1] = Random.Range(0, diametroDoCampo);
            if (campos[index[0], index[1]].bomba == false)
            {
                 campos[Random.Range(0, diametroDoCampo), Random.Range(0, diametroDoCampo)].bomba = true;
                quantidadeDeBombas++;
            }            
           
        }
    }

    public void GameOver()
    {
        for (int i = 0; i < diametroDoCampo; i++)
        {
            for (int j = 0; j < diametroDoCampo; j++)
            {
                if (campos[i, j].bomba)
                {
                    campos[i, j].RevelarBomba();
                }
            }
        }
    }
}
