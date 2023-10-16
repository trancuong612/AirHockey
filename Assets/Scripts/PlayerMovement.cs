using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    UnityEngine.Vector2 startingPosition;
    public UnityEngine.Collider2D PlayerCollider{get; private set;}
    public Controler controller;

    public int? LockedFingerID{get;set;}
    Rigidbody2D rb;

    public Transform Holder;
    Boundary playerBoundary;

    struct Boundary
    {
        public float Up, Down, Left, Right;
        public Boundary(float up,float down,float left,float right){
            Up = up;
            Down = down;
            Left = left;
            Right = right;
        }
    }

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        startingPosition = rb.position;
        PlayerCollider = GetComponent<Collider2D>();

        playerBoundary = new Boundary(Holder.GetChild(0).position.y,
                                    Holder.GetChild(1).position.y,
                                    Holder.GetChild(2).position.x,
                                    Holder.GetChild(3).position.x);
    }
    private void OnEnable() {
        controller.Players.Add(this);
    }
    private void OnDisable() {
        controller.Players.Remove(this);
    }

	
    public void MoveToPosition(UnityEngine.Vector2 position){
        UnityEngine.Vector2 Clam = new UnityEngine.Vector2(Mathf.Clamp(position.x, playerBoundary.Left, playerBoundary.Right), 
                                                            Mathf.Clamp(position.y, playerBoundary.Down, playerBoundary.Up));
                rb.MovePosition(Clam);
    }
    public void ResetPosition(){
            rb.position = startingPosition;
        }
}
