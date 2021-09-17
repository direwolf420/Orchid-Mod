using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace OrchidMod.Shaman.Weapons.Hardmode
{
	public class AdamantiteScepter : OrchidModShamanItem
	{
		public override void SafeSetDefaults()
		{
			item.damage = 51;
			item.width = 30;
			item.height = 30;
			item.useTime = 50;
			item.useAnimation = 50;
			item.knockBack = 4.15f;
			item.rare = 4;
			item.value = Item.sellPrice(0, 2, 70, 0);
			item.UseSound = SoundID.Item117;
			item.autoReuse = true;
			item.shootSpeed = 15f;
			item.shoot = mod.ProjectileType("AdamantiteScepterProj");
			this.empowermentType = 4;
			this.energy = 12;
		}

		public override void SafeSetStaticDefaults()
		{
			DisplayName.SetDefault("Adamantite Scepter");
			Tooltip.SetDefault("Shoots a potent adamantite bolt, hitting your enemy 3 times"
							  + "\nHitting the same target with all 3 shots will grant you an adamantite orb"
							  + "\nIf you have 5 adamantite orbs, your attack will be empowered, dealing double damage");
		}

		public override bool SafeShoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			int numberProjectiles = 3;
			if (player.GetModPlayer<OrchidModPlayer>().orbCountBig >= 15 && player.GetModPlayer<OrchidModPlayer>().shamanOrbBig == ShamanOrbBig.ADAMANTITE)
			{
				for (int i = 0; i < 3; i++)
				{
					Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(5));
					this.NewShamanProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("AdamantiteScepterProj"), damage * 2, knockBack, player.whoAmI);
				}
				player.GetModPlayer<OrchidModPlayer>().orbCountBig = -3;
			}
			else
			{
				for (int i = 0; i < numberProjectiles; i++)
				{
					this.NewShamanProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("AdamantiteScepterProj"), damage, knockBack, player.whoAmI);
				}
			}
			return false;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.AdamantiteBar, 12);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
