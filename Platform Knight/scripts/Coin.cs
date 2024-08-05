using Godot;
using System;

namespace PlataformKnight
{
	public partial class Coin : Area2D
	{
		private GameManager gameManager;
		private AnimatedSprite2D sprite;
		private CollisionShape2D collision;
		private AudioStreamPlayer2D audio;

		public override void _Ready()
		{
			gameManager = GetNode<GameManager>("%GameManager");
			sprite = GetNode<AnimatedSprite2D>("Sprite");
			collision = GetNode<CollisionShape2D>("Collision");
			audio = GetNode<AudioStreamPlayer2D>("Audio");
		}

		private void OnBodyEntered(Player player)
		{
			gameManager.AddScore(1);
			sprite.Visible = false;
			collision.Disabled = true;
			audio.Play();
		}

		private void OnAudioFinished()
		{
			QueueFree();
		}
	}
}
