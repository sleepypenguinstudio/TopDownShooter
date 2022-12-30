using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.Users;

public class GamePadCursor : MonoBehaviour
{
    [SerializeField] private GameObject cursor;
    float speedMultiplier=100f;



















    public void moveCursorPosition(Vector2 cursorMovementInput,float _cursorSpeed)
    {
        cursor.transform.Translate(Vector3.right*cursorMovementInput.x*_cursorSpeed*speedMultiplier*Time.fixedDeltaTime);
        cursor.transform.Translate(Vector3.up * cursorMovementInput.y * _cursorSpeed *speedMultiplier* Time.fixedDeltaTime);
    }




    public Vector3 getCursorPosition()
    {
        

       return cursor.transform.position;
    }

}
