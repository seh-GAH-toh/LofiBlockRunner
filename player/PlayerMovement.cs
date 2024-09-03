using Godot;

public partial class PlayerMovement : CharacterBody3D
{
	public const float speed = 5.0f;

	public override void _PhysicsProcess(double delta)
	{
        // Get input direction
        float direction = Input.GetAxis("move_left","move_right");

		// Velocity = direction * speed
        Velocity = new Vector3(direction * speed, 0, 0);

		// Move
        MoveAndSlide();
	}
}
