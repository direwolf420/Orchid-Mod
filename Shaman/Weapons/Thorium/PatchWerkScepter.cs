using System.Collections.Generic;
using Microsoft.Xna.Framework;
using OrchidMod.Interfaces;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
 
namespace OrchidMod.Shaman.Weapons.Thorium
{
	public class PatchWerkScepter : OrchidModShamanItem, ICrossmodItem
	{
		public string CrossmodName => "Thorium Mod";

		public override void SafeSetDefaults()
		{
			item.damage = 12;
			item.width = 30;
			item.height = 30;
			item.useTime = 35;
			item.useAnimation = 35;
			item.knockBack = 5.25f;
			item.rare = ItemRarityID.Blue;
			item.value = Item.sellPrice(0, 0, 40, 0);
			item.UseSound = SoundID.Item43;
			item.autoReuse = true;
			item.shootSpeed = 10f;
			item.shoot = mod.ProjectileType("PatchWerkScepterProj");
			this.empowermentType = 4;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Festering Fork");
			Tooltip.SetDefault("Fires out a bolt of festering magic"
							+ "\nIf you have 2 or more active shamanic bonds, hitting will summon maggots");
		}
		
		public override bool SafeShoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 64f; 
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
				position += muzzleOffset;
			
			return true;
		}
    }
}

