#pragma strict
var myObject : Transform[]; //light(s)
var maxIntensity : float = 1; //the intesnsity of the light
var speed : float = 2; //how fast the lights turn on and off
private var lightsOn = true; //whether lights are on or off
private var endLoop = true; //stop loop

function Start() {
	//check if lights are on or off
	if(myObject[0]) {
		if(myObject[0].GetComponent(Light)) {
			if(myObject[0].GetComponent(Light).enabled == true) {
				lightsOn = true;
			}
			else {
				lightsOn = false;
			}
		}
		else {
			Debug.LogWarning("This is not a Light! You have assigned a GameObject without a Light component to the LightSwitch script.");
		}
	}
}
function Activate() {
	endLoop = true;
	yield;
	
	if(lightsOn == true) {
		if(myObject[0].GetComponent(Light).intensity > 0) {
			lightsOn = false;
			LightsOff();
		}
	}
	else {
		if(myObject[0].GetComponent(Light).intensity < maxIntensity) {
			lightsOn = true;
			LightsOn();
		}
	}
}
function LightsOff() {
	endLoop = false;
	while(endLoop == false) {
		//turn all lights off
		for(var children in myObject) {
			var child : Transform = children as Transform;
			child.GetComponent(Light).intensity -= speed * Time.deltaTime;
			if(child.GetComponent(Light).intensity <= 0) {
				endLoop = true;
			}
		}
		yield;
	}
}
function LightsOn() {
	endLoop = false;
	while(endLoop == false) {
		//turn all lights on
		for(var children in myObject) {
			var child : Transform = children as Transform;
			child.GetComponent(Light).intensity += speed * Time.deltaTime;
			if(child.GetComponent(Light).intensity >= maxIntensity) {
				endLoop = true;
			}
		}
		yield;
	}
}