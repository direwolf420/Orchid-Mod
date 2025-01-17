using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Microsoft.Xna.Framework;
using OrchidMod;
using OrchidMod.Alchemist.Weapons.Nature;
using OrchidMod.Alchemist.Weapons.Fire;
using OrchidMod.Alchemist.Weapons.Water;
using OrchidMod.Alchemist.Weapons.Air;
using OrchidMod.Alchemist.Weapons.Light;
using OrchidMod.Alchemist.Weapons.Dark;
using static Terraria.ModLoader.ModContent;

namespace OrchidMod.Alchemist
{
	public class AlchemistHiddenReactionHelper
	{
		public static List<AlchemistHiddenReactionRecipe> ListReactions() {
			/* Hint levels :
			<1 : Special
			1 : Pre EoC Vanilla
			2 : Pre Skeletron Vanilla
			3 : Pre WoF Vanilla
			4 : Pre Mechs Vanilla
			5 : Pre Golem Vanilla
			6 : Endgame Vanilla
			*/
			
			List<AlchemistHiddenReactionRecipe> recipes = new List<AlchemistHiddenReactionRecipe>();
			
			recipes.Add(new AlchemistHiddenReactionRecipe(AlchemistHiddenReactionType.SUNFLOWERSEEDS, -1, "Sunflower Seeds",
			"Releases damaging sunflower seeds around the player", 15, 2, 85, AlchemistHiddenReaction.SunflowerSeeds,
			ItemType<SunflowerFlask>(), ItemType<SlimeFlask>()));
			recipes.Add(new AlchemistHiddenReactionRecipe(AlchemistHiddenReactionType.BURNINGSAMPLES, 1, "Burning Samples",
			"Using slimy samples with a fire element will release damaging embers", 15, 2, 85, AlchemistHiddenReaction.BurningSamples,
			ItemType<SlimeFlask>(), ItemType<EmberVial>()));
			
			recipes.Add(new AlchemistHiddenReactionRecipe(AlchemistHiddenReactionType.GLOWSHROOMHEALING, 1, "Glowshroom Healing", 
			"Heals the player for 25 health", 30, 2, 25, AlchemistHiddenReaction.GlowshroomHealing,
			ItemType<GlowingMushroomVial>(), ItemType<KingSlimeFlask>()));
			
			recipes.Add(new AlchemistHiddenReactionRecipe(AlchemistHiddenReactionType.MUSHROOMTHREAD, -2, "Mushroom Thread", 
			"Creates a sample of Mushroom Thread, which can be used to create armor", 5, 2, 25, AlchemistHiddenReaction.MushroomThread,
			ItemType<GlowingMushroomVial>(), ItemType<BlinkrootFlask>()));
			
			recipes.Add(new AlchemistHiddenReactionRecipe(AlchemistHiddenReactionType.FIRESPORES, -3, "Fire Spores", 
			"Releases a sizeable amount of fire spores, which doesn't destroy existing ones", 20, 2, 45, AlchemistHiddenReaction.FireSpores,
			ItemType<AttractiteFlask>(), ItemType<BlinkrootFlask>()));
			
			recipes.Add(new AlchemistHiddenReactionRecipe(AlchemistHiddenReactionType.WATERSPORES, -3, "Water Spores", 
			"Releases a sizeable amount of water spores, which doesn't destroy existing ones", 20, 2, 45, AlchemistHiddenReaction.WaterSpores,
			ItemType<AttractiteFlask>(), ItemType<WaterleafFlask>()));
			
			recipes.Add(new AlchemistHiddenReactionRecipe(AlchemistHiddenReactionType.AIRSPORES, -3, "Air Spores", 
			"Releases a sizeable amount of air spores, which doesn't destroy existing ones", 20, 2, 45, AlchemistHiddenReaction.AirSpores,
			ItemType<AttractiteFlask>(), ItemType<ShiverthornFlask>()));
			
			recipes.Add(new AlchemistHiddenReactionRecipe(AlchemistHiddenReactionType.PROPULSION, 1, "Propulsion", 
			"Vertically propels the player", 10, 2, 14, AlchemistHiddenReaction.Propulsion,
			ItemType<GunpowderFlask>(), ItemType<CloudInAVial>()));
			recipes.Add(new AlchemistHiddenReactionRecipe(AlchemistHiddenReactionType.ATTRACTITESHURIKENS, 1, "Attractite Shurikens", 
			"Creates a maximum of 5 attractite shuriken, inflicting attractite to hit enemies", 15, 2, 25, AlchemistHiddenReaction.AttractiteShurikens,
			ItemType<AttractiteFlask>(), ItemType<KingSlimeFlask>()));
			recipes.Add(new AlchemistHiddenReactionRecipe(AlchemistHiddenReactionType.MISTYSTEPS, 1, "Misty Steps", 
			"Releases harmful mist when moving", 20, 2, 85, AlchemistHiddenReaction.MistySteps,
			ItemType<BloodMoonFlask>(), ItemType<CloudInAVial>(), ItemType<GlowingMushroomVial>()));
			recipes.Add(new AlchemistHiddenReactionRecipe(AlchemistHiddenReactionType.PERMANENTFREEZE, 1, "Permanent Freeze", 
			"Constantly applies the flash freeze aura around the player", 15, 2, 25, AlchemistHiddenReaction.PermanentFreeze,
			ItemType<IceChestFlask>(), ItemType<GunpowderFlask>(), ItemType<CloudInAVial>()));
			recipes.Add(new AlchemistHiddenReactionRecipe(AlchemistHiddenReactionType.STELLARTALCORBIT, 2, "Stellar Talc Orbit", 
			"Stellar Talc projectiles will orbit the user", 20, 2, 85, AlchemistHiddenReaction.StellarTalcOrbit,
			ItemType<SunplateFlask>(), ItemType<AttractiteFlask>()));
			
			recipes.Add(new AlchemistHiddenReactionRecipe(AlchemistHiddenReactionType.BUBBLESLIME, 1, "Slime Bubble", 
			"Creates a catalytic slime bubble", 20, 2, 85, AlchemistHiddenReaction.BubbleSlime,
			ItemType<CloudInAVial>(), ItemType<KingSlimeFlask>()));
			recipes.Add(new AlchemistHiddenReactionRecipe(AlchemistHiddenReactionType.BUBBLESAP, 1, "Sap Bubble", 
			"Creates a catalytic sap bubble", 20, 2, 85, AlchemistHiddenReaction.BubbleSap,
			ItemType<CloudInAVial>(), ItemType<LivingSapVial>()));
			recipes.Add(new AlchemistHiddenReactionRecipe(AlchemistHiddenReactionType.BUBBLEOIL, 1, "Oil Bubble", 
			"Creates a catalytic oil bubble", 20, 2, 85, AlchemistHiddenReaction.BubbleOil,
			ItemType<CloudInAVial>(), ItemType<GoblinArmyFlask>()));
			recipes.Add(new AlchemistHiddenReactionRecipe(AlchemistHiddenReactionType.BUBBLESPIRITED, 3, "Spirited Bubble", 
			"Creates a catalytic spirit bubble", 20, 2, 85, AlchemistHiddenReaction.BubbleSpirited,
			ItemType<CloudInAVial>(), ItemType<DungeonFlask>()));
			recipes.Add(new AlchemistHiddenReactionRecipe(AlchemistHiddenReactionType.BUBBLESEAFOAM, 1, "Seafoam Bubble", 
			"Creates a catalytic seafoam bubble", 20, 2, 85, AlchemistHiddenReaction.BubbleSeafoam,
			ItemType<CloudInAVial>(), ItemType<SeafoamVial>()));
			recipes.Add(new AlchemistHiddenReactionRecipe(AlchemistHiddenReactionType.BUBBLEPOISON, 2, "Poison Bubble", 
			"Creates a catalytic poison bubble", 20, 2, 85, AlchemistHiddenReaction.BubblePoison,
			ItemType<CloudInAVial>(), ItemType<PoisonVial>()));
			recipes.Add(new AlchemistHiddenReactionRecipe(AlchemistHiddenReactionType.BUBBLESLIMELAVA, 3, "Lava Slime Bubble", 
			"Creates a catalytic lava slime bubble", 20, 2, 85, AlchemistHiddenReaction.BubbleSlimeLava,
			ItemType<CloudInAVial>(), ItemType<HellSlimeFlask>()));
			recipes.Add(new AlchemistHiddenReactionRecipe(AlchemistHiddenReactionType.JUNGLELILYPURIFICATION, -4, "Lily Purification", 
			"Cleanses most common early-game debuffs and blooms jungle lilies around the user", 10, 2, 85, AlchemistHiddenReaction.JungleLilyPurification,
			ItemType<JungleLilyFlask>(), ItemType<CorruptionFlask>()));
			recipes.Add(new AlchemistHiddenReactionRecipe(AlchemistHiddenReactionType.LILIESPURIFICATION, 2, "Purifying Lilies", 
			"Each alchemical attack using 2 or more elements will release a purifying aura", 10, 2, 85, AlchemistHiddenReaction.LiliesPurification,
			ItemType<JungleLilyFlask>(), ItemType<CorruptionFlask>(), ItemType<GunpowderFlask>()));
			
			recipes.Add(new AlchemistHiddenReactionRecipe(AlchemistHiddenReactionType.POISONOUSSLIME, 2, "Poisonous Slime", 
			"Increases the likelyhood of spawning slime bubbles, creating spiked jungle slimes", 20, 2, 85, AlchemistHiddenReaction.PoisonousSlime,
			ItemType<KingSlimeFlask>(), ItemType<PoisonVial>()));
			recipes.Add(new AlchemistHiddenReactionRecipe(AlchemistHiddenReactionType.BEESWARM, 2, "Bee Swarm", 
			"Releases a swarm of harmful bees around the player", 25, 2, 97, AlchemistHiddenReaction.BeeSwarm,
			ItemType<QueenBeeFlask>(), ItemType<PoisonVial>()));
			recipes.Add(new AlchemistHiddenReactionRecipe(AlchemistHiddenReactionType.LIVINGBEEHIVE, 2, "Living Beehive", 
			"Every attack using 3 or more element will summon bees", 25, 2, 97, AlchemistHiddenReaction.LivingBeehive,
			ItemType<QueenBeeFlask>(), ItemType<GunpowderFlask>(), ItemType<JungleLilyFlask>()));
			recipes.Add(new AlchemistHiddenReactionRecipe(AlchemistHiddenReactionType.BUBBLES, 2, "Bubbles", 
			"Releases bubbles over a large area", 15, 2, 85, AlchemistHiddenReaction.Bubbles,
			ItemType<SeafoamVial>(), ItemType<PoisonVial>()));
			recipes.Add(new AlchemistHiddenReactionRecipe(AlchemistHiddenReactionType.SPIRITEDDROPLETS, 3, "Spirited Droplets", 
			"Chemical attacks will release spirited water flames", 20, 2, 85, AlchemistHiddenReaction.SpiritedDroplets,
			ItemType<DungeonFlask>(), ItemType<GunpowderFlask>(), ItemType<AttractiteFlask>()));
			recipes.Add(new AlchemistHiddenReactionRecipe(AlchemistHiddenReactionType.DEMONREEKS, 3, "Demon Reeks", 
			"Demon breath projectiles will replicate on death", 20, 2, 85, AlchemistHiddenReaction.DemonReeks,
			ItemType<ShadowChestFlask>(), ItemType<GoblinArmyFlask>()));
			
			recipes.Add(new AlchemistHiddenReactionRecipe(AlchemistHiddenReactionType.POTIONFLIPPER, 1, "Flipper Potion", 
			"Gives 30 seconds of Flipper Potion effect", 30, 2, 25, AlchemistHiddenReaction.PotionFlipper,
			ItemType<ShiverthornFlask>(), ItemType<WaterleafFlask>()));
			recipes.Add(new AlchemistHiddenReactionRecipe(AlchemistHiddenReactionType.POTIONOBSIDIAN, 1, "Obsidian Potion", 
			"Gives 30 seconds of Obsidian Potion effect", 30, 2, 25, AlchemistHiddenReaction.PotionObsidian,
			ItemType<FireblossomFlask>(), ItemType<WaterleafFlask>()));
			recipes.Add(new AlchemistHiddenReactionRecipe(AlchemistHiddenReactionType.POTIONNIGHTOWL, 1, "Night Owl Potion", 
			"Gives 30 seconds of Night Owl Potion effect", 30, 2, 25, AlchemistHiddenReaction.PotionNightOwl,
			ItemType<DaybloomFlask>(), ItemType<BlinkrootFlask>()));
			recipes.Add(new AlchemistHiddenReactionRecipe(AlchemistHiddenReactionType.POTIONINVISIBILITY, 1, "Invisibility Potion", 
			"Gives 30 seconds of Invisibility Potion effect", 30, 2, 25, AlchemistHiddenReaction.PotionInvisibility,
			ItemType<BlinkrootFlask>(), ItemType<MoonglowFlask>()));
			recipes.Add(new AlchemistHiddenReactionRecipe(AlchemistHiddenReactionType.POTIONBUILDER, 1, "Builder Potion", 
			"Gives 30 seconds of Builder Potion effect", 30, 2, 25, AlchemistHiddenReaction.PotionBuilder,
			ItemType<BlinkrootFlask>(), ItemType<ShiverthornFlask>(), ItemType<MoonglowFlask>()));
			recipes.Add(new AlchemistHiddenReactionRecipe(AlchemistHiddenReactionType.POTIONFEATHERFALL, 1, "Featherfall Potion", 
			"Gives 30 seconds of Featherfall Potion effect", 30, 2, 25, AlchemistHiddenReaction.PotionFeatherFall,
			ItemType<DaybloomFlask>(), ItemType<BlinkrootFlask>(), ItemType<CloudInAVial>()));
			
			return recipes;
		}
		
