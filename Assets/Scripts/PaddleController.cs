using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public int speed;
    public int powerUpActiveTime; //On Seconds

    public KeyCode upKey;
    public KeyCode downKey;

    private bool longerPaddleActive = false;
    private bool speedUpActive = false;

    private Rigidbody2D rig;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //Move Object
        MoveObject(GetInput());
    }

    private Vector2 GetInput()
    {
        if (Input.GetKey(upKey))
        {
            return Vector2.up * speed;
        }
        else if (Input.GetKey(downKey))
        {
            return Vector2.down * speed;
        }

        return Vector2.zero;
    }

    private void MoveObject(Vector2 movement)
    {
        //Debug.Log("TEST: " + movement);
        rig.velocity = movement;
    }

    #region Longer Length
    public void ActivePULongerLength(float lengthTimes)
    {
        if (!longerPaddleActive)
        {
            spriteRenderer.color = Color.red;
            transform.localScale = new Vector2(transform.localScale.x, transform.localScale.y * lengthTimes);
            longerPaddleActive = true;
            StartCoroutine("DeactivePULongerLength", lengthTimes);
        }
    }

    private IEnumerator DeactivePULongerLength(float lengthTimes)
    {
        yield return new WaitForSeconds(powerUpActiveTime);
        transform.localScale = new Vector2(transform.localScale.x, transform.localScale.y / lengthTimes);
        longerPaddleActive = false;

        if (speedUpActive)
        {
            spriteRenderer.color = Color.green;
        }
        else
        {
            spriteRenderer.color = Color.white;
        }
    }
    #endregion

    #region Speed Up
    public void ActivePUSpeedUp(float speedTimes)
    {
        if (!speedUpActive)
        {
            spriteRenderer.color = Color.green;
            speed *= (int)speedTimes;
            speedUpActive = true;
            StartCoroutine("DeactivePUSpeedUp", speedTimes);
        }
        
    }

    private IEnumerator DeactivePUSpeedUp(float speedTimes)
    {
        yield return new WaitForSeconds(powerUpActiveTime);
        speedUpActive = false;
        speed /= (int)speedTimes;

        if (longerPaddleActive)
        {
            spriteRenderer.color = Color.red;
        }
        else
        {
            spriteRenderer.color = Color.white;
        }
    }
    #endregion
}
