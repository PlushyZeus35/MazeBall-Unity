using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class Movimiento : MonoBehaviour {
	
	//Poner publico para poder ser editado desde unity
	public float speed=500;
	public Text pointsText;
	public Text timeText;
	public Text finalPointsText;
	public Image finalGameCanvas;
	protected int points;
	protected float time;
	protected Rigidbody rig;
	
	// Use this for initialization
	void Start () {
		points = 0;
		time = Time.time;
		pointsText.text = "Puntos: " + points;
		rig = GetComponent<Rigidbody>();
    }
	
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Point") 
		{
			points++;
			pointsText.text = "Puntos: " + points;
			other.gameObject.SetActive(false);
		}
	}
	
	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Finish") 
		{
			finishGame();
		}
		if(collision.gameObject.tag == "Death"){
			reloadScene();
		}
	}
	
	void FixedUpdate()
	{
		// Add force to player if any movement key is pressed.
		Vector3 direction= new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));
		rig.AddForce(direction*speed*Time.deltaTime);
	}

	void reloadScene(){
		// Get actual scene index
		int sceneIndex = SceneManager.GetActiveScene().buildIndex;
		// Reload actual scene
		SceneManager.LoadScene(sceneIndex);
	}

	void finishGame(){
		// Set stats in UI
		float totalTime = (Time.time - time);
		totalTime = Mathf.Round(totalTime * 100f) / 100f;
		finalGameCanvas.gameObject.SetActive(true);
		finalPointsText.text = "Puntos conseguidos: " + points;
		timeText.text = "Tiempo total: " + totalTime;
		// Desactive player movement
		this.rig.isKinematic=true;
	}
}
