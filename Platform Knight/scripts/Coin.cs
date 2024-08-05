using Godot;
using System;

namespace PlataformKnight
{
	public partial class Coin : Area2D
	{
		private GameManager gameManager;

        public override void _Ready()
        {
            gameManager = GetNode<GameManager>("%GameManager");
        }

        private void OnBodyEntered(Player player)
		{
			gameManager.AddScore(1);
			QueueFree();
		}
	}
}
