using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]
public class Controller2D : MonoBehaviour {
	
	[Header("Ray")]
	[SerializeField]
	LayerMask _collitionMask;
	const float skinWight = 0.15f;
	public int horizontalRayCount = 4;
	public int verticalRayCount = 4;

	float _maxClimbAngle = 80f;
	[HideInInspector]
	public float _horizontalRaySpacing;
	[HideInInspector]
	public float _verticalRatSpacing;

	public float playerInput;

	BoxCollider2D _colloder;
	[HideInInspector]
	public RaycastOrigin _raycastOrigin;
	[HideInInspector]
	public CollitionInfo collitions;
	[HideInInspector]
	public Vector2 _rayOriginHorizontal;
	[HideInInspector]
	public float _diractionX;
	[HideInInspector]
	public bool attackValue;
    [HideInInspector]
    public bool alowWallJump;



    void Start () {
		collitions.faceDir = 1;
		_colloder = GetComponent<BoxCollider2D>();
		CalculateRaySpacing();
	
	}

	public void Move(Vector3 velocity){
		UpdateRaycastOrigin();
		collitions.Reset ();
		if(velocity.x != 0){
			collitions.faceDir = (int)Mathf.Sign(velocity.x);
		}
		if(velocity.y != 0){
			VerticalCollitions(ref velocity);
			VerticalCollitions2(ref velocity);
		}
		if(velocity.x != 0)
			HorizontalCollitions(ref velocity);

		transform.Translate(velocity);
	}
	void HorizontalCollitions(ref Vector3 velosity){
		_diractionX = collitions.faceDir;
		float _rayLangth = Mathf.Abs(velosity.x)+skinWight;

		if(Mathf.Abs(velosity.x)<skinWight){
			_rayLangth = 2*skinWight;
		}

		for (int i = 0; i < horizontalRayCount; i++) {
			_rayOriginHorizontal = (_diractionX == -1)?_raycastOrigin.bottomLeft:_raycastOrigin.bottomRight;
			_rayOriginHorizontal += Vector2.up * (_horizontalRaySpacing * i);
			RaycastHit2D hit = Physics2D.Raycast(_rayOriginHorizontal,Vector2.right*_diractionX,_rayLangth,_collitionMask);

			Debug.DrawRay(_rayOriginHorizontal,Vector2.right*_diractionX*_rayLangth,Color.yellow);

			if(hit){
                if (hit.collider.tag == "notClimb")
                    alowWallJump = false;
                else
                    alowWallJump = true;

                float _slopeAngle = Vector2.Angle(hit.normal,Vector2.up);
				if(_slopeAngle >89){ // ?
				//	Debug.Log("wall");
					collitions.nearWall = true;
				}
				if(i==0 && _slopeAngle <= _maxClimbAngle){
					float _distToSlopeStart = 0f;
					if(_slopeAngle != collitions.slopeAngleOld){
						_distToSlopeStart = hit.distance - skinWight;
						velosity.x -= _distToSlopeStart * _diractionX;
					}

					ClimbSlope(ref velosity,_slopeAngle);
					velosity.x += _distToSlopeStart * _diractionX;
				}
				if(!collitions.climbingSlope || _slopeAngle > _maxClimbAngle){
					velosity.x = (hit.distance - skinWight)*_diractionX;
					_rayLangth = hit.distance;

					if(collitions.climbingSlope){
						velosity.y = Mathf.Tan(collitions.slopeAngle * Mathf.Deg2Rad) * Mathf.Abs (velosity.x);
					}

					collitions.left = _diractionX == -1;
					collitions.right = _diractionX == 1;
				}
			}
		}
	}

	void ClimbSlope(ref Vector3 velosity, float slopeAngle){
		float _moveDistanse = Mathf.Abs(velosity.x);
		float _climbVelisityY = Mathf.Sin(slopeAngle * Mathf.Deg2Rad) * _moveDistanse;
		if(velosity.y <= _climbVelisityY){
			velosity.y = _climbVelisityY;
			velosity.x = Mathf.Cos(slopeAngle * Mathf.Deg2Rad) * _moveDistanse * Mathf.Sin(velosity.x);
			collitions.below = true;
			collitions.climbingSlope = true;
			collitions.slopeAngle = slopeAngle;
		}
	}

