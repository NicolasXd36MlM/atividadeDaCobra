using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Menu : MonoBehaviour
{
    [SerializeField]
    public TMP_InputField Largura;  // Campo de texto para a largura do grid
    [SerializeField]
    public TMP_InputField Altura;   // Campo de texto para a altura do grid
    [SerializeField]
    public TMP_InputField Velocidade;  // Campo de texto para a velocidade da cobra

    // Aplica as configura��es definidas pelo jogador no menu
    public void AplicarConfiguracoes()
    {
        int largura = int.Parse(Largura.text);
        int altura = int.Parse(Altura.text);
        float velocidade = float.Parse(Velocidade.text);

        // Define as configura��es no Gerenciador do Jogo
        GameManager.Instancia.DefinirTamanhoGrid(largura, altura);
        GameManager.Instancia.DefinirVelocidadeCobra(velocidade);
    }
    // M�todo chamado pelo bot�o
    public void IniciarJogo()
    {
        // Substitua "NomeDaCena" pelo nome da cena que voc� deseja carregar
        SceneManager.LoadScene("JogoCobra");
    }
}
