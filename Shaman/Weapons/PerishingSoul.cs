using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.UI.Chat;
 
namespace OrchidMod.Shaman.Weapons
{
    public class PerishingSoul : OrchidModShamanItem
    {
		public override void SafeSetDefaults()
		{
			item.damage = 57;
			item.width = 30;
			item.height = 30;
			item.useTime = 25;
			item.useAnimation = 25;
			item.knockBack = 3.15f;
			item.rare = 3;
			item.value = Item.sellPrice(0, 0, 47, 0);
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;
			item.shootSpeed = 15f;
			item.shoot = mod.ProjectileType("PerishingSoulProj");
			this.empowermentType = 1;
		}

		public override void SetStaticDefaults()
		{
		  DisplayName.SetDefault("Perishing Soul");
		  Tooltip.SetDefault("Shoots fireballs, growing for an instant before being launched"
							+"\nProjectile will grow faster the more active shamanic bonds you have");
		}
		
		public override void AddRecipes()
		{
		    ModRecipe recipe = new ModRecipe(mod);
			recipe.AddTile(TileID.Anvils);	
			recipe.AddIngredient(ItemID.HellstoneBar, 18);
			recipe.SetResult(this);
			recipe.AddRecipe();
        }
    }
}
