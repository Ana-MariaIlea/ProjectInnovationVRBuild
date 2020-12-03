using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeGrapth : MonoBehaviour
{

    [SerializeField]
    List<Node> nodes;
    void Awake()
    {
        nodes = new List<Node>();
    }


    private void Start()
    {
        foreach(var node in GetComponentsInChildren<Node>()) {
            nodes.Add(node);
        }
    }
}
