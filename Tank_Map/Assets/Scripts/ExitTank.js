var TankCamera : GameObject;
var ThePlayer : GameObject;
var ExitTrigger : GameObject;
var Tank : GameObject;
var ExitPlace : GameObject;

function Update () {
	if(Input.GetButtonDown("Action")) {
		ThePlayer.SetActive(true);
		ThePlayer.transform.position = ExitPlace.transform.position;
		TankCamera.SetActive(false);
		ExitTrigger.SetActive(false);
	}
}