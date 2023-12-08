using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyWeapon : MonoBehaviour
{
    public Vector3 attackOffset;
    public float attackRange = 1f;
    public string targetTag; // Tag do objeto que o inimigo pode atacar
    public string nextSceneName; // Nome da próxima cena

    public void Attack()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange);

        if (colInfo != null && colInfo.CompareTag(targetTag))
        {
            Destroy(colInfo.gameObject); // Destruir o objeto com a tag especificada
            ChangeScene(); // Trocar de cena
        }
    }

    private void ChangeScene()
    {
        // Troque para a próxima cena
        SceneManager.LoadScene(0);
    }
}
