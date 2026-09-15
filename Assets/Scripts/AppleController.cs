using UnityEngine;

public class AppleController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Starting apple at: " + transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y - Manager.Instance.appleSpeed*Time.deltaTime);
        transform.Rotate(0,0,Manager.Instance.appleRotationSpeed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Apple is contancting: " + collision.gameObject.name);
        if(collision.gameObject.name == "Floor")
        {
            Manager.Instance.LoseLife();
        }
        if(collision.gameObject.name == "Basket")
        {
            Manager.Instance.GainPoint();
        }
        Destroy(gameObject);
    }
}
