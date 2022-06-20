using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public Vector2 speed;
    public Vector2 resetPosition;

    public PaddleController paddleController;

    private Rigidbody2D rig;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        rig.velocity = speed;
    }

    public void ResetBall()
    {
        rig.velocity = speed;
        transform.position = new Vector3(resetPosition.x, resetPosition.y, 2);
    }

    public void ActivePUSPeedUp(float magnitude)
    {
        rig.velocity *= magnitude;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.GetComponent<PaddleController>() != null)
        {
            paddleController = collision.transform.GetComponent<PaddleController>();
        }
    }
}