		public static void triggerAlchemistReactionEffects(AlchemistHiddenReactionRecipe recipe, Mod mod, Player player, OrchidModPlayer modPlayer) {
			recipe.recipeEffect(recipe, player, modPlayer);
			
			if (recipe.debuffDuration != 0) {
				player.AddBuff((BuffType<Alchemist.Buffs.Debuffs.ReactionCooldown>()), 60 * recipe.debuffDuration);
			}
			
			if (recipe.soundID != 0 && recipe.soundType != 0) {
				Main.PlaySound(recipe.soundType, (int)player.position.X, (int)player.position.Y, recipe.soundID);
			}
		}
		
		public static bool checkSubstitutes(int ingredientID, Mod mod, Player player, OrchidModPlayer modPlayer) {
			List<int> ingredientToCompare = new List<int>();
			ingredientToCompare.Add(ItemType<CloudInAVial>());
			ingredientToCompare.Add(ItemType<AttractiteFlask>());
			ingredientToCompare.Add(ItemType<BlinkrootFlask>());
			ingredientToCompare.Add(ItemType<ShiverthornFlask>());
			ingredientToCompare.Add(ItemType<CorruptionFlask>());
			ingredientToCompare.Add(ItemType<GoblinArmyFlask>());
			
			foreach (int ingredient in ingredientToCompare) {
				if (ingredientID == ItemType<CloudInAVial>()) {
					return (OrchidModAlchemistHelper.containsAlchemistFlask(ItemType<FartInAVial>(), player, modPlayer)
					|| OrchidModAlchemistHelper.containsAlchemistFlask(ItemType<BlizzardInAVial>(), player, modPlayer)
					|| OrchidModAlchemistHelper.containsAlchemistFlask(ItemType<TsunamiInAVial>(), player, modPlayer));
				}
				if (ingredientID == ItemType<AttractiteFlask>()) {
					return OrchidModAlchemistHelper.containsAlchemistFlask(ItemType<GlowingAttractiteFlask>(), player, modPlayer);
				}
				if (ingredientID == ItemType<GoblinArmyFlask>()) {
					return OrchidModAlchemistHelper.containsAlchemistFlask(ItemType<HellOil>(), player, modPlayer);
				}
				if (ingredientID == ItemType<BlinkrootFlask>()) {
					return OrchidModAlchemistHelper.containsAlchemistFlask(ItemType<FireblossomFlask>(), player, modPlayer);
				}
				if (ingredientID == ItemType<ShiverthornFlask>()) {
					return OrchidModAlchemistHelper.containsAlchemistFlask(ItemType<DeathweedFlask>(), player, modPlayer);
				}
				if (ingredientID == ItemType<CorruptionFlask>()) {
					return OrchidModAlchemistHelper.containsAlchemistFlask(ItemType<CrimsonFlask>(), player, modPlayer);
				}
			}
			return false;
		}
		
