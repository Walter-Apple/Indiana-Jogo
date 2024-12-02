using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoDoJogador : MonoBehaviour
{
    // referência ao componente "Character Controller"
    public CharacterController oCharacterController;

    // controla a velocidade de movimento do jogador
    public float velocidadeDoJogador;

    // controla o a altura do pulo do jogador
    public float alturaDoPuloDoJogador;

    // controla a força da gravidade aplicada no jogador
    public float gravidadeDoJogador;

    // referência ao gameObject "Verificador de Chão"
    public Transform verificadorDeChao;

    // controla o tamanho da esfera de checagem de chão
    public float alcanceDoVerificador;

    // diz para a Unity qual é a layer que ela deve interpretar como chão
    public LayerMask layerDoChao;

    // nos fornece um controle sobre a velocidade vertical do jogador
    private Vector3 velocidadeDeQueda;

    // nos permite saber se o jogador está ou não no chão
    private bool estaNoChao;
    // Update is called once per frame
    void Update()
    {
        // roda o método "MoverJogador"
        MoverJogador();

        // roda o método "Pular"
        Pular();

        // roda o método "Aplicar Gravidade"
        AplicarGravidade();
    }

    private void MoverJogador()
    {
        // armazena os inputs "Horizontais" e "Verticais" do teclado (A/D e W/S)
        float movimentoX = Input.GetAxis("Horizontal");
        float movimentoZ = Input.GetAxis("Vertical");

        // calcular o movimento final do jogador (tanto o movimento horizontal, quanto o vertical)
        Vector3 movimentoFinal = transform.right * movimentoX + transform.forward * movimentoZ;

        // aplica o movimento final ao componente "Character Controller"
        oCharacterController.Move(movimentoFinal * velocidadeDoJogador * Time.deltaTime);
    }

    private void Pular()
    {
        // verifica se apertamos a "barra de espaço" e se o jogador está no chão
        if (Input.GetButtonDown("Jump") && estaNoChao)
        {
            // aplica um valor positivo para o eixo "y" da variável "velocidadeDeQueda" (que depois usamos para subir o jogador)
            velocidadeDeQueda.y = Mathf.Sqrt(alturaDoPuloDoJogador * -2f * gravidadeDoJogador);
        }
    }

    private void AplicarGravidade()
    {
        // dá o valor de "true" para a variável "estaNoChao" se estivermos no chão, e "false" se não estivermos
        estaNoChao = Physics.CheckSphere(verificadorDeChao.position, alcanceDoVerificador, layerDoChao);
        // Debug.Log(estaNoChao);

        // verifica se o jogador está no chão e se ele está indo para baixo
        if (estaNoChao && velocidadeDeQueda.y < 0)
        {
            // garante que o jogador sempre esteja indo para baixo (garante que a gravidade sempre seja aplicada)
            velocidadeDeQueda.y = -2f;
        }

        // aplica a força da gravidade na variável "velocidadeDeQueda" a cada segundo que se passa
        velocidadeDeQueda.y += gravidadeDoJogador * Time.deltaTime;

        // aplica o valor final da "velocidadeDeQueda" no jogador
        oCharacterController.Move(velocidadeDeQueda * Time.deltaTime);
    }
}