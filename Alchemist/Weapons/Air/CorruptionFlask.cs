using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using OrchidMod.Alchemist.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using System.Collections.Generic;
using static Terraria.ModLoader.ModContent;

namespace OrchidMod.Alchemist.Weapons.Air
{
	public class CorruptionFlask : OrchidModAlchemistItem
	{
		public override void SafeSetDefaults()
		{
			item.damage = 12;
			item.width = 28;
			item.height = 30;
			item.rare = 1;
			item.value = Item.sellPrice(0, 0, 15, 0);
			this.potencyCost = 1;
			this.element = AlchemistElement.AIR;
			this.rightClickDust = 16;
			this.colorR = 104;
			this.colorG = 90;
			this.colorB = 144;
			this.secondaryDamage = 40;
			this.secondaryScaling = 40f;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Vitriol Mycelium");
		    Tooltip.SetDefault("Grows a mushroom, exploding after a while or when being catalyzed"
							+  "\nThe more ingredients used, the more delayed the explosion"
							+  "\nThe mushroom will absorb the properties of nearby spores, creating more of them"
							+  "\nOnly one mushroom can exist at once");
		}
		
		public override void AddRecipes()
		{
		    ModRecipe recipe = new ModRecipe(mod);
			recipe.AddTile(TileID.WorkBenches);
			recipe.AddIngredient(null, "EmptyFlask", 1);
			recipe.AddIngredient(ItemID.RottenChunk, 5);
			recipe.AddIngredient(ItemID.VileMushroom, 5);
			recipe.SetResult(this);
			recipe.AddRecipe();
        }
		
		public override void KillSecond(int timeLeft, Player player, OrchidModPlayer modPlayer, AlchemistProj alchProj, Projectile projectile, OrchidModGlobalItem globalItem) {
			int projType = ProjectileType<Alchemist.Projectiles.Air.CorruptionFlaskProj>();
			bool spawnedMushroom = false;
			for (int l = 0; l < Main.projectile.Length; l++) {  
				Projectile proj = Main.projectile[l];
				if (proj.active == true && proj.type == projType && proj.owner == projectile.owner) {
					spawnedMushroom = true;
					break;
				}
			}
			
			if (!spawnedMushroom) {
				int dmg = getSecondaryDamage(modPlayer, alchProj.nbElements);
				Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y - 10, 0f, 0f, projType, dmg, 3f, projectile.owner);
			}
		}
	}
}
