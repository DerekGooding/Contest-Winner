using UnityEngine;

public class MaskController : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    [SerializeField]
    private bool isMasked = false;
    [SerializeField]
    private float rate = 1.0f;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    private void Update()
    {
        if (isMasked && spriteRenderer.color.a > 0)
            spriteRenderer.color = new Color(spriteRenderer.color.r,
                                             spriteRenderer.color.g,
                                             spriteRenderer.color.b,
                                             spriteRenderer.color.a -
                                             rate * Time.deltaTime); 
        else if(!isMasked && spriteRenderer.color.a < 1)
            spriteRenderer.color = new Color(spriteRenderer.color.r,
                                             spriteRenderer.color.g,
                                             spriteRenderer.color.b,
                                             spriteRenderer.color.a +
                                             rate * Time.deltaTime);
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
            isMasked = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
            isMasked = false;
    }
}
