using UnityEngine;

[RequireComponent (typeof (Rigidbody2D))]
public class Planet : MonoBehaviour 
{
	[SerializeField]
	private float maxTorque;
	private new Rigidbody2D rigidbody;
    [SerializeField]
    private int speed;

    private LineRenderer lineRenderer;



    private void Awake ()
	{
		rigidbody = GetComponent<Rigidbody2D> ();

        lineRenderer = GetComponent<LineRenderer>();
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



            Vector3 posB = new Vector3(  transform.position.x+mousePosWorld.x, transform.position.y+ mousePosWorld.y  , transform.position.z+mousePosWorld.z  );
           float b= Mathf.Clamp(posB.magnitude, transform.position.magnitude, 10);

            lineRenderer.SetPosition(0, posB);
            rigidbody.AddForce(posB.normalized * speed, ForceMode2D.Impulse);

        }
    }
}
