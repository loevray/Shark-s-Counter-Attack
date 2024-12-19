using UnityEngine;

public class Exp : MonoBehaviour
{
    [SerializeField] private int expAmount = 1;
    [SerializeField] private float expMoveSpeed = 15f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Update()
    {
        MoveExp();
    }

    void MoveExp()
    {
        transform.position += Vector3.back * expMoveSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("EXP���� �浹 �̺�Ʈ �߻�");
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("EXP���� �÷��̾�� �浹 �̺�Ʈ �߻�");
            Player player = other.gameObject.GetComponent<Player>();
            player.IncreaseExp(expAmount);
            Destroy(gameObject);
        }
    }

}
