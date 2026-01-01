using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Movement : MonoBehaviour
{
    [SerializeField] public float moveSpeed = 7f;
    Vector2 rawInput;
    // Update is called once per frame
    void Update()
    {
        Vector3 delta = rawInput * moveSpeed * Time.deltaTime;
        transform.position += delta;
    }

    void OnMove(InputValue value)
    {
        rawInput = value.Get<Vector2>();
    }
}
