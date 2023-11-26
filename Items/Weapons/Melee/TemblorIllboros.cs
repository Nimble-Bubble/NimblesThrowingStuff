using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;
using System;
using NimblesThrowingStuff.Projectiles.Melee;
using NimblesThrowingStuff.Items.Materials;
using Terraria.GameContent.Creative;

namespace NimblesThrowingStuff.Items.Weapons.Melee
{
	public class TemblorIllboros : ModItem
	{
        private bool alting;
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}
		public override void SetDefaults()
		{
			Item.damage = 120;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 42;
			Item.useTime = 42;
			Item.knockBack = 11f;
			Item.width = 128;
			Item.height = 128;
			Item.noUseGraphic = true;
			Item.noMelee = true;
			Item.rare = ItemRarityID.Yellow;
			Item.value = Item.buyPrice(0, 45, 0, 0);
			Item.DamageType = DamageClass.Melee;
			Item.channel = true;
			Item.shoot = ModContent.ProjectileType<TemblorIllborosProj>();
			Item.shootSpeed = 12f;
			Item.autoReuse = true;
			Item.UseSound = SoundID.Item1;
			Item.crit = 20;
		}
		//You might notice that the swinging animation looks weird
		//That's due to how big the sprite is
		//The swinging animation was presumably meant for much smaller weapons
        public override bool AltFunctionUse(Player player)
        {
            return true;
        }
        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                alting = true;
                Item.useStyle = ItemUseStyleID.Swing;
                Item.shoot = ProjectileID.None;
                Item.noUseGraphic = false;
                Item.noMelee = false;
            }
            else
            {
                alting = false;
                Item.useStyle = ItemUseStyleID.Shoot;
                Item.shoot = ModContent.ProjectileType<TemblorIllborosProj>();
                Item.noUseGraphic = true;
                Item.noMelee = true;
            }
            return base.CanUseItem(player);
        }
        /* public override Vector2? HoldoutOffset()
        {
            if (alting)
            {
				return new Vector2 (-80, 0);
            }
            else
            {
                return new Vector2 (0, 0);
            }
        } */
        public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Lepidolancea>(), 1);
			recipe.AddIngredient(ItemID.LihzahrdBrick, 50);
			recipe.AddIngredient(ItemID.LunarTabletFragment, 5);
			recipe.AddTile(TileID.LihzahrdFurnace);
			recipe.Register();
		}
	}
}