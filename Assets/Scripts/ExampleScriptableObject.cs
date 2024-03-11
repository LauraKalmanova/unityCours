using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "example", menuName = "Cours/Data")]
public class ExampleScriptableObject : ScriptableObject
{
    [SerializeField] private float speed = 10;
    [SerializeField] private Vector3 direction = new Vector3(1, 0, 0);
    [SerializeField] private GameObject prefab;

    public float Speed { get { return speed; } }
    public Vector3 Direction { get { return direction; } }
}
