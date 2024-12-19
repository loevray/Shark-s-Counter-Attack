using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float enemyMoveSpeed = 15f;
    [SerializeField] private int enemyHealthPoint = 10;
    [SerializeField] private float enemyDeleteThreshold = -30f;

    public event Action<int> enemyHpChange;  // HP ���� �̺�Ʈ
    public event Action enemyDead;     // �� ��� �̺�Ʈ
    static public event Action ExpDrop; //�� ������ �̺�Ʈ



    private void Start()
    {
        

    }
    void Update()
    {
        MoveEnemy();
        deleteOutEnemy();
    }

    void MoveEnemy()
    {
        transform.position += Vector3.back * enemyMoveSpeed * Time.deltaTime;
    }

    void deleteOutEnemy()
    {
        if (transform.position.z < enemyDeleteThreshold)
        {
            Destroy(gameObject);
        }
    }

    //����� �浹 �� ü�±�� 0���ϰ��Ǹ� ����ġ���� ���� �� �ı�
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Weapon")
        {
            Weapon weapon = other.gameObject.GetComponent<Weapon>();
            enemyHealthPoint -= weapon.damage;
            if (enemyHealthPoint < 0)
            {
                ExpDrop?.Invoke();
                Destroy(gameObject);
            }
        }
    }





}


