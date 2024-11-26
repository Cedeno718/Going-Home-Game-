using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  Vector2 moveInput
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
void OnMove(InputValue value)
{
moveInput = value.Get<Vector2>();
debug.Log(moveInput);
}
