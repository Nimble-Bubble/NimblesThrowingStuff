using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;
using System;
using NimblesThrowingStuff.Projectiles.Melee;

namespace NimblesThrowingStuff.Items.Weapons.Melee
{
	public class Superfast : ModItem
	{
        public override void SetStaticDefaults()
        {
			Tooltip.SetDefault("A superfast pulsar-like yoyo that attacks relentlessly");
			ItemID.Sets.Yoyo[item.type] = true;
			ItemID.Sets.GamepadExtraRange[item.type] = 50;
			ItemID.Sets.GamepadSmartQuickReach[item.type] = true;
        }
        public override void SetDefaults() {
			item.damage = 125;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 8;
			item.useTime = 8;
			item.knockBack = 4f;
			item.width = 20;
			item.height = 20;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.rare = ItemRarityID.Cyan;
			item.value = Item.buyPrice(1, 0, 0, 0);
            item.melee = true;
			item.channel = true;
            item.shoot = ModContent.ProjectileType<SuperfastProj>();
            item.shootSpeed = 18f;
			item.UseSound = SoundID.Item1;
		}
	}
}