#pragma strict
//This script plays the levers' animations, when activated.
var animations : String[]; //name of animations to play
private var interval : int = 0; //which animation we're on

//set starting animation to end | lever will sit idle, instead of playing animation at start
function Start () {
    var anim : String = GetComponent.<Animation>().clip.name;
    GetComponent.<Animation>()[anim].time = GetComponent.<Animation>()[anim].length;
}
function Activate() {
    //play next animation
        yield;
        GetComponent.<Animation>().CrossFade(animations[interval]);
        interval += 1;
        //reset to first animation
        if(interval >= animations.length) {
            interval = 0;
            
        
    }
    
}