	void VerticalCollitions(ref Vector3 velosity){
		float _diractionY = Mathf.Sign(velosity.y);
		float _rayLangth = Mathf.Abs(velosity.y)+skinWight;


		for (int i = 0; i < verticalRayCount; i++) {
			//Vector2 _rayOrigin = (_diractionY == -1)?_raycastOrigin.bottomLeft:_raycastOrigin.topLeft;
			Vector2 _rayOrigin = (_diractionY == -1)?_raycastOrigin.bottomRight:_raycastOrigin.topRight;
			//_rayOrigin += Vector2.right * (_verticalRatSpacing * i * velosity.x);
			_rayOrigin += Vector2.left * (_verticalRatSpacing * i * velosity.x);

            RaycastHit2D hit = Physics2D.Raycast(_rayOrigin,Vector2.up*_diractionY,_rayLangth,_collitionMask);

			Debug.DrawRay(_rayOrigin,Vector2.up*_diractionY*_rayLangth,Color.yellow);


            if (hit && hit.distance != 0){ //&& hit.distance != 0
				if(hit.collider.tag == "ThrowJump"){
					if(_diractionY == 1 || hit.distance == 0){
						continue;
					}
					if(playerInput == -1){
                      //  playerInput = 1;
                        continue;
					}
				}
				velosity.y = (hit.distance - skinWight)*_diractionY;
				_rayLangth = hit.distance;

				if(collitions.climbingSlope){
					velosity.x = velosity.y / Mathf.Tan(collitions.slopeAngle * Mathf.Deg2Rad) * Mathf.Sign(velosity.x);
				}
				
				collitions.below = _diractionY == -1;
				collitions.above = _diractionY == 1;
			}
            playerInput = 1;
		}
	}

	void VerticalCollitions2(ref Vector3 velosity){
		float _diractionY = Mathf.Sign(velosity.y);
		float _rayLangth = Mathf.Abs(velosity.y)+skinWight;
		
		
		for (int i = 0; i < verticalRayCount; i++) {

			Vector2 _rayOrigin = (_diractionY == -1)?_raycastOrigin.bottomLeft:_raycastOrigin.topLeft;
			_rayOrigin += Vector2.right * (_verticalRatSpacing * i * velosity.x);
			//_rayOrigin += Vector2.left * (_verticalRatSpacing * i * velosity.x);
			
			RaycastHit2D hit = Physics2D.Raycast(_rayOrigin,Vector2.up*_diractionY,_rayLangth,_collitionMask);
			
			//Debug.DrawRay(_rayOrigin,Vector2.up*_diractionY*_rayLangth,Color.yellow);
			
			if(hit && hit.distance != 0){ //&& hit.distance != 0
				
				if(hit.collider.tag == "ThrowJump"){
					if(_diractionY == 1 || hit.distance == 0){
						continue;
					}
					if(playerInput == -1){
					//	playerInput = 1;
						continue;
					}
				}
				velosity.y = (hit.distance - skinWight)*_diractionY;
				_rayLangth = hit.distance;
				
				if(collitions.climbingSlope){
					velosity.x = velosity.y / Mathf.Tan(collitions.slopeAngle * Mathf.Deg2Rad) * Mathf.Sign(velosity.x);
				}
				
				collitions.below = _diractionY == -1;
				collitions.above = _diractionY == 1;
			}
			playerInput = 1;
		}
	}

	void UpdateRaycastOrigin(){
		Bounds bounds = _colloder.bounds;
		bounds.Expand(skinWight*-2);

		_raycastOrigin.bottomLeft = new Vector2(bounds.min.x,bounds.min.y);
		_raycastOrigin.bottomRight = new Vector2(bounds.max.x,bounds.min.y);
		_raycastOrigin.topLeft = new Vector2(bounds.min.x,bounds.max.y);
		_raycastOrigin.topRight = new Vector2(bounds.max.x,bounds.max.y);
	}

	void CalculateRaySpacing(){
		Bounds bounds = _colloder.bounds;
		bounds.Expand(skinWight*-2);

		horizontalRayCount = Mathf.Clamp(horizontalRayCount,2,int.MaxValue);
		verticalRayCount = Mathf.Clamp(verticalRayCount,2,int.MaxValue);

		_horizontalRaySpacing = bounds.size.y/(horizontalRayCount-1);
		_verticalRatSpacing = bounds.size.x/(verticalRayCount-1);
	}

	public struct RaycastOrigin {
		public Vector2 topLeft;
		public Vector2 topRight;
		public Vector2 bottomLeft;
		public Vector2 bottomRight;
	}
	public struct CollitionInfo {
		public bool above;
		public bool below;
		public bool left;
		public bool right;

		public bool climbingSlope;
		public float slopeAngle;
		public float slopeAngleOld;
		public int faceDir;
		public bool nearWall;

		public void Reset(){
			slopeAngleOld = slopeAngle;
			slopeAngle = 0;
			climbingSlope = false;
			above = false;
			below = false;
			left = false;
			right = false;
			nearWall = false;
		}
	}
}
