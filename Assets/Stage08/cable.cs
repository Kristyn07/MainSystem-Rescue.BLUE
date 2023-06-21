using UnityEngine;

public class cable : MonoBehaviour
{
	private LineRenderer lineRenderer;
	//[SerializeField] Transform startSocket;
	//[SerializeField] Transform endSocket;
	//[SerializeField] LineRenderer lineRenderer;
	[SerializeField] float cableThickness = 0.1f;
	[SerializeField] Color cableColor = Color.white;
	public Transform[] controlPoints;



	private int segments = 500;

	private void Start()
	{
		lineRenderer = GetComponent<LineRenderer>();
		lineRenderer.positionCount = segments;
		if (lineRenderer == null)
		{
			lineRenderer = gameObject.AddComponent<LineRenderer>();
		}

		lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
		lineRenderer.startWidth = cableThickness;
		lineRenderer.endWidth = cableThickness;
		//lineRenderer.positionCount = 3;
		lineRenderer.startColor = cableColor;
		lineRenderer.endColor = cableColor;
	}

	private void Update()
	{
		// Set the start and end positions of the line renderer to the positions of the two sockets
		//lineRenderer.SetPosition(0, startSocket.position);
		//lineRenderer.SetPosition(1, endSocket.position);
		
		for (int i = 0; i < segments; i++)
		{
			float t = (float)i / (segments - 1);
			lineRenderer.SetPosition(i, CalculatePoint(t));
		}
		//GetCurvePoint(startSocket.position, (startSocket.position / 2), endSocket.position, 20f);
		//lineRenderer.SetPosition(2, (endSocket.position - startSocket.position)/2);
	}

	public Vector3 GetCurvePoint(Vector3 a, Vector3 b, Vector3 c, float t)
	{
		Vector3 p1 = Vector3.Lerp(a, b, t);
		Vector3 p2 = Vector3.Lerp(b, c, t);
		return Vector3.Lerp(p1, p2, t);
	}


	

   
    

    private Vector3 CalculatePoint(float t)
    {
        int numSections = controlPoints.Length - 3;
        int currentIndex = Mathf.Min(Mathf.FloorToInt(t * (float)numSections), numSections - 1);
        float u = t * (float)numSections - (float)currentIndex;

        Vector3 a = controlPoints[currentIndex].position;
        Vector3 b = controlPoints[currentIndex + 1].position;
        Vector3 c = controlPoints[currentIndex + 2].position;
        Vector3 d = controlPoints[currentIndex + 3].position;

        return .5f * (
            (-a + 3f * b - 3f * c + d) * (u * u * u)
            + (2f * a - 5f * b + 4f * c - d) * (u * u)
            + (-a + c) * u
            + 2f * b
        );
    }
}
