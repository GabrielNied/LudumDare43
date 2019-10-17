using UnityEngine;

public class Player : MonoBehaviour
{
    public float vel = 1f;
    private Rigidbody2D rb2d;
    public bool connected = false;
    DistanceJoint2D distanceJoint2D;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        distanceJoint2D = GetComponent<DistanceJoint2D>();
    }

    void FixedUpdate()
    {
        Movimenta();
    }

    void Movimenta()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        if (connected && distanceJoint2D.distance > .75f)
        {
            rb2d.velocity = new Vector2(moveHorizontal * vel, rb2d.velocity.y);
            distanceJoint2D.distance -= Time.deltaTime * vel;
        }
        else
        {
            rb2d.velocity = new Vector2(moveHorizontal * vel, rb2d.velocity.y);
        }
    }
}