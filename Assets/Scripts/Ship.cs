using UnityEngine;

[RequireComponent (typeof (Rigidbody2D))]
public class Ship : MonoBehaviour 
{
	private new Rigidbody2D rigidbody;

    public Vector2 vectorfuerza;
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
             vectorfuerza = new Vector2(-mousePosWorld.x, -mousePosWorld.y);

         
        }
        if (Input.GetMouseButtonUp(0))
        {
          
            rigidbody.AddForce(vectorfuerza, ForceMode2D.Impulse);
          
        }
    }


    private void LookTowards (Vector2 direction)
	{
		
		transform.localRotation = Quaternion.LookRotation (Vector3.forward, direction);
	}
}
