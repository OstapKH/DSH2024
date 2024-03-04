using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 PlayerDirection;
    public float PlayerSpeed;
    public GroundSpawnerScript groundSpawner;
    void Start()
    {
        PlayerDirection = Vector3.left;
    }

    // Update is called once per frame
    void Update()
    {
        playerController();
        transform.position += getPlayerDirection() * PlayerSpeed * Time.deltaTime;
    }

    public Vector3 getPlayerDirection()
    {
        return PlayerDirection;
    }

    private void playerController()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerMove();
        }
    }

    private void PlayerMove()
    {
        if (PlayerDirection.x == -1)
        {
            PlayerDirection = Vector3.forward;
        }
        else
        {
            PlayerDirection = Vector3.left;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            groundSpawner.RandonGround2();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Dead")
        {
            Time.timeScale = 0f;
        }
    }
}
