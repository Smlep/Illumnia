#pragma strict
//This script moves an object from one position to another, and if activated again, will move it back
var myObject : Transform; //object to move
var speed : float = 5; //how fast the objects moves
var newPos : Vector3; //where we want the object to move to
private var startPos : Vector3; //object's starting position
private var moved = false; //whether or not object should move to newPos or startPos
private var endLoop = true; //stop moving object

function Start() {
	//get object's starting position
	startPos = myObject.transform.position;
}
function Activate() {
	if(moved == false) {
		endLoop = true;
		//wait 1 frame | if object is still trying to move somewhere, let it know to stop
		yield;
		//tell object to move to newPos
		MoveToNew();
	}
	else {
		endLoop = true;
		//wait 1 frame | if object is still trying to move somewhere, let it know to stop
		yield;
		//tell object to move to startPos
		MoveToStart();
	}
	//moved is true or false
	moved = !moved;
}
function MoveToNew() {
	endLoop = false;
	while(endLoop == false) {
		//Move object to newPos
		myObject.transform.position = Vector3.MoveTowards(myObject.transform.position, newPos, speed * Time.deltaTime);
		
		//if object is close enough to newPos, make sure while loop ends
		var distanceBetween = Vector3.Distance(myObject.transform.position, newPos);
		if(distanceBetween < 0.1) {
			myObject.transform.position = newPos;
			endLoop = true;
		}
		yield;
	}
}
function MoveToStart() {
	endLoop = false;
	while(endLoop == false) {
		//Move object to startPos
		myObject.transform.position = Vector3.MoveTowards(myObject.transform.position, startPos, speed * Time.deltaTime);
		
		//if object is close enough to startPos, make sure while loop ends
		var distanceBetween = Vector3.Distance(myObject.transform.position, startPos);
		if(distanceBetween < 0.1) {
			myObject.transform.position = startPos;
			endLoop = true;
		}
		yield;
	}
}