#pragma strict
//This script is used for the player to activate objects, by looking at the object and pressing the left mouse button | recommended for first or third person view
var hit : RaycastHit; //used to detect interactable objects
private var activationDistance : int = 5; //must be at least this distance from object to activate it

function Update() {
	//When Left-Mouse-Button is clicked
    if(Input.GetKey('e')) {
		//Raycast outward
		if(Physics.Raycast(transform.position, transform.forward, hit, activationDistance)) {
			//if there is an object tagged as "Interact"
			if(hit.transform.tag == "Interact") {
				//call activate | this will call the activate function on whichever script is attached to the lever, as long as it has an Activate() function
				hit.transform.gameObject.SendMessage("Activate");
			}
		}
	}
}