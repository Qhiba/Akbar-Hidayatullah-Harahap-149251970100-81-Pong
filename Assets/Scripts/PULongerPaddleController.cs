using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PULongerPaddleController : MonoBehaviour
{
    public float paddleLengthTimes;

    public Collider2D ball;
    public PowerUpManager powerUpManager;

    private float timer;

    public void Start()
    {
        timer = 0;
    }

    public void Update()
    {
        timer += Time.deltaTime;
        if (timer >= powerUpManager.onScreenInterval)
        {
            timer -= powerUpManager.onScreenInterval;
            powerUpManager.RemovePowerUp(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == ball)
        {
            //Debug.Log(ball.attachedRigidbody.velocity.x);
            PaddleController paddle = collision.GetComponent<BallController>().paddleController;
            if (paddle == null)
            {
                powerUpManager.RemovePowerUp(gameObject);
                return;
            }

            collision.GetComponent<BallController>().paddleController.ActivePULongerLength(paddleLengthTimes);
            powerUpManager.RemovePowerUp(gameObject);
        }
    }
}
