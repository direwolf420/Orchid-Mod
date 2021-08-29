using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace OrchidMod.Shaman.Weapons
{
	public class DepthsBaton : OrchidModShamanItem
	{
		public override void SafeSetDefaults()
		{
			item.damage = 57;
			item.width = 40;
			item.height = 40;
			item.useTime = 35;
			item.useAnimation = 35;
			item.knockBack = 3.15f;
			item.rare = 3;
			item.value = Item.sellPrice(0, 1, 6, 0);
			item.UseSound = SoundID.Item72;
			item.autoReuse = true;
			item.shootSpeed = 12f;
			item.shoot = mod.ProjectileType("DepthsBatonProj");
			this.empowermentType = 5;
			this.energy = 10;
		}

		public override void SafeSetStaticDefaults()
		{
			DisplayName.SetDefault("Depths Baton");
			Tooltip.SetDefault("Shoots bolts of dark energy"
							  + "\nHitting at maximum range deals increased damage"
							  + "\nHaving 3 or more active shamanic bonds will allow the weapon to shoot a straight beam");
		}

		public override bool SafeShoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			OrchidModPlayer modPlayer = player.GetModPlayer<OrchidModPlayer>();
			int BuffsCount = OrchidModShamanHelper.getNbShamanicBonds(player, modPlayer, mod);
			if (BuffsCount > 2)
			{
				this.NewShamanProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("DepthBatonProjAlt"), damage - 10, knockBack, player.whoAmI);
			}
			return true;
		}


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "Blum", 1);
			recipe.AddIngredient(null, "PerishingSoul", 1);
			recipe.AddIngredient(null, "SporeCaller", 1);
			recipe.AddIngredient(null, "VileSpout", 1);
			recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(this);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "Blum", 1);
			recipe.AddIngredient(null, "PerishingSoul", 1);
			recipe.AddIngredient(null, "SporeCaller", 1);
			recipe.AddIngredient(null, "SpineScepter", 1);
			recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
