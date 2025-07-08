using System;
using TMPro;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody playerRigidbody;
    [SerializeField] private float speed;
    [SerializeField] private TMP_Text scoreText;
    

    private int score = 0;

    private void Start()
    {
        IncreaseScore(0);
    }

    private void FixedUpdate()
    {
        playerRigidbody.linearVelocity = Vector3.zero;
        
        if (Input.GetKey(KeyCode.A) && transform.position.x > -7)
        {
           // playerRigidbody.linearVelocity = Vector2.left * speed * Time.deltaTime;
           Move(Vector2.left);
        }

        if (Input.GetKey(KeyCode.D) && transform.position.x < 7)
        {
            //playerRigidbody.linearVelocity = Vector2.right * speed * Time.deltaTime;
            Move(Vector2.right);
        }
    }

    private void Move(Vector2 direction)
    {
        direction.Normalize();
        Vector2 targetVelocity = direction * speed;
        playerRigidbody.linearVelocity =
            Vector2.Lerp(playerRigidbody.linearVelocity, targetVelocity, 10 * Time.deltaTime);
    }

    public void IncreaseScore(int amount)
    {
        score += amount;
        scoreText.text = score.ToString();
    }
}
