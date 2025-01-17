using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using OrchidMod;
using static Terraria.ModLoader.ModContent;

namespace OrchidMod.Alchemist.Projectiles.Reactive
{
    public class OilBubble : AlchemistProjReactive
    {
        public override void SafeSetDefaults()
        {
            projectile.width = 26;
            projectile.height = 26;
            projectile.friendly = false;
            projectile.aiStyle = 0;
			projectile.timeLeft = 600;
			projectile.scale = 1f;
			projectile.alpha = 64;
			this.spawnTimeLeft = 600;
        }
		
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sap Bubble");
        } 
		
		public override void SafeAI()
        {
			projectile.velocity.Y *= 0.95f;
			projectile.velocity.X *= 0.99f;
			projectile.rotation += 0.02f;
			
			if (Main.rand.Next(20) == 0) {
				int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 184);
				Main.dust[dust].velocity *= 0.1f;
				Main.dust[dust].scale *= 1f;
            }
		}
		
		public override void Despawn() {
            for(int i=0; i<5; i++)
            {
				int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 184);
				Main.dust[dust].velocity *= 1.5f;
				Main.dust[dust].scale *= 1f;
            }
		}
		
		public override void SafeKill(int timeLeft, Player player, OrchidModPlayer modPlayer)
        {
			Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 85);
			int dmg = projectile.damage;
			OrchidModProjectile.spawnDustCircle(projectile.Center, 184, 200, 15, false, 1.5f, 1f, 5f);
			OrchidModProjectile.spawnDustCircle(projectile.Center, 184, 175, 30, false, 1.5f, 1f, 5f);
			
			Vector2 move = Vector2.Zero;
			float distance = 500f;
			for (int k = 0; k < 200; k++)
			{
				if (Main.npc[k].active && !Main.npc[k].friendly)
				{
					Vector2 newMove = Main.npc[k].Center - projectile.Center;
					float distanceTo = (float)Math.Sqrt(newMove.X * newMove.X + newMove.Y * newMove.Y);
					if (distanceTo < distance) {
						OrchidModAlchemistNPC modTarget = Main.npc[k].GetGlobalNPC<OrchidModAlchemistNPC>();
						modTarget.alchemistWater = 60 * 10;
					}
				}
			}
        }
    }
}