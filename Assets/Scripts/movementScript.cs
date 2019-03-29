using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementScript : MonoBehaviour{
    //Criando variaveis para representarem a velocidade de movimento, rotação e força do pulo
    public float movementSpeed;
    public float rotacionSpeed;
    public float forceJump;
    //Variavel booleana para representar se o cubo está no ar ou não
    bool jumping;

    // Função inicial, chamada assim que o jogo é rodado, antes da primeira atualização de quadro
    void Start(){
        // Setando os valores para as variaveis que faram parte do cubo assim que o jogo se inicia
        movementSpeed = 0.2f;
        rotacionSpeed = 3.0f;
        forceJump = 80f;
        jumping = false;
    }

    // função de atualização, é chamada uma vez por quadro
    void Update(){

        // Se o botão W for apertado, mover o cubo para frente
        if (Input.GetKey(KeyCode.W)){
            transform.Translate(0, 0, movementSpeed);
        }

        // Se o botão S for apertado, mover o cubo para tras
        if (Input.GetKey(KeyCode.S)){
            transform.Translate(0, 0, -movementSpeed);
        }

        // Se o botão A for apertado, girar o cubo em sentido anti horario
        if (Input.GetKey(KeyCode.A)){
            transform.Rotate(0, rotacionSpeed, 0);
        }

        // Se o botão D for apertado, girar o cubo em sentido horario     
        if (Input.GetKey(KeyCode.D)){
            transform.Rotate(0, -rotacionSpeed, 0);
        }

        // Se o botão E for apertado, mover o cubo para a direita
        if (Input.GetKey(KeyCode.E)){
            this.gameObject.transform.position += this.gameObject.transform.right * movementSpeed;
        }

        // Se o botão Q for apertado, mover o cubo para a esquerda
        if (Input.GetKey(KeyCode.Q)){
            this.gameObject.transform.position += this.gameObject.transform.right * -movementSpeed;
        }

        // Se botão Espaço for apertado e o cubo não estiver pulando(Não estiver em contato com o plano),
        // aplica uma força para o cubo pular
        if (Input.GetKey(KeyCode.Space) && !jumping){
            this.gameObject.GetComponent<Rigidbody>().AddForce(this.gameObject.transform.up * forceJump);
        }

        // Se o cubo cair do plano(Eixo y < -10), Fazer o cubo voltar para sua posição inicial
        if (this.gameObject.transform.position.y < -10){
            this.gameObject.transform.position = new Vector3(0, 3, 0);
        }
    }

    void OnCollisionEnter(Collision col){
    // Se o cubo estiver em contato com o chão, a variavel pulando se torna falsa
        // floor é a tag adicionada para representar o chão(plano)
        if (col.gameObject.tag == "floor"){
            jumping = false;

            // Apenas mostra essa mensagem no log
            Debug.Log("jumping false");
        }
    }

    void OnCollisionExit(Collision col){
    // Se o cubo não estiver em contato com o chão, a variavel pulando se torna verdadeira
        // floor é a tag adicionada para representar o chão(plano)
        if (col.gameObject.tag == "floor"){
            jumping = true;

            // Apenas mostra essa mensagem no log
            Debug.Log("jumping true");
        }
    }

    private void OnCollisionStay(Collision col){
        // Se o cubo entrar em contato com algum objeto que tenha a tag "maca" atrelada, esse objeto será destruido
        if (col.gameObject.tag == "maca"){
            Destroy(col.gameObject);
        }
    }
}
