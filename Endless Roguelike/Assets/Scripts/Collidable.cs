using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collidable : MonoBehaviour
{
    protected string fighterTag = "Fighter";
    protected string wallTag = "Wall";

    protected virtual void Update()
    {
        
    }

    protected virtual void OnTriggerEnter2D(Collider2D other) 
    {
        
    }
}
