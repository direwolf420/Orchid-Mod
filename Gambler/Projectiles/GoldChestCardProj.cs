using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace OrchidMod.Gambler.Projectiles
{
	public class GoldChestCardProj : OrchidModGamblerProjectile
	{
		bool redDust = false;
		
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sparkle");
        } 
		
		public override void SafeSetDefaults()
		{
			projectile.width = 14;
            projectile.height = 14;
            projectile.friendly = true;
            projectile.aiStyle = 0;
			projectile.timeLeft = 240;
			projectile.penetrate = 3;
			this.gamblingChipChance = 5;
			Main.projFrames[projectile.type] = 4;
		}
		
        public override Color? GetAlpha(Color lightColor)
        {
            return Color.White;
        }
		
		public override void SafeAI()
		{
			if (!this.initialized) {
				this.initialized = true;
				this.redDust = projectile.ai[1] > 1f;
				projectile.frame = (int)projectile.ai[1];
			}
			
			projectile.velocity *= 0.985f;
			
			projectile.rotation += this.redDust ? 0.05f : -0.05f;
			
			// if (Main.rand.Next(8) == 0) {
				// int dustType = this.redDust ? 60 : 59;
				// Vector2 pos = new Vector2(projectile.position.X, projectile.position.Y);
				// int index = Dust.NewDust(pos, projectile.width, projectile.height, dustType);
				// Main.dust[index].velocity *= 0.25f;
				// Main.dust[index].scale *= 1.5f;
				// Main.dust[index].noGravity = false;
			// }
			
			if (Main.rand.Next(3) == 0) {
				int Type = Main.rand.Next(3);
				if (Type == 0) Type = 15;
				if (Type == 1) Type = 57;
				if (Type == 2) Type = 58;
				int index = Dust.NewDust(projectile.position - projectile.velocity * 0.25f, projectile.width, projectile.height, Type, 0.0f, 0.0f, 0, new Color(), Main.rand.Next(80, 110) * 0.013f);
				Main.dust[index].velocity *= 0.2f;
				Main.dust[index].noGravity = true;
			}
		}
		
		public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (projectile.velocity.X != oldVelocity.X) projectile.velocity.X = -oldVelocity.X * 0.5f;
            if (projectile.velocity.Y != oldVelocity.Y) projectile.velocity.Y = -oldVelocity.Y * 0.5f;
            return false;
        }
		
		public override void Kill(int timeLeft) {
			int dustType = this.redDust ? 60 : 59;
			OrchidModProjectile.spawnDustCircle(projectile.Center, dustType, 10, 5, true, 1.5f, 1f, 5f);
			for (int i = 0 ; i < 3 ; i ++) {
				Main.dust[Dust.NewDust(projectile.position, projectile.width, projectile.height, dustType)].noGravity = true;
			}
		}
		
		public override void SafeOnHitNPC(NPC target, int damage, float knockback, bool crit, Player player, OrchidModPlayer modPlayer) {
			if (modPlayer.gamblerElementalLens) {
				target.AddBuff(31, 60 * 2); // Confused
			}
        }
	}
}