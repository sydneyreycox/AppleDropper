using UnityEngine;

public class YellowController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Starting apple at: " + transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y - Manager.Instance.appleSpeed*Time.deltaTime*2);
        transform.Rotate(0,0,Manager.Instance.appleRotationSpeed * Time.deltaTime * 2);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
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
