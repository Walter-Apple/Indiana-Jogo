using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoDoJogador : MonoBehaviour
{
    // refer�ncia ao componente "Character Controller"
    public CharacterController oCharacterController;

    // controla a velocidade de movimento do jogador
    public float velocidadeDoJogador;

    // controla o a altura do pulo do jogador
    public float alturaDoPuloDoJogador;

    // controla a for�a da gravidade aplicada no jogador
    public float gravidadeDoJogador;

    // refer�ncia ao gameObject "Verificador de Ch�o"
    public Transform verificadorDeChao;

    // controla o tamanho da esfera de checagem de ch�o
    public float alcanceDoVerificador;

    // diz para a Unity qual � a layer que ela deve interpretar como ch�o
    public LayerMask layerDoChao;

    // nos fornece um controle sobre a velocidade vertical do jogador
    private Vector3 velocidadeDeQueda;

    // nos permite saber se o jogador est� ou n�o no ch�o
    private bool estaNoChao;
    // Update is called once per frame
    void Update()
    {
        // roda o m�todo "MoverJogador"
        MoverJogador();

        // roda o m�todo "Pular"
        Pular();

        // roda o m�todo "Aplicar Gravidade"
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
        // verifica se apertamos a "barra de espa�o" e se o jogador est� no ch�o
        if (Input.GetButtonDown("Jump") && estaNoChao)
        {
            // aplica um valor positivo para o eixo "y" da vari�vel "velocidadeDeQueda" (que depois usamos para subir o jogador)
            velocidadeDeQueda.y = Mathf.Sqrt(alturaDoPuloDoJogador * -2f * gravidadeDoJogador);
        }
    }

    private void AplicarGravidade()
    {
        // d� o valor de "true" para a vari�vel "estaNoChao" se estivermos no ch�o, e "false" se n�o estivermos
        estaNoChao = Physics.CheckSphere(verificadorDeChao.position, alcanceDoVerificador, layerDoChao);
        // Debug.Log(estaNoChao);

        // verifica se o jogador est� no ch�o e se ele est� indo para baixo
        if (estaNoChao && velocidadeDeQueda.y < 0)
        {
            // garante que o jogador sempre esteja indo para baixo (garante que a gravidade sempre seja aplicada)
            velocidadeDeQueda.y = -2f;
        }

        // aplica a for�a da gravidade na vari�vel "velocidadeDeQueda" a cada segundo que se passa
        velocidadeDeQueda.y += gravidadeDoJogador * Time.deltaTime;

        // aplica o valor final da "velocidadeDeQueda" no jogador
        oCharacterController.Move(velocidadeDeQueda * Time.deltaTime);
    }
}