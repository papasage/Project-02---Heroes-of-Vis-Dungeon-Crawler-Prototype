using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGParallax : MonoBehaviour
{
    Vector2 _position;
    Vector2 _startPosition;
    public int moveModifier;

    private void Start()
    {
        _startPosition = transform.position;
    }

    private void Update()
    {
        _position = Camera.main.ScreenToViewportPoint(Input.mousePosition);

        float posX = Mathf.Lerp(transform.position.x, _startPosition.x + (_position.x * moveModifier), 2f * Time.deltaTime);
        float posY = Mathf.Lerp(transform.position.y, _startPosition.y + (_position.y * moveModifier), 2f * Time.deltaTime);

        transform.position = new Vector3(posX, posY, 0);
    }

}
