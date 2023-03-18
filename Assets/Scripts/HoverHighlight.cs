using UnityEngine;

public class HoverHighlight : MonoBehaviour
{
    
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private float rate = 2.0f;

    bool isHighlight = false;

    private void Update()
    {
        if (!isHighlight && spriteRenderer.color.a > 0)
            spriteRenderer.color = new Color(spriteRenderer.color.r,
                                             spriteRenderer.color.g,
                                             spriteRenderer.color.b,
                                             spriteRenderer.color.a -
                                             rate * Time.deltaTime);
        else if (isHighlight && spriteRenderer.color.a < 1)
            spriteRenderer.color = new Color(spriteRenderer.color.r,
                                             spriteRenderer.color.g,
                                             spriteRenderer.color.b,
                                             spriteRenderer.color.a +
                                             rate * Time.deltaTime);
    }

    private void OnMouseEnter() => isHighlight = true;
    private void OnMouseExit() => isHighlight = false;
}
