using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace OrchidMod.Alchemist.Misc
{
	public class EmptyFlask : OrchidModItem
	{
		public override void SetDefaults()
		{
			item.width = 30;
			item.height = 30;
			item.maxStack = 99;
			item.value = Item.sellPrice(0, 0, 4, 0);
			item.rare = 0;
		}


		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Empty Flask");
			Tooltip.SetDefault("Sold by the mineshaft chemist"
							+ "\nUsed to make various alchemist weapons");
		}

	}
}
