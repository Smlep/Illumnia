#pragma strict
var myObject : Transform; //object to spawn
var spawnPos : Transform[]; //emptyGameObject(s) act as the spawn positions
var randomColors : Color[];

function Activate() {
	//spawn myObject at every spawnPos
	for(var children in spawnPos) {
		var child : Transform = children as Transform;
		var obj : Transform = Instantiate(myObject, child.transform.position, child.transform.rotation);
		obj.GetComponent.<Renderer>().material.color = randomColors[Random.Range(0, (randomColors.length))];
	}
}