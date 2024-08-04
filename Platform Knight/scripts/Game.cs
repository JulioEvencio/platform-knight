using Godot;
using System;

namespace PlataformKnight
{
	public partial class Game : Node2D
	{
		public override void _Ready()
		{
			Camera2D camera = GetNode<Camera2D>("Player/Camera2D");

			Marker2D limitLeft = GetNode<Marker2D>("CameraLimit/LimitLeft");
			Marker2D limitRight = GetNode<Marker2D>("CameraLimit/LimitRight");
			Marker2D limitBottom = GetNode<Marker2D>("CameraLimit/LimitBottom");

			camera.LimitLeft = (int) limitLeft.Position.X;
			camera.LimitRight = (int) limitRight.Position.X;
			camera.LimitBottom = (int) limitBottom.Position.Y;
		}

		public override void _Process(double delta)
		{
			if (Input.IsActionJustPressed("restart"))
			{
				GetTree().ReloadCurrentScene();
			}
			else if (Input.IsActionJustPressed("escape"))
			{
				GetTree().Quit();
			}
		}
	}
}
