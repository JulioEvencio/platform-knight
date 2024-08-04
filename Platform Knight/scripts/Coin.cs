using Godot;
using System;

namespace PlataformKnight
{
	public partial class Coin : Area2D
	{
		private void OnBodyEntered(Player player)
		{
			QueueFree();
		}
	}
}
