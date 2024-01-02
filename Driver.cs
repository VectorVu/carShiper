using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 1f;
    [SerializeField] float moveSpeed = 20f;
    float normalSpeed = 20f;
    [SerializeField] float fastSpeed = 50f;
    [SerializeField] float lowSpeed = 5f;

    int speedTime = 0;

    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);

        if (speedTime > 0) {
            speedTime--;
        }
        if (speedTime == 0) {
            moveSpeed = normalSpeed;
        }
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Translate(0, moveAmount, 0);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "fast")
        {
            speedTime = 1000;
            moveSpeed = fastSpeed;
        }
        if (other.tag == "low")
        {
            speedTime = 1000;
            moveSpeed = lowSpeed;
        }
    }

}
