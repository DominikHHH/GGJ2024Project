using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositiveThrowable : MonoBehaviour
{
    [SerializeField] private float clickMultipler = 4;
    [SerializeField] private float pointMultipler = 1;
    [SerializeField] private float clickRange = 2;
    [field: SerializeField] public EventReference destroySound { get; private set; }
    // Start is called before the first frame update
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
            AudioManager.instance.PlayOneShot(destroySound);

            Destroy(gameObject);
            //Positive Action
            GrantPoints(pointMultipler);

            //Debug.Log("ThrowableObject touched player and destroyed.");
        }

        else if (collision.CompareTag("Kill Zones"))
        {
            Destroy(gameObject);
        }
    }

    void GrantPoints(float mulitplier) 
    {
        PlayerData.instance.ChangeScore(mulitplier);
    }

    void OnClick(Vector2 position) 
    {
        if (Vector2.Distance(position, new Vector2(transform.position.x, transform.position.y)) < clickRange) 
        {
            GrantPoints(pointMultipler * clickMultipler);
            Destroy(gameObject);
            AudioManager.instance.PlayOneShot(destroySound);
        }

    }
}