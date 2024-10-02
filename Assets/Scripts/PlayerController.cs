using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;


public class PlayerController : MonoBehaviour
    
{
    //Player's rigidbody
    private Rigidbody rb;
    private int count;
 
    //movement along X and Y axes
    private float movementX;
    private float movementY;

    //Player's movement speed
    public float speed = 0;

    //Display count of pickup objects collected
    public TextMeshProUGUI countText;

    //display win text
    public GameObject winTextObject;

    public GameObject door;

    // Start is called before the first frame update


    void Start()
    {
        //Get and store the Rigid body component attached to the player
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winTextObject.SetActive(false);
    }
    //Fuction is called when a move input is detected
    void OnMove(InputValue movementValue)

    {
        //Convert the input calue into a Vector2 for movement
        Vector2 movementVector = movementValue.Get<Vector2>();

        // Store the X and Y components of the movement
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3 (movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);
        
    }

    void OnTriggerEnter(Collider other)
    {
       
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            Debug.Log(count);
            SetCountText();
        }

        if (count == 4)
        {
        door.gameObject.SetActive(false);
        }

    }

   void SetCountText()
    {
       countText.text = "Count:" + count.ToString();

        if (count >= 12)
        {
            winTextObject.SetActive(true);
        }
    }

}
