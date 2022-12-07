using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateHoverUtil : MonoBehaviour
{
    [Header("Time Scale Settings")]
    [SerializeField] private bool usesLocalTime = true;
    private float localTime;

    [Header("Rotate Settings")]
    [SerializeField] private bool canRotate;
    [SerializeField] private Vector3 degreesPerSecond = new Vector3(0f, 0f, 15f);

    [Header("Hover Settings")]
    [SerializeField] private bool canHover;
    [SerializeField] private float hoverAmp = 0.05f; //hover intensity
    [SerializeField] private float hoverFreq = 1f; //time needed for one cycle
                                                  
    [Header("Wobble Settings")]
    [SerializeField] private bool canWobble;
    [SerializeField] private float wobbleAmp = 0.05f; //hover intensity
    [SerializeField] private float wobbleFreq = 1f; //time needed for one cycle

    private Vector3 posOffset = new Vector3();
    private Vector3 tempPos = new Vector3();
    private float _sine;
    public float Sine => _sine; // this public sine can be used to sync to a shadow script

    private void Awake()
    {
        posOffset = transform.localPosition;
        localTime = Random.Range(0, 1000);
    }

    private void Update()
    {
        if (usesLocalTime)
        {
            localTime += Time.deltaTime;
        }
        else
        {
            localTime = Time.fixedTime;
        }

        if (canRotate)
        {
            transform.Rotate(Time.deltaTime * degreesPerSecond, Space.Self);
        }

        if (canHover)
        {
            tempPos = posOffset;

            _sine = Mathf.Sin(localTime * Mathf.PI * hoverFreq);
            tempPos.y += (_sine * hoverAmp);

            transform.localPosition = tempPos;
        }
        
        if (canWobble)
        {
            tempPos = posOffset;

            _sine = Mathf.Sin(localTime * Mathf.PI * wobbleFreq);
            tempPos.x += (_sine * wobbleAmp);

            transform.localPosition = tempPos;
        }
    }

}
