using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace OrchidMod.Alchemist.Buffs
{
    public class SpiritedWaterBuff : ModBuff
    {
        public override void SetDefaults()
        {
			DisplayName.SetDefault("Spirited Droplets");
			Description.SetDefault("Chemical attacks will release spirited water flames");
            Main.buffNoTimeDisplay[Type] = false;
			Main.buffNoSave[Type] = true;
        }
    }
}