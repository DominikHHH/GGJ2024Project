using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NegativeThrowable : MonoBehaviour
{
    public MonoBehaviour scriptToDisable;
    [SerializeField] float clickRange = 4;

    void Start()
    {
        EventHandler.Click += OnClick;
    }

    private void OnDestroy()
    {
        EventHandler.Click -= OnClick;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
            //Negative Action:
            EventHandler.OnChangeHealth(-1);


            //Debug.Log("ThrowableObject touched player and destroyed.");
        }
        else if (collision.CompareTag("Kill Zones")) 
        {
            Destroy(gameObject);
        }
    }

    void OnClick(Vector2 position)
    {
        if (Vector2.Distance(position, new Vector2(transform.position.x, transform.position.y)) < clickRange)
        {
            DisableScript(scriptToDisable);
        }
    }

    public static void DisableScript(MonoBehaviour script)
    {
        if (script != null)
        {
            script.enabled = false;
        }
        else
        {
            Debug.LogWarning("Script is null! Cannot disable.");
        }
    }
}