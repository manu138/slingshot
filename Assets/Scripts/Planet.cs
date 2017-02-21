using UnityEngine;

[RequireComponent (typeof (Rigidbody2D))]
public class Planet : MonoBehaviour 
{
	[SerializeField]
	private float maxTorque;
	private new Rigidbody2D rigidbody;
    [SerializeField]
    private int speed = 100;

    public float rango;
    public Vector3 posB;

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



            posB = new Vector3(transform.position.x + mousePosWorld.x, transform.position.y + mousePosWorld.y, 0);
            rango = Mathf.Clamp(posB.magnitude, 0, 10);
            lineRenderer.SetPosition(1, posB);
           
        }
        

    }
    public void AplicarFuerza(int rango)
    {
        if (rango >= 10)
            rigidbody.AddForce(posB.normalized * speed, ForceMode2D.Impulse);
    }
}
