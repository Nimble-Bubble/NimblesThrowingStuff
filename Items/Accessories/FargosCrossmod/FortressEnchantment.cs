using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using NimblesThrowingStuff.Items.Accessories;
using NimblesThrowingStuff.Items.Armor;
using Terraria.GameContent.Creative;

namespace NimblesThrowingStuff.Items.Accessories.FargosCrossmod
{
    public class FortressEnchantment : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            Item.accessory = true;
            Item.width = 30;
            Item.height = 34;
            Item.value = Item.buyPrice(0, 1, 0, 0);
            Item.rare = ItemRarityID.Orange;
            Item.expert = false;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            var modPlayer = player.GetModPlayer<NimblesPlayer>();
            modPlayer.guardBonus += player.statDefense;
        }
        public override void AddRecipes()
		{
            ModLoader.TryGetMod("FargosSoulsMod", out Mod FargosSouls);
            if (FargosSouls != null)
            {
                Recipe recipe = CreateRecipe();
                recipe.AddIngredient(ModContent.ItemType<FortressHelmet>());
                recipe.AddIngredient(ModContent.ItemType<FortressPlate>());
                recipe.AddIngredient(ModContent.ItemType<FortressBrickboots>());
                recipe.AddIngredient(3000, 1); //I know it's better to just use the name, but Alchemy Table's number might look neat
                recipe.AddTile(TileID.DemonAltar);
                recipe.Register();
            }
        }
    }
}
