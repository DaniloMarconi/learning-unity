using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlataformController : MonoBehaviour
{
    private bool going = true;

    [SerializeField]
    private bool horizontal;
    [SerializeField]
    private float speed;

    private Vector3 inicialPosition;
    public Transform finalObject;

    void Start()
    {
        this.inicialPosition = this.transform.position;
    }

    void Update()
    {
        if (this.horizontal)
            this.VerifyHorizontalMove();
        else
            this.VerifyVerticalMove();
    }

    private void FixedUpdate()
    {
        if (this.horizontal)
            this.HorizontalMove();
        else 
            this.VerticalMove();
    }

    private void VerifyHorizontalMove()
    {
        if (this.transform.position.x >= this.finalObject.position.x)
            this.going = false;
        else if (this.transform.position.x <= this.inicialPosition.x)
            this.going = true;
    }

    private void HorizontalMove()
    {
        if (this.going)
            this.transform.Translate(Vector2.right * this.speed * Time.deltaTime);
        else
            this.transform.Translate(Vector2.right * this.speed * -1 * Time.deltaTime);

    }

    private void VerifyVerticalMove()
    {
        if (this.transform.position.y >= this.finalObject.position.y)
            this.going = false;
        else if (this.transform.position.y <= this.inicialPosition.y)
            this.going = true;
    }

    private void VerticalMove()
    {
        if (this.going)
            this.transform.Translate(Vector2.up * this.speed * Time.deltaTime);
        else
            this.transform.Translate(Vector2.up * this.speed * -1 * Time.deltaTime);

    }
}
