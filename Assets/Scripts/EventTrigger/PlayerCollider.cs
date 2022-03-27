using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerCollider : MonoBehaviour
{
    public UnityEvent<Player> OnEnter;
    public UnityEvent<Player> OnExit;
    
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            OnEnter?.Invoke(col.GetComponent<Player>());
        }
    }
    
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            OnExit?.Invoke(col.GetComponent<Player>());
        }
    }
}
