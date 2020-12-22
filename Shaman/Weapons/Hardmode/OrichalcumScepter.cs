using System.Collections.Generic;
using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.UI.Chat;
 
namespace OrchidMod.Shaman.Weapons.Hardmode
{
    public class OrichalcumScepter : OrchidModShamanItem
    {
		public override void SafeSetDefaults()
		{
			item.damage = 43;
			item.width = 30;
			item.height = 30;
			item.useTime = 50;
			item.useAnimation = 50;
			item.knockBack = 4.15f;
			item.rare = 4;
			item.value = Item.sellPrice(0, 2, 41, 0);
			item.UseSound = SoundID.Item117;
			item.autoReuse = true;
			item.shootSpeed = 15f;
			item.shoot = mod.ProjectileType("OrichalcumScepterProj");
			this.empowermentType = 4;
			this.empowermentLevel = 3;
		}

		public override void SetStaticDefaults()
		{
		  DisplayName.SetDefault("Orichalcum Scepter");
		  Tooltip.SetDefault("Shoots a potent orichalcum bolt, hitting your enemy 3 times"
							+"\nHitting the same target with all 3 shots will grant you an orichalcum orb"
							+"\nIf you have 5 orichalcum orbs, your next hit will release a burst of damaging petals");
		}
		
		public override void AddRecipes()
		{
		    ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.OrichalcumBar, 12);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
        }
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
			Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 64f;
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}
			int numberProjectiles = 3;
			for (int i = 0; i < numberProjectiles; i++)
			{
				Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("OrichalcumScepterProj"), damage, knockBack, player.whoAmI, 0f, 0f);
			}
			return false;
		}
    }
}
