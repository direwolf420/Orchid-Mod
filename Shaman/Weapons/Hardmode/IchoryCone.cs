using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
 
namespace OrchidMod.Shaman.Weapons.Hardmode
{
    public class IchoryCone : OrchidModShamanItem
    {
		public override void SafeSetDefaults()
		{
			item.damage = 30;
			item.width = 50;
			item.height = 50;
			item.useTime = 10;
			item.useAnimation = 10;
			item.knockBack = 4.15f;
			item.rare = 4;
			item.value = Item.sellPrice(0, 7, 50, 0);
			item.UseSound = SoundID.Item13;
			item.autoReuse = true;
			item.shootSpeed = 10f;
			item.shoot = mod.ProjectileType("IchoryConeProj");
			this.empowermentType = 1;
		}

		public override void SetStaticDefaults()
		{
		  DisplayName.SetDefault("Ichor Scepter");
		  Tooltip.SetDefault("Sprays your enemies with piercing ichor bursts"
							+"\nThe first enemy hit will fill an ichor cyst above you"
							+"\nYour next hit after the cyst is full will release a shower of ichor in the direction you're moving");
		}

		public override bool SafeShoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 75f;
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}
			Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(10));
			Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
			return false;
		}
		
		public override void AddRecipes()
		{
		    ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "RitualScepter", 1);
			recipe.AddIngredient(ItemID.Ichor, 20);
			recipe.AddIngredient(ItemID.SoulofNight, 15);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
        }
    }
}
