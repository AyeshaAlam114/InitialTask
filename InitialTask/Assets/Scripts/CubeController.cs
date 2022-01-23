using UnityEngine;

public class CubeController : MonoBehaviour
{
    public float maxSizeLimit;
    public Color[] colorArray;
    // Update is called once per frame
    void Update()
    {
        Movement();                                                                 //Move Cube
        Scaling();
    }

    void Scaling()
    {
        if (Input.GetKey(KeyCode.Space))                                            //check if hold space
            IncreaseSize();                                                         //call increase size
        if (Input.GetKeyUp(KeyCode.Space))                                          //check if release space
            DecreaseSize();                                                         //call decrease size
        if (transform.localScale.x > maxSizeLimit)                                  //check if scale is greater then max limit
            ResetSize();                                                            //call reset size
    }

    void ColorChange()
    {
        int value = Random.Range(0, colorArray.Length);                             //pic random index
        GetComponent<Renderer>().material.color = colorArray[value];                //change the color code
    }

    void IncreaseSize()
    {
        transform.localScale=new Vector3(transform.localScale.x + 0.1f, 
                                         transform.localScale.y + 0.1f, 
                                         transform.localScale.z + 0.1f);            //Increase scale value
        ColorChange();                                                              //Call change color
    }
    void DecreaseSize()
    {
        transform.localScale = new Vector3(transform.localScale.x - 1, 
                                           transform.localScale.y - 1, 
                                           transform.localScale.z - 1);            //Decrease scale value
    }
    void ResetSize()
    {
        transform.localScale = new Vector3(1, 1, 1);                               //Reset scale to 1

    }

    void Movement()
    {
        if (Input.GetKey(KeyCode.RightArrow))                                      //check if right arrow pressed
            RotateCube(Vector3.right);                                             //Set rotation direction to positive X-axis
        if (Input.GetKey(KeyCode.LeftArrow))                                       //check if left arrow pressed
            RotateCube(Vector3.left);                                              //Set rotation direction to negative X-axis
        if (Input.GetKey(KeyCode.UpArrow))                                         //check if up arrow pressed
            RotateCube(Vector3.up);                                                //Set rotation direction to positive Y-axis
        if (Input.GetKey(KeyCode.DownArrow))                                       //check if down arrow pressed
            RotateCube(Vector3.down);                                              //Set rotation direction to negative Y-axis
        if (Input.GetKey(KeyCode.A))                                               //check if A pressed
            RotateCube(Vector3.forward);                                           //Set rotation direction to positive Z-axis
        if (Input.GetKey(KeyCode.S))                                               //check if S pressed
            RotateCube(Vector3.back);                                              //Set rotation direction to negative Z-axis
    }

    void RotateCube(Vector3 direction)
    {
        transform.Rotate(direction * 1);                                           //Rotate according the given direction
    }
}
