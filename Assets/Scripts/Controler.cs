using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controler : MonoBehaviour
{
public List<PlayerMovement> Players = new List<PlayerMovement>();

public GameObject AiPlayer;
private void Start()
    {
        if (GameValues.IsMultiplayer)
        {
            AiPlayer.GetComponent<PlayerMovement>().enabled = true;
            AiPlayer.GetComponent<AI>().enabled = false;
        }
        else
        {
            AiPlayer.GetComponent<PlayerMovement>().enabled = false;
            AiPlayer.GetComponent<AI>().enabled = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        for (int i = 0 ; i < Input.touchCount; i++){
            UnityEngine.Vector2 touchPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position);
            foreach (var player in Players)
            {
                if(player.LockedFingerID == null){
                    if (Input.GetTouch(i).phase == TouchPhase.Began && player.PlayerCollider.OverlapPoint(touchPos))
                    {
                        player.LockedFingerID = Input.GetTouch(i).fingerId;
                    }
                }
                else if (player.LockedFingerID == Input.GetTouch(i).fingerId)
                {
                    player.MoveToPosition(touchPos);
                    if (Input.GetTouch(i).phase == TouchPhase.Ended ||
                        Input.GetTouch(i).phase == TouchPhase.Canceled)
                    {
                        player.LockedFingerID = null;
                    }
                }
            }
        }
    }
}
