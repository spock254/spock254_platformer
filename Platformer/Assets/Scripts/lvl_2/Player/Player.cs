using UnityEngine;
using System.Collections;

//[RequireComponent(typeof(PlayerHP))]
[RequireComponent(typeof(Controller2D))]
public class Player : MonoBehaviour {

	[Header("Player Controller")]
	[Range(0.1f,10)]
    [HideInInspector]
	public float maxJumpHeight = 4f;
	[Range(0.1f,10)]
    [HideInInspector]
    public float minJumpHeight = 1f;
	[Range(0.1f,2f)]
    [HideInInspector]
    public float timeToJumpApex = 0.4f;
	[Range(1,12)]
    [HideInInspector]
    public float fastSpeed = 9;
	[Range(1,12)]
    [HideInInspector]
    public float slowSpeed = 6;
	[Range(0,10)]
    [HideInInspector]
    public float wallSlideSpeedMax;
	[Range(0.01f,3f)]
    [HideInInspector]
    public float deltaX = 1f;
    [HideInInspector]
    [Range(0,2)]
	public float accleretationInAir = 0.2f;
    [HideInInspector]
    [Range(0,2)]
	public float accelerationOnGround = 0.1f;

	float velosityXSmoothing;
	float maxJumpVelocity;
	float minJumpVelocity;
	float currentSpeed;
	float gravity;
	float targetVelosityX;

	[HideInInspector]
	public Vector3 velocity;
	[HideInInspector]
	public Vector2 _input;
	Controller2D _controller2D;

	[Header("Wall Jump")]
    [HideInInspector]
    public Vector2 wallJumpClimb;
    [HideInInspector]
    public Vector2 wallJumpOff;
    [HideInInspector]
    public Vector2 wallLeap;

	void Start () {
		_controller2D = GetComponent<Controller2D>();

		gravity = -(2 * maxJumpHeight) / Mathf.Pow(timeToJumpApex,2);
		maxJumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
		minJumpVelocity = Mathf.Sqrt(2 * Mathf.Abs(gravity) * minJumpHeight);
	}
	void Update(){
		_input = new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"));
		int wallDir = (_controller2D.collitions.left)?-1:1;
		if(this.transform.position.y < -12){
			Application.LoadLevel(Application.loadedLevel);
		}

		bool _wallSlide = false;
		if((_controller2D.collitions.right || _controller2D.collitions.left) && !_controller2D.collitions.below && velocity.y < 0){
			_wallSlide = true;
			if(velocity.y < -wallSlideSpeedMax){
				velocity.y = -wallSlideSpeedMax;
			}
		}
		if(_controller2D.collitions.above || _controller2D.collitions.below){
			velocity.y = 0;
		}


		if(Input.GetKeyDown(KeyCode.Space)){
			if(_wallSlide){
				if(wallDir == _input.x){
					velocity.x = -wallDir * wallJumpClimb.x;  // +currentSpeed; -->y
					velocity.y = wallJumpClimb.y+currentSpeed*deltaX;
				}else if(_input.x == 0){
					velocity.x = -wallDir * wallJumpOff.x;
					velocity.y = wallJumpOff.y+currentSpeed*deltaX;
				}else{
					velocity.x = -wallDir * wallLeap.x;
					velocity.y = wallLeap.y+currentSpeed*deltaX;
				}
			}
			if(_controller2D.collitions.below){
				velocity.y = maxJumpVelocity+currentSpeed*deltaX;
			}
		}
		if(Input.GetKeyUp(KeyCode.Space))
        {
			if(velocity.y > minJumpVelocity){
				velocity.y = minJumpVelocity;
			}
		}
		if(Input.GetKeyDown(KeyCode.Space) && _input.y == -1){
			velocity.y = 0;
			_controller2D.playerInput = -1;
		}

		if(Input.GetKey(KeyCode.LeftShift)){
			currentSpeed  = fastSpeed;
		}else{
			currentSpeed = slowSpeed;
		}

		targetVelosityX = _input.x * currentSpeed;
		velocity.x = Mathf.SmoothDamp(velocity.x,targetVelosityX,ref velosityXSmoothing,
		                              (_controller2D.collitions.below)?
										accelerationOnGround
										:accleretationInAir);
		velocity.y += gravity * Time.deltaTime;
		_controller2D.Move(velocity * Time.deltaTime);
	}
}
