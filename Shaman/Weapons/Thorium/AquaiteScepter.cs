using Microsoft.Xna.Framework;
using OrchidMod.Interfaces;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace OrchidMod.Shaman.Weapons.Thorium
{
	public class AquaiteScepter : OrchidModShamanItem, ICrossmodItem
	{
		public string CrossmodName => "Thorium Mod";

		public override void SafeSetDefaults()
		{
			item.damage = 20;
			item.width = 38;
			item.height = 38;
			item.useTime = 40;
			item.useAnimation = 40;
			item.knockBack = 4.75f;
			item.rare = ItemRarityID.Green;
			item.value = Item.sellPrice(0, 0, 30, 0);
			item.UseSound = SoundID.Item21;
			item.autoReuse = true;
			item.shootSpeed = 15f;
			item.shoot = mod.ProjectileType("AquaiteScepterProj");
			this.empowermentType = 4;
			this.energy = 8;
		}

		public override void SafeSetStaticDefaults()
		{
			DisplayName.SetDefault("Aquaite Scepter");
			Tooltip.SetDefault("Shoots a water bolt, hitting your enemy twice"
							+ "\nHitting the same target twice will grant you a water crystal"
							+ "\nIf you have 5 crystals, your next hit will summon a powerful geyser");
		}

		public override bool SafeShoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			int numberProjectiles = 2;
			for (int i = 0; i < numberProjectiles; i++)
			{
				this.NewShamanProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("AquaiteScepterProj"), damage, knockBack, player.whoAmI);
			}
			return false;
		}

		public override void AddRecipes()
		{
			var thoriumMod = OrchidMod.ThoriumMod;
			if (thoriumMod != null)
			{
				ModRecipe recipe = new ModRecipe(mod);
				recipe.AddTile(TileID.Anvils);
				recipe.AddIngredient(thoriumMod, "AquaiteBar", 14);
				recipe.AddIngredient(thoriumMod, "DepthScale", 6);
				recipe.SetResult(this);
				recipe.AddRecipe();
			}
		}
	}
}
