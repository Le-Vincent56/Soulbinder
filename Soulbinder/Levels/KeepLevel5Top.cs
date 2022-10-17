﻿using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Soulbinder.GameObjects;

namespace Soulbinder
{
    class KeepLevel5Top : Level
    {
        // FIELDS =======================================================================
        // Level Specific Fields
        private double rockDropTimer;

        // PROPERTIES ===================================================================
        // There shouldn't be any properties not already included with Level.

        // CONSTRUCTORS =================================================================
        public KeepLevel5Top(Game1 game, string titFile)
            : base(game, titFile)
        {
            // Setting Initial Checkpoint (a.k.a Player Spawn)
            CheckpointPosition = new Vector2(140, 262);

            // Load the background
            Background = game.SpriteManager.KeepBackground;

            rockDropTimer = 400;
        }

        // METHODS ======================================================================
        public override void ConnectDoors(Game1 game)
        {
            Doors.Add(new Door(
                new Rectangle(120, 192, 64, 128),
                game.L_Keep4Top,
                false));

            Doors.Add(new Door(
                new Rectangle(1680, 276, 64, 128),
                game.L_Keep6,
                false));

        }

        public override void Update(Game1 game)
        {
            // Spawn a new projectile at set intervals
            rockDropTimer -= game.ElapsedMilliseconds;

            if (rockDropTimer <= 0)
            {
                game.Player.ProjectileList = Projectiles;

                Projectiles.Add(new Projectile(
                    game.SpriteManager.RockSprite,
                    new Rectangle(140, 550, 50, 50),
                    7, 10, 10, 4));
                Projectiles.Add(new Projectile(
                    game.SpriteManager.RockSprite,
                    new Rectangle(612, 80, 50, 50),
                    7, 10, 10, 4));
                Projectiles.Add(new Projectile(
                    game.SpriteManager.RockSprite,
                    new Rectangle(1270, 80, 50, 50),
                    7, 10, 10, 4));

                rockDropTimer = 1000;
            }

            // move all projectiles up and left
            for (int i = 0; i < Projectiles.Count; i++)
            {
                Projectiles[i].X += Projectiles[i].Speed;
                Projectiles[i].Y -= Projectiles[i].Speed;
            }
        }
        public override void DrawText(Game1 game)
        {
            // N/A
        }
    }
}
