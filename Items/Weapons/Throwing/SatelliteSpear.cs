using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace NimblesThrowingStuff.Items.Weapons.Throwing
{
	public class SatelliteSpear : ModItem
	{
		public override void SetStaticDefaults()
        {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}
		public override void SetDefaults()
		{
			Item.damage = 125;
			Item.width = 64;
			Item.height = 64;
			Item.useTime = 25;
			Item.useAnimation = 25;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.value = Item.buyPrice(1, 25, 0, 0);
			Item.rare = ItemRarityID.Red;
			Item.noMelee = true;
            Item.noUseGraphic = true;
			Item.mana = 30;
			Item.UseSound = SoundID.Item1;
			Item.shoot = Mod.Find<ModProjectile>("SatelliteSpearProj").Type;
			Item.shootSpeed = 16f;
            Item.knockBack = 5f;
			Item.DamageType = DamageClass.Throwing;
			Item.autoReuse = true;
		}
	}
}