﻿using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using System.Linq;
using OrchidMod.Gambler;
using static Terraria.ModLoader.ModContent;

namespace OrchidMod.Gambler
{
	public class GamblerDummyTest : OrchidModItem
	{
		public	override void SetDefaults() {
			item.melee = false;
			item.ranged = false;
			item.magic = false;
			item.thrown = false;
			item.summon = false;
			item.noMelee = true;
			item.maxStack = 1;
			item.width = 34;
			item.height = 34;
			item.useStyle = 1;
			item.noUseGraphic = true;
			//item.UseSound = SoundID.Item7;
			item.useAnimation = 30;
			item.useTime = 30;
			item.knockBack = 1f;
			item.damage = 1;
            item.rare = -11;
			item.shootSpeed = 1f;
			item.shoot = 1;
			item.autoReuse = true;
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			OrchidModPlayer modPlayer = player.GetModPlayer<OrchidModPlayer>();
			Item currentCard = modPlayer.gamblerCardDummy;
			if (OrchidModGamblerHelper.getNbGamblerCards(player, modPlayer) > 0) {
				if (player.altFunctionUse == 2 || modPlayer.gamblerCardDummy.type == 0) {
					Main.PlaySound(SoundID.Item64, player.position);
					OrchidModGamblerHelper.drawDummyCard(player, modPlayer);
					currentCard = modPlayer.gamblerCardDummy;
					this.checkStats(currentCard, modPlayer);
					Color floatingTextColor = new Color(255, 200, 0);
					CombatText.NewText(player.Hitbox, floatingTextColor, modPlayer.gamblerCardDummy.Name);
					return false;
				}
			} else {
				return false;
			}
			
			currentCard = modPlayer.gamblerCardDummy;
			this.checkStats(currentCard, modPlayer);
			currentCard.GetGlobalItem<OrchidModGlobalItem>().gamblerShootDelegate(player, position, speedX, speedY, type, item.damage, item.knockBack, true);
			return false;
		}
		
		public override void HoldItem(Player player) {
			OrchidModPlayer modPlayer = player.GetModPlayer<OrchidModPlayer>();
			modPlayer.GamblerDeckInHand = true;
			if (Main.mouseLeft) {
				OrchidModGamblerHelper.ShootBonusProjectiles(player, player.Center, true);
			}
		}
		
		public override void ModifyWeaponDamage(Player player, ref float add, ref float mult, ref float flat) {
			mult *= player.GetModPlayer<OrchidModPlayer>().gamblerDamage;
		}
		
		public override void GetWeaponCrit(Player player, ref int crit) {
			crit += player.GetModPlayer<OrchidModPlayer>().gamblerCrit;
		}
		
		// public override void UpdateInventory(Player player) {
			// OrchidModPlayer modPlayer = player.GetModPlayer<OrchidModPlayer>();
			// Item currentCard = modPlayer.gamblerCardCurrent;
			// this.checkStats(currentCard);
		// }
		
		public override bool AltFunctionUse(Player player) {
			return true;
		}
		
		public override bool CanUseItem(Player player) {
			if (player == Main.LocalPlayer) {
				if (player.altFunctionUse == 2) {
					item.useAnimation = 20;
					item.useTime = 20;
					item.reuseDelay = 0;
				}
			}
			return base.CanUseItem(player);
		}
		
		public override void ModifyTooltips(List<TooltipLine> tooltips) {
			Mod thoriumMod = ModLoader.GetMod("ThoriumMod");
			if (thoriumMod != null) {
				tooltips.Insert(1, new TooltipLine(mod, "ClassTag", "-Gambler Class-")
				{
					overrideColor = new Color(255, 200, 0)
				});
			}
			Player player = Main.player[Main.myPlayer]; 
			OrchidModPlayer modPlayer = player.GetModPlayer<OrchidModPlayer>();
			Item currentCard = modPlayer.gamblerCardDummy;
			if (currentCard.type != 0) {
				int index = tooltips.FindIndex(ttip => ttip.mod.Equals("Terraria") && ttip.Name.Equals("Tooltip0"));
				if (index != -1)
				{
					tooltips.Insert(index, new TooltipLine(mod, "CardType", currentCard.Name)
					{
						overrideColor = new Color(255, 200, 0)
					});
				}
			}
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Gambler Test Card");
		    Tooltip.SetDefault("Allows the use of specific gambler cards"
							+  "\nRight click to cycle through your deck"
							+  "\n[c/FF0000:Test Item]");
		}
		
		public void checkStats(Item currentCard, OrchidModPlayer modPlayer) {
			if (currentCard.type != 0) {
				item.damage = (int)(currentCard.damage * modPlayer.gamblerDamage);
				item.rare = currentCard.rare;
				item.crit = currentCard.crit + modPlayer.gamblerCrit;
				item.useAnimation = currentCard.useAnimation;
				item.useTime = currentCard.useTime;
				item.reuseDelay = currentCard.reuseDelay;
				item.knockBack = currentCard.knockBack;
				item.shootSpeed = currentCard.shootSpeed;
			} else {
				item.damage = 0;
				item.rare = 0;
				item.crit = 0;
				item.useAnimation = 1;
				item.useTime = 1;
				item.reuseDelay = 0;
				item.knockBack = 1f;
				item.shootSpeed = 1f;
			}
		}
	}
}
