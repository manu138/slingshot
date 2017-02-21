using UnityEngine;

[RequireComponent (typeof (Rigidbody2D))]
public class Ship : MonoBehaviour 
{
	private new Rigidbody2D rigidbody;

	private void Awake () 
	{
		rigidbody = GetComponent<Rigidbody2D> ();	
	}
	
	void Update () 
	{
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePosScreen = Input.mousePosition;
            Vector3 mousePosWorld = Camera.main.ScreenToWorldPoint(mousePosScreen);

            transform.position = new Vector3(- mousePosWorld.x, - mousePosWorld.y, 0);

    }


    }


    private void LookTowards (Vector2 direction)
	{
		
		transform.localRotation = Quaternion.LookRotation (Vector3.forward, direction);
	}
}
