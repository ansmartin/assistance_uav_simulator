using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UAV : MonoBehaviour {

    public Vector3 position_received;

    static public ComMqtt objMqtt;

    static private Vector3 newPosition;
    static private Vector3 newRotation;

    public float speed;
    private Vector3 oldPosition;
	
	public DrawLines[] scripts;
	
	private bool isEqual(float x, float y, float diff)
	{
		if (x==y)
			return true;
		if (((x + diff) <= y) && (((x - diff) >= y)))
			return true;
		return false;
	}
		
	

	// Use this for initialization
	void Start () {
        //GameObject UAV;
        objMqtt = new ComMqtt();
        //objMqtt.StartMosquittoCMD();
        objMqtt.ConfigMqttConnection();
        newPosition = transform.position;
    }

    float diff = 0.1f;
    Vector3 temp;

	// Update is called once per frame
	void FixedUpdate () {
		/******/
		
		temp = newPosition;
		newPosition = objMqtt.getPosition();
		
		if (isEqual(oldPosition.x, newPosition.x, diff) && isEqual(oldPosition.y, newPosition.y, diff) && isEqual(oldPosition.z, newPosition.z, diff))
			return;
		oldPosition = temp;
		
		foreach (DrawLines script in scripts) 
		{
			script.addPoint(newPosition);
		}
		
		
		
		/******/

        // ----------------------------------------------------------------------------
        // POSITION 
        // ----------------------------------------------------------------------------
        //oldPosition = newPosition;
        //newPosition = objMqtt.getPosition();
        print("Update(UAV). Position (x, y, z): " + newPosition);

        transform.position = newPosition;
        //transform.position = Vector3.MoveTowards(transform.position, newPosition, 10);
       

        // Draw a Line
        //Color color = new Color(1.0f, 0.0f, 0.0f);
        Debug.DrawLine(oldPosition, newPosition, Color.red, 250);

        // ----------------------------------------------------------------------------


        // ----------------------------------------------------------------------------
        // ORIENTATION 
        // ----------------------------------------------------------------------------
        newRotation = objMqtt.getRotation();
        print("Update(UAV). Rotation (pitch, yaw, roll): " + newRotation);
        transform.rotation = Quaternion.Euler(newRotation);

        // ----------------------------------------------------------------------------


    }
}
