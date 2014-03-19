#pragma strict

var SCALE = -0.0625;
var range = 0;

function Start() {
	renderer.material.mainTextureScale = Vector2(transform.localScale.x*SCALE, transform.localScale.z*SCALE);
	renderer.material.mainTextureOffset = Vector2(SCALE, range*SCALE);
}

function Update() {

}

function Offset() {
	return range*SCALE;
}