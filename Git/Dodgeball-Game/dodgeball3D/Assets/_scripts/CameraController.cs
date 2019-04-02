using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WiimoteApi;//wiimote library
public class CameraController : MonoBehaviour {
	private BoxCollider bc;
	//Wiimote object
	private Wiimote wiimote;

	public float camshiftHorizontal = 0;
    public float camshiftVertical = 0;
    public bool hitFlag = false;
        // Player properties
    public static bool isAlive;
	public static int hitCount;
	public static float timeSurvived;

    public static float maxY;

	// Use this for initialization
	void Start () {
		bc = GetComponent<BoxCollider> ();
        // Initialize Player properties
        isAlive = true;
        hitCount = 5;
        maxY = transform.position.y;
		//Initializes wiimote
		InitWiiMote();
    }
	
	// Update is called once per frame
	void LateUpdate () {
        if (isAlive == false)
        {
            //Do something for dying
            Debug.Log("ded");
        }

        if (Input.GetKey (KeyCode.LeftArrow)){
			//transform.position = transform.position + new Vector3 (-camshift, 0);
			transform.position = (transform.position + new Vector3 (-camshiftHorizontal, 0)* Time.fixedDeltaTime);
		}
		if(Input.GetKey (KeyCode.RightArrow)){
			transform.position = (transform.position + new Vector3 (camshiftHorizontal, 0)* Time.fixedDeltaTime);
		}
        if(Input.GetKey (KeyCode.UpArrow) && transform.position.y < maxY){
            transform.position = (transform.position + new Vector3 (0, camshiftVertical)* Time.fixedDeltaTime);
        }
        if(Input.GetKey (KeyCode.DownArrow)){
            transform.position = (transform.position + new Vector3 (0, -camshiftVertical)* Time.fixedDeltaTime);
        }

        // if (wiimote.Button.d_left){
        //     transform.position= (transform.position + new Vector3 (-camshift, 0)* Time.fixedDeltaTime);
        // //     rb.AddForce(movement * speed); 
        // }
        // if (wiimote.Button.d_right){
        //     transform.position= (transform.position + new Vector3 (camshift, 0)* Time.fixedDeltaTime);
        // }

		//Wiimote manager checks to see if wiimote is still connected
		if (!WiimoteManager.HasWiimote())
			return;
		int ret;
		//This do while loop is used to make sure all data from wiimote has been read
        do
        {
            ret = wiimote.ReadWiimoteData();
        } while (ret > 0); 
		//GetIRMidpoint provides position data where pointer[0] is x direction from 0-1
		//and pointer[1] is y direction from 0-1
		float[] pointer = wiimote.Ir.GetIRMidpoint(true);
        float x = (float)pointer[0];
        float y = (float)pointer[1];
        int horizontal = 0;
        int vertical = 0;
        // print(x.ToString());
        if (x > 0.1 || y > 0.1){
            if (x > 0.1 && x > 0.65){ //left movement
                camshiftHorizontal = -camshiftHorizontal;
                print("left");
            }
            else if(x > 0.1 && x < 0.35){ //right movement
                print("right");
            }
            else{
                camshiftHorizontal = 0;
            }
            //Vertical
            if (y > 0.1 && y < 0.35){ //down movement
                print("down");
                camshiftVertical = -camshiftVertical;
            }
            else if(y > 0.1 && y > 0.65){
                print("up");
            }
            else{
                camshiftVertical = 0;
            }
            transform.position= (transform.position + new Vector3 (camshiftHorizontal, camshiftVertical)* Time.fixedDeltaTime);
        }
	}
	void OnApplicationQuit() {//Called when appliation is about to exit
        FinishedWithWiimotes();//cleans up the wii remote connection
        print("Goodbye!");
    }

    // Check for ball trigger
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ball")
        {
            isAlive = PlayerHit(1);
        }
        else
        {
            isAlive = PlayerHit(-1);
        }
        

    }

    private bool PlayerHit(int damage)
    {
        if (hitCount - damage > 0)
        {
            hitCount = hitCount - damage;
            return true;
        }
        else
        {
            hitCount = 0;
            return false;
        }
    }

	void InitWiiMote(){
        WiimoteManager.FindWiimotes(); // Poll native bluetooth drivers to find Wiimotes
        if (!WiimoteManager.HasWiimote()){ //If the wiimote manager does not find a wiimote
            print("Wiimote is not connected!");
            return; 
        }
        else{ //If wiimote is connected
            wiimote = WiimoteManager.Wiimotes[0]; //Provides the wiimote object
            print("Wiimote is connected!");
            //Sets up IR camera and the read type to only give position info on where IR dots are.
            wiimote.SetupIRCamera(IRDataType.BASIC);
            //wiimote.SetupIRCamera(IRDataType.EXTENDED);
            //sets the LEDS on the wiimote
			wiimote.SendPlayerLED(true, false, true, true); 
        }
    }
	//Used to disconnect from the wiimote when game is over.
	void FinishedWithWiimotes() {
        //Called to disconnect from the wii remote
        if (!WiimoteManager.HasWiimote()) { return; }
		//Cleans up connected wiimotes safely
        WiimoteManager.Cleanup(wiimote);
        print("Remote is cleaned");
    }

}
