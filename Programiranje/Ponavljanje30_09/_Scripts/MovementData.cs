using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/MovementData", order = 1)]
public class MovementData : ScriptableObject
{
  public float moveSpeed;
  public float rotateSpeed;
  public float jumpForce;
}
