using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    float movespeed=5f;
    [SerializeField]
    float jumpforce=7f;

    [SerializeField]
    float raydistance=5f;
    [SerializeField]
    Color raycolor=Color.red;
    [SerializeField]
    LayerMask groundlayer;
    Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Axis multiplicado por la vel. y el tiempo delta (tiempo real).
        transform.Translate(Axis.x*Vector2.right*movespeed*Time.deltaTime);
        if(JumpButton && IsGrounding)
        {
            rb2d.AddForce(Vector2.up*jumpforce, ForceMode2D.Impulse);
        }
    }

    // Comando para controlar objeto; 'x' y 'y'
    Vector2 Axis => new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    bool JumpButton => Input.GetButtonDown("Jump"); 
    bool IsGrounding => Physics2D.Raycast(transform.position, Vector2.down, raydistance, groundlayer);
    void OnDrawGizmosSelected()
    {
        Gizmos.color=raycolor; 
        Gizmos.DrawRay(transform.position,Vector2.down*raydistance);
    }
}