		public static void triggerAlchemistReaction(Mod mod, Player player, OrchidModPlayer modPlayer) {
			string floatingTextStr = "Failed reaction ...";
			AlchemistHiddenReactionRecipe hiddenReaction = AlchemistHiddenReaction.NullRecipe;
			
			foreach (AlchemistHiddenReactionRecipe recipe in OrchidMod.alchemistReactionRecipes) {
				bool goodIngredients = true;
				if (modPlayer.alchemistNbElements == recipe.reactionIngredients.Count) {
					foreach(int ingredientID in recipe.reactionIngredients) {
						if (!(OrchidModAlchemistHelper.containsAlchemistFlask(ingredientID, player, modPlayer))) {
							if (!AlchemistHiddenReactionHelper.checkSubstitutes(ingredientID, mod, player, modPlayer)) {
								goodIngredients = false;
								break;	
							}
						}
					}
					if (goodIngredients) {
						hiddenReaction = recipe;
						floatingTextStr = recipe.reactionText;
						
						int val = 0;
						Item item = new Item();
						foreach(int ingredientID in recipe.reactionIngredients) {
							item.SetDefaults(ingredientID);
							OrchidModGlobalItem globalItem = item.GetGlobalItem<OrchidModGlobalItem>();
							val += globalItem.alchemistPotencyCost;
						}
						val = (int)(val / 2);
						CombatText.NewText(player.Hitbox, new Color(128, 255, 0), val);
						modPlayer.alchemistPotency += modPlayer.alchemistPotency + val > modPlayer.alchemistPotencyMax ? modPlayer.alchemistPotencyMax : modPlayer.alchemistPotency;
						break;
					}
				}
			}
			
			Color floatingTextColor = hiddenReaction.reactionType != AlchemistHiddenReactionType.NULL ? new Color(128, 255, 0) : new Color(255, 0, 0);
			CombatText.NewText(player.Hitbox, floatingTextColor, floatingTextStr);
			
			if (hiddenReaction.reactionType == AlchemistHiddenReactionType.NULL) {
				player.AddBuff((BuffType<Alchemist.Buffs.Debuffs.ReactionCooldown>()), 60 * 5);
				for(int i=0; i < 15; i++)
				{
					int dust = Dust.NewDust(player.Center, 10, 10, 37);
					Main.dust[dust].noGravity = true;
					Main.dust[dust].velocity *= 2f;
					Main.dust[dust].scale *= 1.2f;
				}
				for(int i=0; i < 10; i++)
				{
					int dust = Dust.NewDust(player.Center, 10, 10, 6);
					Main.dust[dust].noGravity = true;
					Main.dust[dust].velocity *= 2f;
					Main.dust[dust].scale *= 1.5f;
				}
				Main.PlaySound(2, (int)player.position.X, (int)player.position.Y, 16);
			} else {
				triggerAlchemistReactionEffects(hiddenReaction, mod, player, modPlayer);
				
				if (!(modPlayer.alchemistKnownReactions.Contains((int)hiddenReaction.reactionType))) {
					if (modPlayer.alchemistKnownHints.Contains((int)hiddenReaction.reactionType)) {
						modPlayer.alchemistKnownHints.Remove((int)hiddenReaction.reactionType);
					}
					modPlayer.alchemistKnownReactions.Add((int)hiddenReaction.reactionType);
					floatingTextColor = new Color(255, 187, 0);
					floatingTextStr = "New Entry";
					Rectangle rect = player.Hitbox;
					rect.Y -= 50;
					CombatText.NewText(rect, floatingTextColor, floatingTextStr);
				}
			}
			
			int colorRed = modPlayer.alchemistColorR;
			int colorGreen = modPlayer.alchemistColorG;
			int colorBlue = modPlayer.alchemistColorB;
			
			int rand = 2 + Main.rand.Next(3);
			for (int i = 0 ; i < rand ; i ++) {
				int proj = ProjectileType<Alchemist.Projectiles.AlchemistSmoke1>();
				Vector2 vel = (new Vector2(0f, -((float)(2 + Main.rand.Next(5)))).RotatedByRandom(MathHelper.ToRadians(180)));
				int smokeProj = Projectile.NewProjectile(player.Center.X, player.Center.Y, vel.X, vel.Y, proj, 0, 0f, player.whoAmI);
				Main.projectile[smokeProj].localAI[0] = colorRed;
				Main.projectile[smokeProj].localAI[1] = colorGreen;
				Main.projectile[smokeProj].ai[1] = colorBlue;
			}
			rand = 1 + Main.rand.Next(3);
			for (int i = 0 ; i < rand ; i ++) {
				int proj = ProjectileType<Alchemist.Projectiles.AlchemistSmoke2>();
				Vector2 vel = (new Vector2(0f, -((float)(2 + Main.rand.Next(5)))).RotatedByRandom(MathHelper.ToRadians(180)));
				int smokeProj = Projectile.NewProjectile(player.Center.X, player.Center.Y, vel.X, vel.Y, proj, 0, 0f, player.whoAmI);
				Main.projectile[smokeProj].localAI[0] = colorRed;
				Main.projectile[smokeProj].localAI[1] = colorGreen;
				Main.projectile[smokeProj].ai[1] = colorBlue;
			}
			rand = Main.rand.Next(2);
			for (int i = 0 ; i < rand ; i ++) {
				int proj = ProjectileType<Alchemist.Projectiles.AlchemistSmoke3>();
				Vector2 vel = (new Vector2(0f, -((float)(2 + Main.rand.Next(5)))).RotatedByRandom(MathHelper.ToRadians(180)));
				int smokeProj = Projectile.NewProjectile(player.Center.X, player.Center.Y, vel.X, vel.Y, proj, 0, 0f, player.whoAmI);
				Main.projectile[smokeProj].localAI[0] = colorRed;
				Main.projectile[smokeProj].localAI[1] = colorGreen;
				Main.projectile[smokeProj].ai[1] = colorBlue;
			}
			
			AlchemistHiddenReactionHelper.bonusReactionEffects(mod, player, modPlayer);
			
			modPlayer.alchemistFlaskDamage = 0;
			modPlayer.alchemistNbElements = 0;
			OrchidModAlchemistHelper.clearAlchemistElements(player, modPlayer, mod);
			OrchidModAlchemistHelper.clearAlchemistFlasks(player, modPlayer, mod);
			OrchidModAlchemistHelper.clearAlchemistColors(player, modPlayer, mod);
			modPlayer.alchemistSelectUIDisplay = false;
		}
		
