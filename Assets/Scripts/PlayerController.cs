using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _compRigidbody2D;
    private SpriteRenderer _compSpriteRenderer;
    [SerializeField] private float direccionHorizontal;
    [SerializeField] private float direccionVertical;
    [SerializeField] private int velocidad = 5;
    [SerializeField] private LayerMask layersInteractuables;
    
    void Awake()
    {
        _compRigidbody2D = GetComponent<Rigidbody2D>();
        _compSpriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        direccionHorizontal = Input.GetAxisRaw("Horizontal");
        direccionVertical = Input.GetAxisRaw("Vertical");
    }
    void FixedUpdate()
    {
        //Movimiento
        Vector2 direccion = new Vector2(direccionHorizontal, direccionVertical);
        _compRigidbody2D.velocity = direccion * velocidad;

        //Raycast
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direccion, 100, layersInteractuables);
        if (hit.collider != null)
        {
            GameObject datosDelObjeto = hit.collider.gameObject;
            Debug.Log("Nombre del Objeto: " + datosDelObjeto.name);
            Debug.Log("Posicion del Objeto: " + datosDelObjeto.transform.position);
            Debug.Log("Etiqueta del Objeto: " + datosDelObjeto.tag);
            SpriteRenderer tmpSR = datosDelObjeto.GetComponent<SpriteRenderer>();
            if (datosDelObjeto.tag == "Shape")
            {
                Debug.Log("Sprite: " + tmpSR.sprite);
            }
            else if (datosDelObjeto.tag == "Color")
            {
                Debug.Log("Color: " + tmpSR.sprite);
            }

        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        string indentificador = collision.tag;
        SpriteRenderer objetoEnColision = collision.gameObject.GetComponent<SpriteRenderer>();

        if (indentificador == "Shape")
        {
            _compSpriteRenderer.sprite = objetoEnColision.sprite;
        }
        else if (indentificador == "Color")
        {
            _compSpriteRenderer.color = objetoEnColision.color;
        }
    }
}
