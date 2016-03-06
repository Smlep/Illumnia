#pragma strict
var myObject : Transform[];

function Activate() {
	//add random force to myObject(s)
	for(var children in myObject) {
		var child : Transform = children as Transform;
		child.GetComponent.<Rigidbody>().constraints = RigidbodyConstraints.None;
		child.GetComponent.<Rigidbody>().useGravity = true;
		var randomVector : Vector3 = Vector3(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
		child.GetComponent.<Rigidbody>().AddForce(2 * randomVector);
		
		child.transform.parent = null;
	}
}