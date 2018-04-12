var TankCamera : GameObject;
var ThePlayer : GameObject;
var ExitTrigger : GameObject;
var Tank : GameObject;
var TriggerCheck : int;

function OnTriggerEnter (col : Collider) {
	TriggerCheck = 1;
}

function OnTriggerExit (col : Collider) {
	TriggerCheck = 0;
}

function Update () {
	if (TriggerCheck == 1) {
		if (Input.GetButtonDown("Action")) {
			TankCamera.SetActive(true);
			ThePlayer.SetActive(false);
			ExitTrigger.SetActive(true);
		}
	}
}