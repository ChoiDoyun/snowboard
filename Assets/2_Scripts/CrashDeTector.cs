using UnityEngine;

public class Crash : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            Debug.Log("��! ���Ӹ���!");
        }
    }
}
