using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Ball : MonoBehaviour
{
    
    private GameObject pedal;
    public GameObject olive;
    private bool gamestarted = false;
    public Text scoreText;

    int score = 0;

   
    // Start is called before the first frame update
    void Start()
    {
        pedal = GameObject.FindObjectOfType<Pedal>().gameObject;//find which object has pedal script on it
        scoreText.text = score.ToString() + "POINTS";
    }

    // Update is called once per frame
    void Update()
    {
        if (!gamestarted)
        {
            transform.position = new Vector3(pedal.transform.position.x, transform.position.y, transform.position.z);
        }
        
        if (Input.GetMouseButtonDown(0))
        {
            gamestarted = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 10f);
        }

        if (score==100)
        {
            SceneManager.LoadScene("YouWon");
        }
    }

    public void AddPoint()
    {
        score += 10;
        scoreText.text = score.ToString() + "POINTS";
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="cherry")
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(3f, 10f);
            AddPoint();
            Destroy(collision.gameObject);
            
            //Destroy();
        }
        else if (collision.gameObject.tag == "banana")
        {
           
            pedal.transform.localScale += new Vector3(0.28f, 0.2f, 1f);
            AddPoint();
            Destroy(collision.gameObject);

        }
        else if (collision.gameObject.tag == "watermelon")
        {

            olive.transform.localScale += new Vector3(0.12f, 0.12f, 1f);
            AddPoint();
            Destroy(collision.gameObject);

        }
        else if (collision.gameObject.tag == "hamburger")
        {

            pedal.transform.localScale -= new Vector3(0.05f, 0.05f, 0.05f);
            AddPoint();
            Destroy(collision.gameObject);

        }
        else if (collision.gameObject.tag == "cheese")
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(1f, 10f);
            AddPoint();
            Destroy(collision.gameObject);

        }

    }
}
