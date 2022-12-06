using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGParallax : MonoBehaviour
{
    Vector2 _position;
    Vector2 _startPosition;
    private float posX;
    private float posY;

    public int moveModifier = 20;
    public int reactionSpeed = 5;

    public bool _followMouse;

    private void Start()
    {
        _startPosition = transform.position;
    }

    private void Update()
    {
        _position = Camera.main.ScreenToViewportPoint(Input.mousePosition);

        if (_followMouse == true)
        {
            float posX = Mathf.Lerp(transform.position.x, _startPosition.x + (_position.x * moveModifier), reactionSpeed * Time.deltaTime);
            float posY = Mathf.Lerp(transform.position.y, _startPosition.y + (_position.y * moveModifier), reactionSpeed * Time.deltaTime);
            transform.position = new Vector3(posX, posY, 0);
        }
        else
        {
            float posX = Mathf.Lerp(transform.position.x, _startPosition.x - (_position.x * moveModifier), reactionSpeed * Time.deltaTime);
            float posY = Mathf.Lerp(transform.position.y, _startPosition.y - (_position.y * moveModifier), reactionSpeed * Time.deltaTime);
            transform.position = new Vector3(posX, posY, 0);
        }


        
    }

}
