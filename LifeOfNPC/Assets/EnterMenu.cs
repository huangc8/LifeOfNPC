using UnityEngine;
using System.Collections;

public class EnterMenu : MonoBehaviour {

    public GameObject Menu;
    public bool inMenu = false;

    void OnGUI()
    {
        Vector3 MousePosition = Input.mousePosition;//gets mouse position
        MousePosition.z = Camera.main.transform.position.z;//distance from camera to screen
        MousePosition = Camera.main.ScreenToWorldPoint(MousePosition);//converts mouse position(pixels) to world position

        if (GetComponent<Collider2D>().OverlapPoint(MousePosition) && !inMenu)//text if mouse over object and no open menu
        {
            GUI.Label(new Rect(300, 300, 150, 50), "Click to craft item");
        }

        if(GameObject.Find("CraftingMenu(Clone)") == null)//checks to see if a menu is open
        {
            inMenu = false;
        }
    }

    void OnMouseOver()//called once per frame while mouse is over the object with this script
    {
        if (Input.GetMouseButtonUp(0) && !inMenu)
        {
            inMenu = true;
            //Debug.Log("menu opened");
            Instantiate(Menu, new Vector3(300, 300, 0), new Quaternion(0, 0, 0, 0));//creates empty objects that creates gui button objects
        }
    }

}
