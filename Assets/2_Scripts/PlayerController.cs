
using UnityEngine;

public class PlayController : MonoBehaviour
{
    public float torqueForce = 3f; // 토크의 크기
    [SerializeField] float baseSpeed = 20f;
    [SerializeField] float boostSpeed = 30f;
    private Rigidbody2D rb;
    private SurfaceEffector2D surfaceEffector2D;
    private bool isBoosting = false;
    private bool isRuning = true;

    private enum InputKey
    {
        None,Left,RIght
    }

    private InputKey currentKey = InputKey.None;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        surfaceEffector2D = Object.FindObjectOfType<SurfaceEffector2D>();
    }

    void Update()
    {
        currentKey = Input.GetKey(KeyCode.LeftArrow) ?
            InputKey.Left :
            Input.GetKey(KeyCode.RightArrow) ? InputKey.RIght : InputKey.None;

        isBoosting = Input.GetKey(KeyCode.UpArrow);
    }

    public void GameOVer()
    {
        isRuning = false;
    }

    private void FixedUpdate()
    {
        if (!isRuning) return;

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
         
        surfaceEffector2D.speed = isBoosting ? boostSpeed : baseSpeed;
    } 
}

