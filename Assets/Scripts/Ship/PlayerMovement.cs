using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    UIController uIController;
    GameController gameController;
    public GameObject movementTarget;
    public int sailLevel = 0;
    public int maxSailLevel = 2;
    public float turnSpeed = 0.2f;

    void Start(){
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        uIController = GameObject.Find("UIController").GetComponent<UIController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            gameController.TogglePlayerPause();
        }
        if (!gameController.paused){
            if (Input.GetKeyDown(KeyCode.W)){
                IncreaseSailLevel();
            }
            else if (Input.GetKeyDown(KeyCode.S)){
                DecreaseSailLevel();
            }
            MoveForwards();
            if(Input.GetKey(KeyCode.A)){
                TurnLeft();
            }
            if(Input.GetKey(KeyCode.D)){
                TurnRight();
            }
        }
    }

    public void IncreaseSailLevel(){
        if (sailLevel < maxSailLevel){
            sailLevel++;
            uIController.UpdateSailSpeedDisplay(sailLevel);
        }
    }

    public void DecreaseSailLevel(){
        if (sailLevel > 0){
            sailLevel--;
            uIController.UpdateSailSpeedDisplay(sailLevel);
        }
    }

    public void MoveForwards(){
        Vector3 heading = movementTarget.transform.position - transform.position;
        transform.position += heading * sailLevel * Time.deltaTime;
    }

    public void TurnLeft(){
        Vector3 newRotation = new Vector3(0 - GetCurrentTurnSpeed(), 0, 0);
        transform.Rotate(newRotation);
    }
    public void TurnRight(){
        Vector3 newRotation = new Vector3(GetCurrentTurnSpeed(), 0, 0);
        transform.Rotate(newRotation);
    }

    float GetCurrentTurnSpeed(){
        int sailLevelForTurnSpeed = maxSailLevel - sailLevel;
        if (sailLevelForTurnSpeed < 1){
            sailLevelForTurnSpeed = 1;
        }
        float currentTurnSpeed = turnSpeed * sailLevelForTurnSpeed;
        return currentTurnSpeed;
    }
}
