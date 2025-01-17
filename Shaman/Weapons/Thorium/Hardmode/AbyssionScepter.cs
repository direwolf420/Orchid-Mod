using System.Collections.Generic;
using Microsoft.Xna.Framework;
using OrchidMod.Interfaces;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
 
namespace OrchidMod.Shaman.Weapons.Thorium.Hardmode
{
	public class AbyssionScepter : OrchidModShamanItem, ICrossmodItem
    {
		public string CrossmodName => "Thorium Mod";

		public override void SafeSetDefaults()
		{
			item.damage = 250;
			item.width = 50;
			item.height = 50;
			item.useTime = 40;
			item.useAnimation = 40;
			item.knockBack = 4.25f;
			item.rare = ItemRarityID.Yellow;
			item.value = Item.sellPrice(0, 10, 0, 0);
			item.UseSound = SoundID.Item43;
			item.autoReuse = true;
			item.shootSpeed = 8f;
			item.shoot = mod.ProjectileType("AbyssionScepterProj");
			this.empowermentType =2;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Will of the Lurker");
			Tooltip.SetDefault("Summons bolts of dark energy that lingers for a while before returning to you"
							+ "\nCosts 25 health to cast, reduced by 5 for each active shamanic bond");
		}
		
		public override bool SafeShoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			OrchidModPlayer modPlayer =  player.GetModPlayer<OrchidModPlayer>();
			Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 64f; 
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
				position += muzzleOffset;
			
			int damageCost = 25 - OrchidModShamanHelper.getNbShamanicBonds(player, modPlayer, mod) * 5;
			if (player.statLife - damageCost > 0) { 
				player.statLife -= damageCost;
			} else {
				player.statLife = 1;
			}
			
			return true;
		}
    }
}

