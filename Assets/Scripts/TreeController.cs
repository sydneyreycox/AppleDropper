using System.Collections;
using UnityEngine;

public class TreeController : MonoBehaviour
{
    public float minWait = 2.5f;
    public float maxWait = 8f;
    private float direction = 1;

    public GameObject appleObject;
    public GameObject yellowAppleObject;
    public GameObject greenAppleObject;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Starting Tree");
        StartCoroutine(DropApples());
    }

    IEnumerator DropApples()
    {
        while (true)
        {
            float wait = Random.Range(minWait-Manager.Instance.appleSpawnRate,maxWait-(Manager.Instance.appleSpawnRate*2));
            yield return new WaitForSeconds(wait);
            int ran = Random.Range(0, 5); 
            if (ran == 4)
            {
                Instantiate(greenAppleObject, transform.position, Quaternion.identity);
            }
            if (ran == 3)
            {
                Instantiate(yellowAppleObject, transform.position, Quaternion.identity);
            }
            else{
                Instantiate(appleObject, transform.position, Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x + direction*Manager.Instance.treeSpeed*Time.deltaTime, 
            transform.position.y);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //if(collision.gameObject.name=="LeftWall" || collision.gameObject.name=="RightWall") 
        direction *= -1;
    }
}
