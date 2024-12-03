using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
  public float movSpeed;

  void Start()
  {
  }

  void Update()
  {
    if (Input.GetButton("WalkForward")) transform.Translate(0, 0, movSpeed * Time.deltaTime);
    if (Input.GetButton("WalkBackwards")) transform.Translate(0, 0, -movSpeed * Time.deltaTime);
    if (Input.GetButton("WalkRight")) transform.Translate(movSpeed * Time.deltaTime, 0, 0);
    if (Input.GetButton("WalkLeft")) transform.Translate(-movSpeed * Time.deltaTime, 0, 0);
  }
}
