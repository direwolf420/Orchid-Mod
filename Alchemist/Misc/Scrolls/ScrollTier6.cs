namespace OrchidMod.Alchemist.Misc.Scrolls
{
	public class ScrollTier6 : OrchidModAlchemistScroll
	{
		public override void SafeSetDefaults()
		{
			item.rare = 8;
			this.hintLevel = 6;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Alchemist Recipe Scroll");
			Tooltip.SetDefault("Contains the recipe for an unknown alchemist hidden reaction");
		}
	}
}
