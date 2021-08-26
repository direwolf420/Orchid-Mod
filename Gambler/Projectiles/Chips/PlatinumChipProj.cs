namespace OrchidMod.Gambler.Projectiles.Chips
{
	public class PlatinumChipProj : OrchidModGamblerProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Platinum Chip");
		}

		public override void SafeSetDefaults()
		{
			projectile.width = 26;
			projectile.height = 26;
			projectile.friendly = true;
			projectile.aiStyle = 2;
			projectile.timeLeft = 250;
			projectile.penetrate = 3;
		}
	}
}