using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;
using System;
using NimblesThrowingStuff.Projectiles.Melee;

namespace NimblesThrowingStuff.Items.Weapons.Melee
{
	public class DemonLance : ModItem
	{
        public override void SetStaticDefaults()
        {
			Tooltip.SetDefault("Cthulhu's hardened flesh brings out the best in shortswords.");
        }
        public override void SetDefaults() {
			item.damage = 16;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 24;
			item.useTime = 24;
			item.knockBack = 5.5f;
			item.width = 20;
			item.height = 20;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.rare = ItemRarityID.Blue;
			item.value = Item.buyPrice(0, 0, 1, 35);
            item.melee = true;
			item.channel = true;
            item.shoot = ModContent.ProjectileType<DemonLanceProj>();
            item.shootSpeed = 10f;
			item.UseSound = SoundID.Item1;
		}
	}
}