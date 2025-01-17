using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using OrchidMod.Alchemist.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using System.Collections.Generic;
using static Terraria.ModLoader.ModContent;

namespace OrchidMod.Alchemist.Weapons.Nature
{
	public class SunflowerFlask : OrchidModAlchemistItem
	{
		public override void SafeSetDefaults()
		{
			item.damage = 6;
			item.width = 30;
			item.height = 30;
			item.rare = 1;
			item.value = Item.sellPrice(0, 0, 3, 0);
			this.potencyCost = 1;
			this.element = AlchemistElement.NATURE;
			this.rightClickDust = 3;
			this.colorR = 245;
			this.colorG = 197;
			this.colorB = 1;
			this.secondaryDamage = 8;
			this.secondaryScaling = 1f;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Forest Samples");
		    Tooltip.SetDefault("Using a water element increases damage and spawns a damaging sunflower"
							+  "\n'Handcrafted jars are unfit for precise alchemy'");
		}
		
		public override void AddRecipes()
		{
		    ModRecipe recipe = new ModRecipe(mod);
			recipe.AddTile(TileID.WorkBenches);
			recipe.AddIngredient(ItemID.Bottle, 1);
			recipe.AddIngredient(ItemID.Sunflower, 1);
			recipe.AddIngredient(ItemID.Mushroom, 3);
			recipe.SetResult(this);
			recipe.AddRecipe();
        }
		
		public override void KillSecond(int timeLeft, Player player, OrchidModPlayer modPlayer, AlchemistProj alchProj, Projectile projectile, OrchidModGlobalItem globalItem) {
			int nb = 2 + Main.rand.Next(2);
			for (int i = 0 ; i < nb ; i ++) {
				Vector2	vel = (new Vector2(0f, (float)(3 + Main.rand.Next(4))).RotatedByRandom(MathHelper.ToRadians(180)));
				int spawnProj = ProjectileType<Alchemist.Projectiles.Nature.SunflowerFlaskProj4>();
				Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, vel.X, vel.Y, spawnProj, 0, 0f, projectile.owner);
			}
			if (alchProj.waterFlask.type != 0) {
				int dmg = getSecondaryDamage(modPlayer, alchProj.nbElements);
				Vector2 vel = (new Vector2(0f, -2f).RotatedByRandom(MathHelper.ToRadians(20)));
				Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, vel.X, vel.Y, ProjectileType<Alchemist.Projectiles.Nature.SunflowerFlaskProj1>(), dmg, 0f, projectile.owner);
			}
		}
		
		public override void AddVariousEffects(Player player, OrchidModPlayer modPlayer, AlchemistProj alchProj, Projectile projectile, OrchidModGlobalItem globalItem) {
			if (alchProj.waterFlask.type != 0) projectile.damage += (int)(3 * modPlayer.alchemistDamage);
		}
	}
}
