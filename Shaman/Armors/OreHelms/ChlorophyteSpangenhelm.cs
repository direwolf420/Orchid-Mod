using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace OrchidMod.Shaman.Armors.OreHelms
{
	[AutoloadEquip(EquipType.Head)]
	public class ChlorophyteSpangenhelm : OrchidModShamanEquipable
	{

		public override void SafeSetDefaults()
		{
			Item.width = 30;
			Item.height = 20;
			Item.value = Item.sellPrice(0, 6, 0, 0);
			Item.rare = 7;
			Item.defense = 14;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Chlorophyte Spangenhelm");
			Tooltip.SetDefault("Your shamanic bonds will last 4 seconds longer"
							  + "\n16% increased shamanic damage");
		}

		public override void UpdateEquip(Player player)
		{
			OrchidModPlayer modPlayer = player.GetModPlayer<OrchidModPlayer>();
			modPlayer.shamanBuffTimer += 4;
			modPlayer.shamanDamage += 0.16f;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == 1004 && legs.type == 1005;
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Summons a powerful leaf crystal to shoot at nearby enemies";
			player.AddBuff((60), 1);
		}

		public override void DrawHair(ref bool drawHair, ref bool drawAltHair)
		{
			drawHair = drawAltHair = false;
		}

		public override bool DrawHead()
		{
			return true;
		}

		public override void ArmorSetShadows(Player player)
		{
			player.armorEffectDrawShadowSubtle = true;
		}

		public override void AddRecipes()
		{
			var recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.ChlorophyteBar, 12);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
			recipe.Register();
		}
	}
}
