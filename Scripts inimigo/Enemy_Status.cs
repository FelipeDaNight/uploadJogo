using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Status : MonoBehaviour
{
    public Animator animator;
    public int vidaMaxima = 100;
    int vidaAtual;
    void Start()
    {
        vidaAtual = vidaMaxima;
    }

    public void TomouDano(int dano)
    {
        vidaAtual -= dano;  

        animator.SetTrigger("Hurt"); 

        if(vidaAtual <= 0)
        {
            Morreu();
        }
    }

    void Morreu()
    {
        Debug.Log("morreu");

        animator.SetBool("EstaMorto",true);

        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }
}
