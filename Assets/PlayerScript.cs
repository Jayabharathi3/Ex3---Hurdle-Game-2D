
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class Player1 : MonoBehaviour
{

    public float speed;
    public float jumpforce;
    private Rigidbody2D rb;
    public CoinManager cc;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveinp = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(moveinp, 0, 0) * speed * Time.deltaTime;

        if(Input.GetKeyDown(KeyCode.Space)&&Mathf.Abs(rb.velocity.y)<0.001f)
        {
            rb.AddForce(new Vector2(0, jumpforce), ForceMode2D.Impulse);
        }
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("destroy"))
        {
            cc.coincount++;
            Destroy(collision.gameObject);
        }
    }
}
