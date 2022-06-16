﻿using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace OrchidMod.Alchemist.Recipes
{
	public class RecipeFireSpores : AlchemistHiddenReactionRecipe
	{
		public override void SetDefaults()
		{
			this.level = -3;
			this.name = "Fire Spores";
			this.description = "Releases a sizeable amount of fire spores, which doesn't destroy existing ones";
			this.debuffDuration = 20;
			this.sound = SoundID.Item45;
			this.dust = 6;
			
			this.ingredients.Add(ItemType<Alchemist.Weapons.Nature.AttractiteFlask>());
			this.ingredients.Add(ItemType<Alchemist.Weapons.Fire.BlinkrootFlask>());
		}
		
		
		public override void Reaction(Player player, OrchidModPlayer modPlayer)
		{
			int itemType = ItemType<Alchemist.Weapons.Fire.BlinkrootFlask>();
			int itemType2 = ItemType<Alchemist.Weapons.Fire.FireblossomFlask>();
			itemType = OrchidModAlchemistHelper.containsAlchemistFlask(itemType, player, modPlayer) ? itemType : itemType2;
			int dmg = OrchidModAlchemistHelper.getSecondaryDamage(player, modPlayer, itemType, 4, true);
			for (int i = 0; i < 10; i++)
			{
				Vector2 vel = (new Vector2(0f, -5f).RotatedBy(MathHelper.ToRadians(Main.rand.Next(360))));
				int spawnProj = ProjectileType<Alchemist.Projectiles.Fire.FireSporeProj>();
				int spawnProj2 = Projectile.NewProjectile(player.GetSource_Misc("Alchemist Hidden Reaction"), player.Center, vel, spawnProj, dmg, 0f, player.whoAmI);
				Main.projectile[spawnProj2].localAI[1] = 1f;
			}
			int nb = 4 + Main.rand.Next(3);
			for (int i = 0; i < nb; i++)
			{
				Vector2 vel = (new Vector2(0f, (float)(3 + Main.rand.Next(4))).RotatedByRandom(MathHelper.ToRadians(180)));
				int spawnProj = ProjectileType<Alchemist.Projectiles.Fire.FireSporeProjAlt>();
				Projectile.NewProjectile(player.GetSource_Misc("Alchemist Hidden Reaction"), player.Center, vel, spawnProj, dmg, 0f, player.whoAmI);
			}
			if (OrchidModAlchemistHelper.containsAlchemistFlask(ItemType<Alchemist.Weapons.Nature.GlowingAttractiteFlask>(), player, modPlayer))
			{
				for (int i = 0; i < 5; i++)
				{
					Vector2 vel = (new Vector2(0f, -5f).RotatedBy(MathHelper.ToRadians(Main.rand.Next(360))));
					int spawnProj = ProjectileType<Alchemist.Projectiles.Nature.NatureSporeProj>();
					int spawnProj2 = Projectile.NewProjectile(player.GetSource_Misc("Alchemist Hidden Reaction"), player.Center, vel, spawnProj, dmg, 0f, player.whoAmI);
					Main.projectile[spawnProj2].localAI[1] = 1f;
				}
				for (int i = 0; i < 2; i++)
				{
					Vector2 vel = (new Vector2(0f, (float)(3 + Main.rand.Next(4))).RotatedByRandom(MathHelper.ToRadians(180)));
					int spawnProj = ProjectileType<Alchemist.Projectiles.Nature.NatureSporeProjAlt>();
					Projectile.NewProjectile(player.GetSource_Misc("Alchemist Hidden Reaction"), player.Center, vel, spawnProj, dmg, 0f, player.whoAmI);
				}
			}
		}
	}
}
