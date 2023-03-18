using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    Animator animator;

    private Vector2 moveTarget = Vector2.zero;
    [SerializeField]
    double buffer = 2.0;
    [SerializeField]
    float speed = 3.4f;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(Input.GetMouseButton(0))
            moveTarget = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        HandleMove();
        
    }

    private void HandleMove()
    {
        
        float move = 0.0f;
        var distance = Mathf.Abs(transform.position.x - moveTarget.x);
        if (distance > buffer)
        {
            if (moveTarget.x > transform.position.x)
                move = speed;
            else if (moveTarget.x < transform.position.x)
                move = -speed;
        }
        else if(distance != 0)
            Stop();

        rb.velocity =  new Vector2(speed  * move, transform.position.y);

        if (move > 0 && transform.localScale.x > 0 ||
            move < 0 && transform.localScale.x < 0)
            transform.localScale = new Vector3(-transform.localScale.x,
                                                transform.localScale.y, 
                                                transform.localScale.z);

        if (Mathf.Abs(move) <= 0.5)
        {
            if (animator.GetBool("Walking") != false)
                animator.SetBool("Walking", false);
        }
        else
        {
            if (animator.GetBool("Walking") != true)
                animator.SetBool("Walking", true);
        }
    }

    private void OnCollisionStay2D() => Stop();

    public void Stop()
    {
        moveTarget = transform.position;
        rb.velocity = Vector2.zero;
    }
}
