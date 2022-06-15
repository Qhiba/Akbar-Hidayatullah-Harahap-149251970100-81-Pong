using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUSpeedUpController : MonoBehaviour
{
    public float magnitude;

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
            ball.GetComponent<BallController>().ActivePUSPeedUp(magnitude);
            powerUpManager.RemovePowerUp(gameObject);
        }
    }
}
