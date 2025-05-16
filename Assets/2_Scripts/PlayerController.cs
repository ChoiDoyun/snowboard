
using UnityEngine;

public class PlayController : MonoBehaviour
{
    public float torqueForce = 3f; // 토크의 크기
    private Rigidbody2D rb;

    private enum InputKey
    {
        None,Left,RIght
    }

    private InputKey currentKey = InputKey.None;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        currentKey = Input.GetKey(KeyCode.LeftArrow) ?
            InputKey.Left :
            Input.GetKey(KeyCode.RightArrow) ? InputKey.RIght : InputKey.None;
    }

    private void FixedUpdate()
    {
        switch (currentKey)
        {
            case InputKey.Left:
                rb.AddTorque(torqueForce);
                break;
            case InputKey.RIght:
                rb.AddTorque(-torqueForce);
                break;
            default:
                // Do nothing
                break;
        }
    } 
}

