using Godot;
using System;

namespace PlataformKnight.Scripts
{
	public partial class Player : CharacterBody2D
	{
		private const float Speed = 130.0f;
		private const float JumpVelocity = -300.0f;

		// private float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

		private AnimatedSprite2D _sprite;

		public override void _Ready()
		{
			_sprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
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
					velocity.Y = JumpVelocity;
				}
			}
			else
			{
				// velocity.Y += gravity * (float) delta;
				velocity += GetGravity() * (float) delta;
			}

			float direction = Input.GetAxis("move_left", "move_right");

			if (direction != 0)
			{
				velocity.X = direction * Speed;
				_sprite.FlipH = direction != 1.0f;
			}
			else
			{
				velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
			}

			Velocity = velocity;

			MoveAndSlide();
		}

		private void Animate()
		{
			if (!IsOnFloor())
			{
				_sprite.Play("jump");
			}
			else if (Velocity == Vector2.Zero)
			{
				_sprite.Play("idle");
			}
			else
			{
				_sprite.Play("run");
			}
		}
	}
}
