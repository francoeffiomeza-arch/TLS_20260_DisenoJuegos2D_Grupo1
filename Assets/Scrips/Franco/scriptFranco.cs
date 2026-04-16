using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;

public class scriptFranco : MonoBehaviour
{
    public float velocidad = 7f;
    public float SuperSalto = 8f;
    private Rigidbody2D rb;
    private bool EstaEnSuelo;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
       rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // controles de movimiento del personaje
        float movimiento = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * movimiento * velocidad * Time.deltaTime);
        if(Input.GetButtonDown("Jump") && EstaEnSuelo)
        {
            rb.AddForce(Vector2.up * SuperSalto, ForceMode2D.Impulse);
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            EstaEnSuelo = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Suelo"))
            EstaEnSuelo = false;
    }


}
