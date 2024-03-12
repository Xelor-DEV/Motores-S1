using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _compRigidbody2D;
    private float direccionHorizontal;
    private float direccionVertical;
    private int velocidad = 5;
    void Awake()
    {
        _compRigidbody2D = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        direccionHorizontal = Input.GetAxisRaw("Horizontal");
        direccionVertical = Input.GetAxisRaw("Vertical");
    }
    void FixedUpdate()
    {
        _compRigidbody2D.velocity = new Vector2(velocidad * direccionHorizontal, velocidad * direccionVertical);
    }
}
