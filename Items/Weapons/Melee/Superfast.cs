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
			ItemID.Sets.Yoyo[Item.type] = true;
			ItemID.Sets.GamepadExtraRange[Item.type] = 50;
			ItemID.Sets.GamepadSmartQuickReach[Item.type] = true;
        }
        public override void SetDefaults() {
			Item.damage = 125;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 8;
			Item.useTime = 8;
			Item.knockBack = 4f;
			Item.width = 20;
			Item.height = 20;
			Item.noUseGraphic = true;
			Item.noMelee = true;
			Item.rare = ItemRarityID.Cyan;
			Item.value = Item.buyPrice(1, 0, 0, 0);
            Item.DamageType = DamageClass.Melee;
			Item.channel = true;
            Item.shoot = ModContent.ProjectileType<SuperfastProj>();
            Item.shootSpeed = 18f;
			Item.UseSound = SoundID.Item1;
		}
	}
}