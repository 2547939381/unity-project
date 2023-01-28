using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spring : MonoBehaviour
{
    Rigidbody2D rb;
    public Transform headCheck;
    [SerializeField] private float speed = 450f;
    void Start()
    {
        headCheck = transform.Find("headCheck");
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Spring();
    }
    private void Spring()
    {
        Collider2D player = Physics2D.OverlapCircle(headCheck.position, 0.3f, LayerMask.GetMask("player"));
        if (player == null)
        {
            return;
        }
        rb= player.gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(rb.velocity.x, 0f);//«Â≥˝y÷·ÀŸ∂»
        rb.AddForce(new Vector2(0, speed));
    }
}
