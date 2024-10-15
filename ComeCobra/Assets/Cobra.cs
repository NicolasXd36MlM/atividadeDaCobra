using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cobra : MonoBehaviour
{
<<<<<<< Updated upstream
    public List<Vector2> segmentosCobra = new List<Vector2>();  // Lista que armazena os segmentos da cobra
    public Vector2 direcao = Vector2.right;  // Dire��o inicial da cobra
    private float temporizadorMovimento;  // Temporizador que controla o tempo entre movimentos
    private bool viva = true;  // Verifica se a cobra est� viva
=======
    public float velocidade = 5f;
    public float distanciaEntreSegmentos = 0.5f;
    public Vector2 direcao = Vector2.right;
    public Vector2 limiteMapa;  
    public GameObject corpoPrefab;

    private float temporizadorMovimento;
    private bool viva = true;

    [SerializeField] private Transform segmentoPrefab;
    public List<Transform> segmento = new List<Transform>();

>>>>>>> Stashed changes
    public static Cobra Instancia;

    private void Awake()
    {
<<<<<<< Updated upstream
        Instancia = this; // Define esta inst�ncia como a inst�ncia da cobra
    }
    private void Start()
    {
        // Define a posi��o inicial da cobra no meio 
        segmentosCobra.Add(new Vector2(10, 10));
=======
        Instancia = this;
    }

    void Start()
    {
        segmento.Add(this.transform); // Adiciona a cabe�a da cobra na lista
        velocidade = GameManager.Instancia.velocidadeCobra;  // Define a velocidade a partir do GameManager

    }

    public void Inicializar()
    {
        segmento.Clear();
        transform.position = Vector3.zero;
        AdicionarSegmento();
>>>>>>> Stashed changes
    }

    private void Update()
    {
            if (viva)
            {
                temporizadorMovimento += Time.deltaTime;
                if (temporizadorMovimento >= 1f / velocidade)
                {
                    temporizadorMovimento = 0f;
                    Mover();
                }
            }
    }
    private void Mover()
    {
        Vector2 posicaoAnterior = segmento[0].position;
        //transform.Translate(direcao * distanciaEntreSegmentos);

        // Cada segmento segue a posi��o do anterior
        for (int i = 1; i < segmento.Count; i++)
        {
            Vector2 posAnteriorSegmento = segmento[i].position;
            segmento[i].position = posicaoAnterior;
            posicaoAnterior = posAnteriorSegmento;
        }

        // Chama o m�todo do GameManager para mudar a posi��o caso a cobra ultrapasse os limites
        transform.position = GameManager.Instancia.MudarPosicao(transform.position);

    }
    private void AtualizarDirecao()
    {
        // Movimenta��o horizontal (esquerda e direita)
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            direcao.x = -1; // Esquerda
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            direcao.x = 1; // Direita
        }

        // Movimenta��o vertical (cima e baixo)
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            direcao.y = 1; // Cima
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            direcao.y = -1; // Baixo
        }

        // Mover o objeto apenas se houver dire��o
        if (direcao != Vector2.zero)
        {
            Mover(direcao);
        }
        void Mover(Vector2 direcao)
        {
            transform.Translate(direcao.normalized * velocidade * Time.deltaTime);
        }
    }


    private void OnTriggerEnter2D(Collider2D colisao)
    {
        if (colisao.CompareTag("Maca"))
        {
            Crescer();
            Destroy(colisao.gameObject);  // Ma�� consumida
            maca.Instancia.RecriarMaca();  // Gera uma nova ma��
        }
        else if (colisao.CompareTag("Segmento"))
        {
            Debug.Log("A cobra se comeu e morreu :C");
            viva = false;
        }
    }

    private bool ColidiuComSegmento()
    {
        // Verifica se a cabe�a colidiu com algum segmento do corpo
        for (int i = 1; i < segmento.Count; i++)
        {
            if (Vector2.Distance(transform.position, segmento[i].position) < distanciaEntreSegmentos)
            {
                return true;
            }
        }
        return false;
    }


    public void AdicionarSegmento()
    {
        // Adiciona um novo segmento na posi��o do �ltimo segmento
        Transform novoSegmento = Instantiate(segmentoPrefab);
        novoSegmento.position = segmento[segmento.Count - 1].position;
        segmento.Add(novoSegmento);
    }

    public void Crescer()
    {
        Transform ultimoSegmento = segmento[segmento.Count - 1];
        Transform novoSegmento = Instantiate(corpoPrefab, ultimoSegmento.position, Quaternion.identity).transform;
        segmento.Add(novoSegmento);
    }
    private void TerminarJogo()
    {
         Debug.Log("Fim de jogo!");
    }
}