using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using NimblesThrowingStuff.Items.Materials;
using Terraria.GameContent.Creative;

namespace NimblesThrowingStuff.Items.Accessories
{
    [AutoloadEquip(EquipType.Back)]
    public class BreathingPack : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            Item.accessory = true;
            Item.width = 24;
            Item.height = 42;
            Item.value = Item.value = Item.buyPrice(0, 12, 50, 0);
            Item.rare = ItemRarityID.Orange;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.gills = true;
            player.buffImmune[BuffID.Suffocation] = true;
        }
        public override void AddRecipes() 
        {
			Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.MeteoriteBar, 12);
            recipe.AddIngredient(ItemID.Leather, 6);
            recipe.AddIngredient(ItemID.ShadowScale, 10);
            recipe.AddIngredient(ItemID.WhitePearl, 1);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
            recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.MeteoriteBar, 12);
            recipe.AddIngredient(ItemID.Leather, 6);
            recipe.AddIngredient(ItemID.TissueSample, 10);
            recipe.AddIngredient(ItemID.WhitePearl, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}