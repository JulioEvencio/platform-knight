using Godot;
using System;

namespace PlataformKnight
{
	public partial class Player : CharacterBody2D
	{
		private const float SPEED = 130.0f;
		private const float JUMP_VELOCITY = -300.0f;

		private float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

		private AnimatedSprite2D sprite;

        public override void _Ready()
        {
            sprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
        }

        public override void _PhysicsProcess(double delta)
		{
			Animate();
			Move(delta);
		}

		private void Move(double delta)
		{
			Vector2 velocity = Velocity;

			if (IsOnFloor())
			{
				if (Input.IsActionJustPressed("jump"))
				{
					velocity.Y = JUMP_VELOCITY;
				}
			}
			else
			{
				velocity.Y += gravity * (float) delta;
			}

			float direction = Input.GetAxis("move_left", "move_right");

			if (direction != 0)
			{
				velocity.X = direction * SPEED;
				sprite.FlipH = direction != 1.0f;
			}
			else
			{
				velocity.X = Mathf.MoveToward(Velocity.X, 0, SPEED);
			}

			Velocity = velocity;

			MoveAndSlide();
		}

		private void Animate()
		{
			if (!IsOnFloor())
			{
				sprite.Play("jump");
			}
			else if (Velocity == Vector2.Zero)
			{
				sprite.Play("idle");
			}
			else
			{
				sprite.Play("run");
			}
		}
	}
}
