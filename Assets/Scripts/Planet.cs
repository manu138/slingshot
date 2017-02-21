using UnityEngine;

[RequireComponent (typeof (Rigidbody2D))]
public class Planet : MonoBehaviour 
{
	[SerializeField]
	private float maxTorque;
	private new Rigidbody2D rigidbody;
    [SerializeField]
    private int speed;


    private void Awake ()
	{
		rigidbody = GetComponent<Rigidbody2D> ();
	}

	private void Start () 
	{
		AddRandomTorque ();	
	}
	
	private void AddRandomTorque ()
	{
		float torque = Random.Range (-maxTorque, maxTorque);
		rigidbody.AddTorque (torque);
	}
    void Update()
    {
       
      


        if (Input.GetMouseButton(0))
        {
            Vector3 mousePosScreen = Input.mousePosition;
            Vector3 mousePosWorld = Camera.main.ScreenToWorldPoint(mousePosScreen);



            Vector3 posB = new Vector3(mousePosWorld.x - transform.position.x, mousePosWorld.y - transform.position.y, mousePosWorld.z - transform.position.z);
            Mathf.Clamp(posB.magnitude, 0, 10);


            rigidbody.AddForce(posB.normalized * speed, ForceMode2D.Impulse);

        }
    }
}
