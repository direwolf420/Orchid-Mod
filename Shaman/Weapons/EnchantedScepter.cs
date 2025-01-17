using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.UI.Chat;
 
namespace OrchidMod.Shaman.Weapons
{
    public class EnchantedScepter : OrchidModShamanItem
    {
		public override void SafeSetDefaults()
		{
			item.damage = 9;
			item.width = 40;
			item.height = 40;
			item.useTime = 28;
			item.useAnimation = 28;
			item.knockBack = 3.15f;
			item.rare = 1;
			item.value = Item.sellPrice(0, 1, 0, 0);
			item.UseSound = SoundID.Item43;
			item.autoReuse = true;
			item.shootSpeed = 9f;
			item.shoot = mod.ProjectileType("EnchantedScepterProj");
			this.empowermentType = 1;
		}
		
		public override void SetStaticDefaults()
		{
		  DisplayName.SetDefault("Enchanted Scepter");
		  Tooltip.SetDefault("Weapon damage increases with the number of active shamanic bonds");
		}
		
		public override void ModifyWeaponDamage(Player player, ref float add, ref float mult, ref float flat) {
			OrchidModPlayer modPlayer = player.GetModPlayer<OrchidModPlayer>();
			flat += (OrchidModShamanHelper.getNbShamanicBonds(player, modPlayer, mod) * 3f);
		}
    }
}
