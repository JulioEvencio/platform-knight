using Godot;
using System;

namespace PlataformKnight.Scripts
{
	public partial class Coin : Area2D
	{
		private GameManager _gameManager;
		private AnimatedSprite2D _sprite;
		private CollisionShape2D _collision;
		private AudioStreamPlayer2D _audio;

		public override void _Ready()
		{
			_gameManager = GetNode<GameManager>("%GameManager");
			_sprite = GetNode<AnimatedSprite2D>("Sprite");
			_collision = GetNode<CollisionShape2D>("Collision");
			_audio = GetNode<AudioStreamPlayer2D>("Audio");
		}

		private void OnBodyEntered(Player player)
		{
			CallDeferred("CustomSelfFree");
		}

		private void OnAudioFinished()
		{
			QueueFree();
		}

		private void CustomSelfFree()
		{
			_collision.Disabled = true;
			_gameManager.AddScore(1);
			_sprite.Visible = false;
			_audio.Play();
		}
	}
}
