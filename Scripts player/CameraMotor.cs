using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class CameraMotor : MonoBehaviour
{
    public Transform olhePara;//Indica a posição para onde a camera deve olhar
    public float boundX = 0.15f;//limite de deslocamento horizontal da camera
    public float boundY = 0.05f;//limite de deslocamento vertical da camera

    private void LateUpdate()//Geralmente usado para ajustar a posição de objetos após
    //todas as atualizações de posição terem ocorrido
    {
        Vector3 delta = Vector3.zero;//variavel q vai armazenar a quantidade que a camera deve se deslocar

        float deltaX = olhePara.position.x - transform.position.x;//Calcula a diferença horizontal entre a posição da 
        //câmera (transform.position.x) e a posição do objeto olhePara.
        if(deltaX > boundX || deltaX < -boundX)//Verifica a diferença horizontal (deltaX) excede o limite definido
        // por boundX
        {
            if(transform.position.x < olhePara.position.x)
            {
                delta.x = deltaX - boundX;
            }   
            else
            {
                delta.x = deltaX + boundX;
            }
        }//Determina a direção do deslocamento horizontal (delta.x) com base na relação entre a 
        //posição da câmera e a posição do objeto olhePara.

        float deltaY = olhePara.position.y - transform.position.y;//Ira fazer os mesmos calculos e verificações so que
        //agora analisando a deiferença vertical
        if(deltaY > boundY || deltaY < -boundY)
        {
            if(transform.position.y < olhePara.position.y)
            {
                delta.y = deltaY - boundY;
            }   
            else
            {
                delta.y = deltaY + boundY;
            }
        }

        transform.position += new Vector3(delta.x, delta.y, 0);//Atualiza a posição da câmera adicionando a quantidade
        // calculada de deslocamento (delta) à posição atual da câmera. O valor em z é mantido como 0, pois a 
        //câmera normalmente se move apenas no plano xy.
    }
}
