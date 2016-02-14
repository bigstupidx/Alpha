using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent (typeof (Controller2D))]
public class Player : MonoBehaviour {

	private bool m_FacingRight = true;  // For determining which way the player is currently facing.

	public float maxJumpHeight = 4;
	public float minJumpHeight = 1;
	public float timeToJumpApex = .4f;
	float accelerationTimeAirborne = .2f;
	float accelerationTimeGrounded = .1f;
	public float moveSpeed = 6;

	public Vector2 wallJumpClimb;
	public Vector2 wallJumpOff;
	public Vector2 wallLeap;

	public float wallSlideSpeedMax = 3;
	public float wallStickTime = .25f;
	float timeToWallUnstick;

	float gravity;
	float maxJumpVelocity;
	float minJumpVelocity;
	Vector3 velocity;
	float velocityXSmoothing;

	Controller2D controller;
	private Animator m_Anim; 

	void Start() {
		m_Anim = GetComponent<Animator>();

		controller = GetComponent<Controller2D> ();

		gravity = -(2 * maxJumpHeight) / Mathf.Pow (timeToJumpApex, 2);
		maxJumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
		minJumpVelocity = Mathf.Sqrt (2 * Mathf.Abs (gravity) * minJumpHeight);
		//print ("Gravity: " + gravity + "  Jump Velocity: " + maxJumpVelocity);
	}

	void Update() {

		if (controller.collisions.below) {
			m_Anim.SetBool ("Grounded", true);
		}

		Vector2 input = new Vector2 (CrossPlatformInputManager.GetAxisRaw ("Horizontal"), CrossPlatformInputManager.GetAxisRaw ("Vertical"));

			// If the input is moving the player right and the player is facing left...
			if (input.x > 0 && !m_FacingRight) {
				// ... flip the player.
				Flip ();
			}
		// Otherwise if the input is moving the player left and the player is facing right...
		else if (input.x < 0 && m_FacingRight) {
				// ... flip the player.
				Flip ();
			}

			if (CrossPlatformInputManager.GetAxisRaw ("Horizontal") != 0) {			
				m_Anim.SetBool ("Walking", true);
			} else {
				m_Anim.SetBool ("Walking", false);
			}

			int wallDirX = (controller.collisions.left) ? -1 : 1;

			float targetVelocityX = input.x * moveSpeed;
			velocity.x = Mathf.SmoothDamp (velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below) ? accelerationTimeGrounded : accelerationTimeAirborne);

			bool wallSliding = false;
			if ((controller.collisions.left || controller.collisions.right) && !controller.collisions.below && velocity.y < 0) {
				wallSliding = true;

				if (velocity.y < -wallSlideSpeedMax) {
					velocity.y = -wallSlideSpeedMax;
				}

				if (timeToWallUnstick > 0) {
					velocityXSmoothing = 0;
					velocity.x = 0;

					if (input.x != wallDirX && input.x != 0) {
						timeToWallUnstick -= Time.deltaTime;
					} else {
						timeToWallUnstick = wallStickTime;
					}
				} else {
					timeToWallUnstick = wallStickTime;
				}

			}

			if (CrossPlatformInputManager.GetButtonDown ("Jump")) {
			
				m_Anim.SetBool ("Grounded", false);

				if (wallSliding) {
					if (wallDirX == input.x) {
						velocity.x = -wallDirX * wallJumpClimb.x;
						velocity.y = wallJumpClimb.y;
					} else if (input.x == 0) {
						velocity.x = -wallDirX * wallJumpOff.x;
						velocity.y = wallJumpOff.y;
					} else {
						velocity.x = -wallDirX * wallLeap.x;
						velocity.y = wallLeap.y;
					}
				}
				if (controller.collisions.below) {
					velocity.y = maxJumpVelocity;
				}
			}
		if (CrossPlatformInputManager.GetButtonUp ("Jump")) {
				if (velocity.y > minJumpVelocity) {
					velocity.y = minJumpVelocity;
				}
			}

			velocity.y += gravity * Time.deltaTime;
			controller.Move (velocity * Time.deltaTime, input);

			if (controller.collisions.above || controller.collisions.below) {
				velocity.y = 0;
		}
	}

	private void Flip()
	{
		// Switch the way the player is labelled as facing.
		m_FacingRight = !m_FacingRight;

		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}