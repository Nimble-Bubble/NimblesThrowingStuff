using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;

namespace NimblesThrowingStuff.Items.Accessories
{
    public class ThrowerEmblem : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            // Tooltip.SetDefault("15% increased thrown damage");
        }
        public override void SetDefaults()
        {
            Item.accessory = true;
            Item.width = 28;
            Item.height = 28;
            Item.value = Item.value = Item.buyPrice(0, 10, 0, 0);
            Item.rare = ItemRarityID.LightRed;
            Item.expert = false;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetDamage(DamageClass.Throwing) += 0.15f;
        }
        public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(935, 1);
			recipe.AddIngredient(this);
            recipe.AddIngredient(547, 5);
			recipe.AddIngredient(548, 5);
            recipe.AddIngredient(549, 5);
			recipe.AddTile(114);
			recipe.Register();
            //Some mods let you swap the emblems for each other, and I don't know how to do Shimmer recipes yet, so this is my solution for the time being
            recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.SorcererEmblem);
			recipe.AddTile(114);
			recipe.Register();
            recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.WarriorEmblem);
			recipe.AddTile(114);
			recipe.Register();
            recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.RangerEmblem);
			recipe.AddTile(114);
			recipe.Register();
            recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.SummonerEmblem);
			recipe.AddTile(114);
			recipe.Register();
            recipe = Recipe.Create(ItemID.SorcererEmblem, 1);
			recipe.AddIngredient(this);
			recipe.AddTile(114);
			recipe.Register();
            recipe = Recipe.Create(ItemID.WarriorEmblem, 1);
			recipe.AddIngredient(this);
			recipe.AddTile(114);
			recipe.Register();
            recipe = Recipe.Create(ItemID.RangerEmblem, 1);
			recipe.AddIngredient(this);
			recipe.AddTile(114);
			recipe.Register();
            recipe = Recipe.Create(ItemID.SummonerEmblem, 1);
			recipe.AddIngredient(this);
			recipe.AddTile(114);
			recipe.Register();
        }
    }
}
