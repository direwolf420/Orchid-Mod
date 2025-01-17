﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
 
namespace OrchidMod.Shaman.Projectiles
{
    public class SporeCallerProj  : OrchidModShamanProjectile
    {
		bool started = false;
		int count = 0;
		int basedmg = 0;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Jungle Spore");
        } 
        public override void SafeSetDefaults()
        {
            projectile.width = 14;
            projectile.height = 14;
            projectile.friendly = true;
            projectile.aiStyle = 0;
			projectile.alpha = 126;
			projectile.timeLeft = 1200;
			ProjectileID.Sets.Homing[projectile.type] = true;
			this.empowermentType = 3;
			this.projectileTrail = true;
        }
		
		public override Color? GetAlpha(Color lightColor)
        {
            return Color.White;
        }
		
		public override void AI()
        {
			count++;
			projectile.friendly = started;
			
			if (count == 0) basedmg = projectile.damage;
			if (count < 900) projectile.damage = basedmg+(int)(count/20);
			if (count > 600 && count % 100 == 0) {
				for(int i=0; i<5; i++)
				{
					int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 163);
					Main.dust[dust].noGravity = true;
					Main.dust[dust].noLight = true;
				}
			}
			if (count > 900 && count % 50 == 0 && count % 100 != 0) {
				for(int i=0; i<5; i++)
				{
					int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 163);
					Main.dust[dust].noGravity = true;
					Main.dust[dust].noLight = true;
				}
			}
			if (started == false) {
				if (count == 30) started = true;
			}
			if (started == true) {
				projectile.ai[1]++;
				if (projectile.ai[1] == 10)
				{	
					projectile.ai[1] = 0;
					projectile.netUpdate = true;
					switch (Main.rand.Next(4)) {	
						case 0:
						projectile.velocity.Y =  1;
						projectile.velocity.X =  1;
						break;
						case 1:
						projectile.velocity.Y =  -1;
						projectile.velocity.X =  -1;
						break;
						case 2:
						projectile.velocity.Y =  -1;
						projectile.velocity.X =  1;
						break;
						case 3:
						projectile.velocity.Y =  1;
						projectile.velocity.X =  -1;
						break;
					}
				}
				for (int index1 = 0; index1 < 1; ++index1)
				{	
					projectile.velocity = projectile.velocity * 0.75f;		
				}
				if (projectile.alpha > 70)
				{
					projectile.alpha -= 15;
					if (projectile.alpha < 70)
					{
						projectile.alpha = 70;
					}
				}
				if (projectile.localAI[0] == 0f)
				{
					AdjustMagnitude(ref projectile.velocity);
					projectile.localAI[0] = 1f;
				}
				Vector2 move = Vector2.Zero;
				float distance = 200f;
				bool target = false;
				for (int k = 0; k < 200; k++)
				{
					if (Main.npc[k].active && !Main.npc[k].dontTakeDamage && !Main.npc[k].friendly && Main.npc[k].lifeMax > 5 && Main.npc[k].type != NPCID.TargetDummy)
					{
						Vector2 newMove = Main.npc[k].Center - projectile.Center;
						float distanceTo = (float)Math.Sqrt(newMove.X * newMove.X + newMove.Y * newMove.Y);
						if (distanceTo < distance)
						{
							move = newMove;
							distance = distanceTo;
							target = true;
						}
					}
				}
				if (target)
				{
					AdjustMagnitude(ref move);
					projectile.velocity = (5 * projectile.velocity + move) / 1f;
					AdjustMagnitude(ref projectile.velocity);
				}
			}
        }
		
		public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (projectile.velocity.X != oldVelocity.X) projectile.velocity.X = -oldVelocity.X;
            if (projectile.velocity.Y != oldVelocity.Y) projectile.velocity.Y = -oldVelocity.Y;
            return false;
        }
		
		private void AdjustMagnitude(ref Vector2 vector)
		{
			float magnitude = (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
			if (magnitude > 6f)
			{
				vector *= 6f / magnitude;
			}
		}
		
		public override void Kill(int timeLeft)
        {
            for(int i=0; i<10; i++)
            {
                int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 163);
				Main.dust[dust].noGravity = true;
				Main.dust[dust].noLight = true;
            }
		}
		
		public override void SafeOnHitNPC(NPC target, int damage, float knockback, bool crit, Player player, OrchidModPlayer modPlayer)
		{
			if (Main.rand.Next(10) == 0) target.AddBuff((20), 5 * 60);
			if (count > 600) player.AddBuff((mod.BuffType("SporeEmpowerment")), 15 * 60);
        }
    }
}