		public static void bonusReactionEffects(Mod mod, Player player, OrchidModPlayer modPlayer) {
			if (modPlayer.alchemistReactiveVials) {
				player.AddBuff(BuffType<Alchemist.Buffs.ReactiveVialsBuff>(), 60 * 10);
			}
		}
		
		public static void addAlchemistHint(Player player, OrchidModPlayer modPlayer, int hintLevel, bool negativeMessage = true) {
			Color floatingTextColor = new Color(0,0,0);
			string floatingTextStr = "";
			List<AlchemistHiddenReactionRecipe> validHints = new List<AlchemistHiddenReactionRecipe>();
			
			foreach (AlchemistHiddenReactionRecipe recipe in OrchidMod.alchemistReactionRecipes) {
				if (recipe.reactionLevel == hintLevel) {
					if (!(modPlayer.alchemistKnownReactions.Contains((int)recipe.reactionType) || modPlayer.alchemistKnownHints.Contains((int)recipe.reactionType))) {
						validHints.Add(recipe);
					}
				}
			}
			
			if (validHints.Count == 0) {
				if (negativeMessage) {
					floatingTextColor = new Color(255, 92, 0);
					floatingTextStr = "No hints left for this tier";
					CombatText.NewText(player.Hitbox, floatingTextColor, floatingTextStr);
				}
			} else {
				int rand = Main.rand.Next(validHints.Count);
				AlchemistHiddenReactionRecipe hint = validHints[rand];
				modPlayer.alchemistKnownHints.Add((int)hint.reactionType);
				if (!modPlayer.alchemistEntryTextCooldown) {
					floatingTextColor = new Color(255, 187, 0);
					floatingTextStr = "New Hidden Reaction Hint";
					CombatText.NewText(player.Hitbox, floatingTextColor, floatingTextStr);
					modPlayer.alchemistEntryTextCooldown = true;
				}
			}
		}
	}
}