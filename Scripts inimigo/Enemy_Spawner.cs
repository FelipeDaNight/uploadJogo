using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_ : MonoBehaviour
{
    [SerializeField]
    Enemy enemy1;
    Transform [] enemys;

    // Start is called before the first frame update
    void Start()
    {
        spawnEnemie();
    }

    // Update is called once per frame
    public void spawnEnemie()
    {
        Instantiate(enemy1,transform.position, Quaternion.identity);
    }
}
