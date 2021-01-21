using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace OrchidMod.Shaman.Projectiles.Thorium.OreOrbs.Big
{
    public class LodestoneScepterProj : OrchidModShamanProjectile
    {
        public override void SafeSetDefaults()
        {
            projectile.width = 14;
            projectile.height = 14;
            projectile.friendly = true;
            projectile.aiStyle = 0;
			projectile.timeLeft = 25;
			projectile.scale = 1f;
			projectile.alpha = 255;
            this.empowermentType = 4;
            this.empowermentLevel = 3;
            this.spiritPollLoad = 4;
        }
		
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lodestone Bolt");
        } 
		
        public override void AI()
        {  
            int dust = Dust.NewDust(projectile.position, 1, 1, 90);
			Main.dust[dust].velocity /= 10f;
			Main.dust[dust].scale = 1f;
			Main.dust[dust].noGravity = true;
			Main.dust[dust].noLight = false;
			int dust2 = Dust.NewDust(projectile.position, 1, 1, 182);
			Main.dust[dust2].velocity /= 1f;
			Main.dust[dust2].scale = 0.8f;
			Main.dust[dust2].noGravity = true;
			Main.dust[dust2].noLight = true;
			
			if (Main.rand.Next(2) == 0) {
				int dust3 = Dust.NewDust(projectile.position, 1, 1, 38);
				Main.dust[dust3].velocity /= 1.5f;
				Main.dust[dust3].scale = 1f;
				Main.dust[dust3].noGravity = true;
				Main.dust[dust3].noLight = true;
			}
		}
		
		public override void Kill(int timeLeft)
        {
            for(int i=0; i<10; i++)
            {
                int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 90);
				Main.dust[dust].noGravity = true;
				Main.dust[dust].velocity *= 10f;
            }
        }
		
		public override void SafeOnHitNPC(NPC target, int damage, float knockback, bool crit, Player player, OrchidModPlayer modPlayer)
		{	
			Mod thoriumMod = ModLoader.GetMod("ThoriumMod");
			if (thoriumMod != null && Main.rand.Next(5) == 0) {
				target.AddBuff((thoriumMod.BuffType("Sunder")), 4 * 60);
			}
			
			if (modPlayer.shamanOrbBig != ShamanOrbBig.LODESTONE) {
				modPlayer.shamanOrbBig = ShamanOrbBig.LODESTONE;
				modPlayer.orbCountBig = 0;
			}
			modPlayer.orbCountBig ++;
			
			if (modPlayer.orbCountBig == 3)
				{
				Projectile.NewProjectile(player.Center.X - 30, player.position.Y - 30, 0f, 0f, mod.ProjectileType("LodestoneOrb"), 0, 0, projectile.owner, 0f, 0f);
				
				if (player.FindBuffIndex(mod.BuffType("ShamanicBaubles")) > -1)
				{
					modPlayer.orbCountBig +=3;
					Projectile.NewProjectile(player.Center.X - 15, player.position.Y - 38, 0f, 0f, mod.ProjectileType("LodestoneOrb"), 1, 0, projectile.owner, 0f, 0f);
					player.ClearBuff(mod.BuffType("ShamanicBaubles"));
				}
			}
			if (modPlayer.orbCountBig == 6)
				Projectile.NewProjectile(player.Center.X - 15, player.position.Y - 38, 0f, 0f, mod.ProjectileType("LodestoneOrb"), 0, 0, projectile.owner, 0f, 0f);
			if (modPlayer.orbCountBig == 9)
				Projectile.NewProjectile(player.Center.X, player.position.Y - 40, 0f, 0f, mod.ProjectileType("LodestoneOrb"), 0, 0, projectile.owner, 0f, 0f);
			if (modPlayer.orbCountBig == 12)
				Projectile.NewProjectile(player.Center.X + 15, player.position.Y - 38, 0f, 0f, mod.ProjectileType("LodestoneOrb"), 0, 0, projectile.owner, 0f, 0f);
			if (modPlayer.orbCountBig == 15)
				Projectile.NewProjectile(player.Center.X + 30, player.position.Y - 30, 0f, 0f, mod.ProjectileType("LodestoneOrb"), 0, 0, projectile.owner, 0f, 0f);
			if (modPlayer.orbCountBig > 15) {
				Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0f, 0f, mod.ProjectileType("LodestoneScepterExplosion"), projectile.damage * 3, 0.0f, projectile.owner, 0.0f, 0.0f);
				Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 14);
				modPlayer.orbCountBig = -3;
			}
		}
    }
}