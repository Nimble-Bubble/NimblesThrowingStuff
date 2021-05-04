using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;
using System;
using NimblesThrowingStuff.Projectiles.Melee;

namespace NimblesThrowingStuff.Items.Weapons.Melee
{
	public class SkyseaSpinner : ModItem
	{
        public override void SetStaticDefaults()
        {
			Tooltip.SetDefault("A very agile yoyo that rains spikes upon its targets");
			ItemID.Sets.Yoyo[item.type] = true;
			ItemID.Sets.GamepadExtraRange[item.type] = 50;
			ItemID.Sets.GamepadSmartQuickReach[item.type] = true;
        }
        public override void SetDefaults() {
			item.damage = 220;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 24;
			item.useTime = 24;
			item.knockBack = 7f;
			item.width = 20;
			item.height = 20;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.rare = ItemRarityID.Purple;
			item.value = Item.buyPrice(1, 0, 0, 0);
            item.melee = true;
			item.channel = true;
            item.shoot = ModContent.ProjectileType<SkyseaSpinnerProj>();
            item.shootSpeed = 14f;
			item.UseSound = SoundID.Item1;
		}
	}
}