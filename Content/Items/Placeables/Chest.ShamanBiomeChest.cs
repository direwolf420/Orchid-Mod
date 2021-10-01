using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.GameContent.Achievements;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace OrchidMod.Content.Items.Placeables
{
	public class ShamanBiomeChest : OrchidItem
	{
		public override void SetDefaults()
		{
			item.width = 32;
			item.height = 32;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.consumable = true;
			item.value = Item.sellPrice(0, 0, 5, 0);
			item.createTile = ModContent.TileType<ShamanBiomeChestTile>();
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Shroom Chest");
		}
	}

	public class ShroomKey : OrchidItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Shroom Key");
			Tooltip.SetDefault("Unlocks a Shroom Chest in the dungeon");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 28;
			item.maxStack = 1;
			item.useStyle = 0;
			item.rare = ItemRarityID.Yellow;
			item.value = Item.sellPrice(0, 0, 0, 0);
		}

		public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			var tooltip = tooltips.Find(i => i.mod == "Terraria" && i.Name.StartsWith("Tooltip"));

			if (tooltip != null && !NPC.downedPlantBoss) tooltip.text = Language.GetTextValue("LegacyTooltip.59");
		}
	}

	public class ShamanBiomeChestTile : OrchidTile
	{
		public override void SetDefaults()
		{
			Main.tileSpelunker[Type] = true;
			Main.tileContainer[Type] = true;
			Main.tileShine2[Type] = true;
			Main.tileShine[Type] = 1200;
			Main.tileFrameImportant[Type] = true;
			Main.tileNoAttach[Type] = true;
			Main.tileValue[Type] = 500;
			TileID.Sets.HasOutlines[Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
			TileObjectData.newTile.Origin = new Point16(0, 1);
			TileObjectData.newTile.CoordinateHeights = new[] { 16, 18 };
			TileObjectData.newTile.HookCheck = new PlacementHook(new Func<int, int, int, int, int, int>(Chest.FindEmptyChest), -1, 0, true);
			TileObjectData.newTile.HookPostPlaceMyPlayer = new PlacementHook(new Func<int, int, int, int, int, int>(Chest.AfterPlacement_Hook), -1, 0, false);
			TileObjectData.newTile.AnchorInvalidTiles = new[] { 127 };
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.newTile.LavaDeath = false;
			TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
			TileObjectData.addTile(Type);

			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Shroom Chest");
			AddMapEntry(new Color(174, 129, 92), name, MapChestName);
			name = CreateMapEntryName("_Locked" + Name);
			name.SetDefault("Locked Shroom Chest");
			AddMapEntry(new Color(174, 129, 92), name, MapChestName);

			dustType = 239;
			disableSmartCursor = true;
			adjTiles = new int[] { TileID.Containers };
			chest = "Shroom Chest";
			chestDrop = ModContent.ItemType<ShamanBiomeChest>();
		}

		public override ushort GetMapOption(int i, int j) => (ushort)(Main.tile[i, j].frameX / 36);

		public override bool HasSmartInteract() => true;

		public override bool IsLockedChest(int i, int j) => Main.tile[i, j].frameX / 36 == 1;

		public override bool UnlockChest(int i, int j, ref short frameXAdjustment, ref int dustType, ref bool manual)
		{
			if (!NPC.downedPlantBoss) return false;

			AchievementsHelper.NotifyProgressionEvent(20);
			return true;
		}

		public string MapChestName(string name, int i, int j)
		{
			if (i < 0 || i >= Main.maxTilesX || j < 0 || j >= Main.maxTilesY)
				return name;
			Tile tile = Main.tile[i, j];
			if (tile == null)
				return name;
			int left = i;
			int top = j;
			if (tile.frameX % 36 != 0) left--;
			if (tile.frameY != 0) top--;
			int chest = Chest.FindChest(left, top);
			return name + ((Main.chest[chest].name != "") ? (": " + Main.chest[chest].name) : "");
		}

		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = 1;
		}

		public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			Item.NewItem(i * 16, j * 16, 32, 32, chestDrop);
			Chest.DestroyChest(i, j);
		}

		public override bool NewRightClick(int i, int j)
		{
			Player player = Main.LocalPlayer;
			Tile tile = Main.tile[i, j];
			Main.mouseRightRelease = false;
			int left = i;
			int top = j;
			if (tile.frameX % 36 != 0)
			{
				left--;
			}
			if (tile.frameY != 0)
			{
				top--;
			}
			if (player.sign >= 0)
			{
				Main.PlaySound(SoundID.MenuClose);
				player.sign = -1;
				Main.editSign = false;
				Main.npcChatText = "";
			}
			if (Main.editChest)
			{
				Main.PlaySound(SoundID.MenuTick);
				Main.editChest = false;
				Main.npcChatText = "";
			}
			if (player.editedChestName)
			{
				NetMessage.SendData(MessageID.SyncPlayerChest, -1, -1, NetworkText.FromLiteral(Main.chest[player.chest].name), player.chest, 1f, 0f, 0f, 0, 0, 0);
				player.editedChestName = false;
			}
			bool isLocked = IsLockedChest(left, top);
			if (Main.netMode == NetmodeID.MultiplayerClient && !isLocked)
			{
				if (left == player.chestX && top == player.chestY && player.chest >= 0)
				{
					player.chest = -1;
					Recipe.FindRecipes();
					Main.PlaySound(SoundID.MenuClose);
				}
				else
				{
					NetMessage.SendData(MessageID.RequestChestOpen, -1, -1, null, left, (float)top, 0f, 0f, 0, 0, 0);
					Main.stackSplit = 600;
				}
			}
			else
			{
				if (isLocked)
				{
					if (!NPC.downedPlantBoss)
					{
						return true;
					}

					int key = ModContent.ItemType<ShroomKey>();
					if (player.ConsumeItem(key) && Chest.Unlock(left, top))
					{
						if (Main.netMode == NetmodeID.MultiplayerClient)
						{
							NetMessage.SendData(MessageID.Unlock, -1, -1, null, player.whoAmI, 1f, (float)left, (float)top);
						}
					}
				}
				else
				{
					int chest = Chest.FindChest(left, top);
					if (chest >= 0)
					{
						Main.stackSplit = 600;
						if (chest == player.chest)
						{
							player.chest = -1;
							Main.PlaySound(SoundID.MenuClose);
						}
						else
						{
							player.chest = chest;
							Main.playerInventory = true;
							Main.recBigList = false;
							player.chestX = left;
							player.chestY = top;
							Main.PlaySound(player.chest < 0 ? SoundID.MenuOpen : SoundID.MenuTick);
						}
						Recipe.FindRecipes();
					}
				}
			}
			return true;
		}

		public override void MouseOver(int i, int j)
		{
			Player player = Main.LocalPlayer;
			Tile tile = Main.tile[i, j];
			int left = i;
			int top = j;
			if (tile.frameX % 36 != 0)
			{
				left--;
			}
			if (tile.frameY != 0)
			{
				top--;
			}
			int chest = Chest.FindChest(left, top);
			player.showItemIcon2 = -1;
			if (chest < 0)
			{
				player.showItemIconText = Language.GetTextValue("LegacyChestType.0");
			}
			else
			{
				player.showItemIconText = Main.chest[chest].name.Length > 0 ? Main.chest[chest].name : "Shroom Chest";
				if (player.showItemIconText == "Shroom Chest")
				{
					player.showItemIcon2 = ModContent.ItemType<ShamanBiomeChest>(); // Chest icon
					if (Main.tile[left, top].frameX / 36 == 1) player.showItemIcon2 = ModContent.ItemType<ShroomKey>(); // Key icon
					player.showItemIconText = "";
				}
			}
			player.noThrow = 2;
			player.showItemIcon = true;
		}

		public override void MouseOverFar(int i, int j)
		{
			MouseOver(i, j);
			Player player = Main.LocalPlayer;
			if (player.showItemIconText == "")
			{
				player.showItemIcon = false;
				player.showItemIcon2 = 0;
			}
		}
	}
}