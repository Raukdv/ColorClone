using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    //Declaring Variables
    [SerializeField] private float verticalForce = 400f;
    [SerializeField] private float restartDelay = 1f;

    [SerializeField] private ParticleSystem playerParticles;

    //public AnimationCurve curva;
    [SerializeField] private Color yellowColor;
    [SerializeField] private Color violetColor;
    [SerializeField] private Color cyanColor;
    [SerializeField] private Color pinkColor;
    [SerializeField] private string currentColor;

    //Component's  references
    Rigidbody2D playerRb;
    SpriteRenderer playerSr;
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Hola, me acabo de llamar.");
        //Getting Component RigidBody2D
        //GetComponent<Rigidbody2D>().gravityScale = 0;
        //Adding Force
        //GetComponent<Rigidbody2D>().AddForce(new Vector2(100, 400));
        //Changing Sprite color
        //GetComponent<SpriteRenderer>().color = Color.red;

        //instando referencias
        playerRb = GetComponent<Rigidbody2D>();
        playerSr = GetComponent<SpriteRenderer>();
        //playerSr.color = Color.red;
        ChangeColor();

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Hola, me acabo de llamar.");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Adding Force
            playerRb.velocity = Vector2.zero;
            playerRb.AddForce(new Vector2(0, verticalForce));
            //Debug.Log(curva.Evaluate(5));
        }
    }
    //Collieder function
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Ay, me pegue teeh-hee con. " + collision.gameObject.name);
        //collision.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
    }

    //Trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Color changer logic
        if (collision.gameObject.CompareTag("ColorChanger"))
        {
            ChangeColor();
            Destroy(collision.gameObject);
            return;
        }

        if (collision.gameObject.CompareTag("FinishLine"))
        {
            //Call like this and will be automatic
            //LoadNextScene();
            //To add delay without timers, just apply Invoke with the function name and the delay you want to use
            gameObject.SetActive(false); // this for disable player object in the current game, to have clean new scene
            Instantiate(playerParticles, transform.position, Quaternion.identity); // Apply the effects
            Invoke("LoadNextScene", restartDelay);
            return;
        }

        //Debug.Log("Ay, me triggeree teeh-hee con. " + collision.gameObject.name);
        //sDebug.Log("Ay, me triggeree teeh-hee con. " + collision.gameObject.tag);
        //collision.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        //Check main condicion for the game
        if (!collision.gameObject.CompareTag(currentColor))
        {
            //Restart the Scena - Custom Function
            //RestartScene();
            gameObject.SetActive(false); // this will disable the player
            //Instantiate particles
            Instantiate(playerParticles, transform.position, Quaternion.identity);
            Invoke("RestartScene", restartDelay);
        }

    }
    void LoadNextScene(){
        int activeIndexScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(activeIndexScene+1);
    }
    public void RestartScene()
    {   
        //Take Scene Object Name as argument
        //Raw method
        //SceneManager.LoadScene("Level1");
        //Dynamic Method by name
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //Dynamic Method by index
        int activeIndexScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(activeIndexScene);
    }
    void ChangeColor()
    {
        int randomNumber = Random.Range(0,4);
        //Debug.Log("" + randomNumber);

        switch(randomNumber) 
        {
        case 0:
            playerSr.color = yellowColor;
            currentColor = "Yellow";
            // code block
            break;
        case 1:
            playerSr.color = violetColor;
            currentColor = "Violet";
            // code block
            break;
        case 2:
            playerSr.color = cyanColor;
            currentColor = "Cyan";
            //code block
            break;
        case 3:
            playerSr.color = pinkColor;
            currentColor = "Pink";
            break;
        default:
            break;
        }
        Debug.Log("Teeh-hee, Ahora el color es " + currentColor);
    }
}
