using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Singleton que gerencia o estado do jogo
    public static GameManager Instancia;
    private int larguraGrid;  // Armazena a largura do grid
    private int alturaGrid;   // Armazena a altura do grid
    private float velocidadeCobra;  // Armazena a velocidade da cobra
    private void Awake()  
    {        
        if (Instancia == null)
        {           
            Instancia = this;
            DontDestroyOnLoad(gameObject); 
     }
    else
     {            Destroy(gameObject);  
    
        } 
    
    }
<<<<<<< Updated upstream
=======

    public void IniciarJogo()
    {
        // Verifica se o prefab est� definido e se a ma�� n�o foi instanciada
        if (prefabMaca != null && macaInstanciada == null)
        {
            // Instancia a ma��
            macaInstanciada = Instantiate(prefabMaca);
            // Gera e posiciona a ma��
            macaInstanciada.GetComponent<maca>().RecriarMaca();
        }
        else if (macaInstanciada != null)
        {
            Debug.Log("A ma�� j� foi instanciada.");
        }
        else
        {
            Debug.LogError("Prefab de ma�� n�o est� atribu�do!");
        }
    }
>>>>>>> Stashed changes
    public void DefinirTamanhoGrid(int largura, int altura)
    {
        larguraGrid = largura;
        alturaGrid = altura;
        maca.Instancia.limiteMapa = new Vector2(largura / 2, altura / 2);  // Define os limites da ma��
    }

    public void DefinirVelocidadeCobra(float velocidade)
    {
        velocidadeCobra = velocidade; // Define a velocidade da cobra
    }

  

    // M�todo que retorna uma posi��o na borda do outro lado se a cobra atravessar os limites do mapa
    public Vector2 MudarPosicao(Vector2 posicao)
    {
        if (posicao.x < 0)
            posicao.x = larguraGrid - 1;
        else if (posicao.x >= larguraGrid)
        {
            posicao.x = 0;
        }

        if (posicao.y < 0)
            posicao.y = alturaGrid - 1;
        else if (posicao.y >= alturaGrid)
            posicao.y = 0;

        return posicao;
    }

}
