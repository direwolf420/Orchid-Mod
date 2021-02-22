using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using System.Collections.Generic;

namespace OrchidMod.Alchemist.Misc.Scrolls
{
	public class ScrollTier1 : OrchidModAlchemistScroll
	{
		public override void SafeSetDefaults()
		{
			item.rare = 1;
			item.value = Item.sellPrice(0, 0, 10, 0);
			this.hintLevel = 1;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Alchemist Recipe Scroll");
		    Tooltip.SetDefault("Contans the recipe for an unknown alchemist hidden reaction");
		}
	}
}
