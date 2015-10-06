using UnityEngine;
using System.Collections;

public class ClickandDrag : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        //on mouse down 
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 MousePosition = Input.mousePosition;//gets mouse position
            MousePosition.z = Camera.main.transform.position.z;//distance from camera to screen
            MousePosition = Camera.main.ScreenToWorldPoint(MousePosition);//converts mouse position(pixels) to world position
                                                                          //Debug.Log(MousePosition);

            if (GetComponent<Collider2D>().OverlapPoint(MousePosition))
            {
                //Debug.Log("clicked on");
                OnMouseDrag();

            }
        }
        else
        {
            //dragging = false;
        }
    }

    void OnMouseDrag()
    {
        Vector3 MousePosition = Input.mousePosition;//gets mouse position
        MousePosition = Camera.main.ScreenToWorldPoint(MousePosition);//converts mouse position(pixels) to world position
        transform.position = new Vector3(MousePosition.x, MousePosition.y, 0);//set object position to mouse position while mouse is down
    }

}