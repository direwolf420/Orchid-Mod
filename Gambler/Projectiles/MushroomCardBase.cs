using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace OrchidMod.Gambler.Projectiles
{
	public class MushroomCardBase : OrchidModGamblerProjectile
	{
		public Vector2 bushLeftPos;
		public Vector2 bushRightPos;
		public Texture2D bushTexture;
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mushroom Card Base");
		}
		
		public override void SafeSetDefaults()
		{
			Projectile.width = 2;
			Projectile.height = 2;
			Projectile.friendly = false;
			Projectile.aiStyle = 0;
			Projectile.tileCollide = false;
			Projectile.timeLeft = 3600;
			Projectile.alpha = 255;
		}
		
		public override void OnSpawn() {
			Projectile.ai[0] = 10;
			bushTexture = bushTexture ?? ModContent.GetTexture("OrchidMod/Gambler/Projectiles/MushroomCardBase");
		}

		public override void SafeAI()
		{
			Player player = Main.player[Projectile.owner];
			OrchidModPlayer modPlayer = player.GetModPlayer<OrchidModPlayer>();
			bool dummy = Projectile.GetGlobalProjectile<OrchidModGlobalProjectile>().gamblerDummyProj;
			
			bushLeftPos = Projectile.Center;
			bushRightPos = Projectile.Center;
			bushLeftPos.X -= (bushTexture.Width / 4);
			bushRightPos.X += (bushTexture.Width / 4);
			bushLeftPos.Y -= ((Math.Abs(modPlayer.timer120 - 60)) / 10) - (bushTexture.Height / 12) - 8;
			bushRightPos.Y -= ((Math.Abs(modPlayer.timer120 - 60) * -1f) / 10) - (bushTexture.Height / 12 * -1f) - 8;
			
			Projectile.ai[0] --;
			if (Projectile.ai[0] <= 0) {
				Projectile.ai[0] = 90f;
				int projType = ProjectileType<Gambler.Projectiles.MushroomCardProj>();
				int newProjectile = (OrchidModGamblerHelper.DummyProjectile(Projectile.NewProjectile(Projectile.Center.X, Projectile.Center.Y, 10f, 0f, projType, Projectile.damage, Projectile.knockBack, Projectile.owner), dummy));
				Main.projectile[newProjectile].ai[0] = Projectile.whoAmI;
				Main.projectile[newProjectile].ai[1] = 0f;
				Main.projectile[newProjectile].netUpdate = true;
			}
			
			if (Main.myPlayer == Projectile.owner)
			{
				int cardType = this.getCardType(modPlayer);
				if (cardType != ItemType<Gambler.Weapons.Cards.MushroomCard>() || modPlayer.gamblerShuffleCooldown <= 0)
				{
					if (!dummy && !modPlayer.gamblerLuckySprout) {
						Projectile.Kill();
					} else {
						Projectile.ai[1] = 1f;
						Projectile.netUpdate = true;
					}
				}
			}
			
			if (Projectile.ai[1] == 0f) {
				Projectile.position = player.Center;
				Projectile.position.Y -= 60;
				Projectile.position.X -= (int)(Projectile.width / 2);
			}
		}
		
		public override bool OrchidPreDraw(SpriteBatch spriteBatch, Color lightColor) {
			bushTexture = bushTexture ?? ModContent.GetTexture("OrchidMod/Gambler/Projectiles/MushroomCardBase");
			Vector2 position = bushLeftPos - Main.screenPosition + Vector2.UnitY * Projectile.gfxOffY;
			spriteBatch.Draw(bushTexture, position, null, lightColor, 0f, bushTexture.Size() * 0.5f, 1f, SpriteEffects.None, 0f);
			position = bushRightPos - Main.screenPosition + Vector2.UnitY * Projectile.gfxOffY;
			spriteBatch.Draw(bushTexture, position, null, lightColor, 0f, bushTexture.Size() * 0.5f, 1f, SpriteEffects.FlipHorizontally, 0f);
			
			int projType = ProjectileType<Gambler.Projectiles.MushroomCardProj>();
			for (int l = 0; l < Main.projectile.Length; l++)
			{
				Projectile proj = Main.projectile[l];
				if (proj.active && proj.type == projType && proj.ai[1] < 2f && proj.ai[0] == Projectile.whoAmI)
				{
					Texture2D texture = ModContent.GetTexture("OrchidMod/Gambler/Projectiles/MushroomCardProj");
					position = proj.position - Main.screenPosition;
					spriteBatch.Draw(texture, position, null, lightColor, proj.rotation, texture.Size() * 0f, proj.scale, SpriteEffects.None, 0f);
					
					if (proj.ai[1] == 1f) {
						Texture2D pixelTexture = ModContent.GetTexture("OrchidMod/Gambler/UI/Textures/Trajectory");
						Vector2 newMove = Projectile.Center - proj.Center;
						if (newMove.Length() > 1f) {
							newMove.Normalize();
							newMove *= proj.localAI[1];
							Vector2 pos = proj.Center - Main.screenPosition;
							Color drawColor = Color.White;
							for (int i = 0 ; i < 61; i ++) {
								if (i % 10 == 0) {
									drawColor *= 0.8f;
									Vector2 drawpos = pos - new Vector2(pixelTexture.Width / 2, pixelTexture.Height / 2);
									spriteBatch.Draw(pixelTexture, drawpos, drawColor);
								}
								pos += newMove;
							}
						}
					}
				}
			}
			return true;
		}
	}
}