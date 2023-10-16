using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vien : MonoBehaviour
{
    public Score ScoreScriptInstance;
    public static bool WasGoal { get; private set; }
    private Rigidbody2D rb;
    public float MaxSpeed;

    public Audio audioManager;

	void Start () {
        rb = GetComponent<Rigidbody2D>();
        WasGoal = false;
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!WasGoal)
        {
            if (other.tag == "BlueGoal")
            {
                ScoreScriptInstance.Increment(Score.score.PlayerScore);
                WasGoal = true;
                audioManager.PlayGoal();
                StartCoroutine(ResetPuck(false));
            }
            else if (other.tag == "RedGoal")
            {
                ScoreScriptInstance.Increment(Score.score.AiScore);
                WasGoal = true;
                audioManager.PlayGoal();
                StartCoroutine(ResetPuck(true));// reset ve vi tri ban dau
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D other) {
        audioManager.PlayPuckCollision();
    }

    private IEnumerator ResetPuck(bool dAiScore)// reset
    {
        yield return new WaitForSecondsRealtime(1);
        WasGoal = false;
        rb.velocity = rb.position = new Vector2(0, 0);

        if (dAiScore)
            rb.position = new Vector2(0, -1);
        else
            rb.position = new Vector2(0, 1);
    }
    public void CenterPuck()
    {
        rb.position = new Vector2(0, 0);
    }
    private void FixedUpdate()
    {
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, MaxSpeed);
    }
}
