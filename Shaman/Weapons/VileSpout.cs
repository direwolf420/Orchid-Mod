using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.UI.Chat;

namespace OrchidMod.Shaman.Weapons
{
    public class VileSpout : OrchidModShamanItem
    {
		public override void SafeSetDefaults()
		{
			item.damage = 20;
			item.width = 42;
			item.height = 42;
			item.useTime = 25;
			item.useAnimation = 25;
			item.knockBack = 3.15f;
			item.rare = 1;
			item.value = Item.sellPrice(0, 0, 27, 0);
			item.UseSound = SoundID.Item43;
			item.autoReuse = true;
			item.shootSpeed = 7f;
			item.shoot = mod.ProjectileType("VileSpoutProj");
			this.empowermentType = 1;
			OrchidModGlobalItem orchidItem = item.GetGlobalItem<OrchidModGlobalItem>();
			orchidItem.shamanWeaponNoVelocityReforge = true;
		}

		public override void SetStaticDefaults()
		{
		  DisplayName.SetDefault("Vile Spout");
		  Tooltip.SetDefault("Shoots short ranged corruption beams"
							+ "\nThe weapon range scales with the number of active shamanic bonds");
		}
		
		public override void UpdateInventory(Player player) {
			OrchidModPlayer modPlayer = player.GetModPlayer<OrchidModPlayer>();
			int nbBonds = OrchidModShamanHelper.getNbShamanicBonds(player, modPlayer, mod);
			item.shootSpeed = 7f + 2f * nbBonds;
		}
		
		public override void AddRecipes()
		{
		    ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.DemoniteBar, 10);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
        }
    }
}
