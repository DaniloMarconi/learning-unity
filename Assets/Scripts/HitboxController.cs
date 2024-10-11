using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxController : MonoBehaviour
{
    private float horizontalInput;

    public BoxCollider2D bc;

    // Start is called before the first frame update
    void Start()
    {
        this.bc = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
            Destroy(collision.gameObject);
    }
}
