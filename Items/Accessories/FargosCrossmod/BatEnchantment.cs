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
    public class BatEnchantment : ModItem
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
            Item.rare = ItemRarityID.Blue;
            Item.expert = false;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            var modPlayer = player.GetModPlayer<NimblesPlayer>();
            modPlayer.thrownSpeed += 0.2f;
            player.ThrownVelocity += 0.2f;
        }
        public override void AddRecipes()
		{
            ModLoader.TryGetMod("FargosSoulsMod", out Mod FargosSouls);
            if (FargosSouls != null)
            {
                Recipe recipe = CreateRecipe();
                recipe.AddIngredient(ModContent.ItemType<BatMask>());
                recipe.AddIngredient(ModContent.ItemType<BatMail>());
                recipe.AddIngredient(ModContent.ItemType<BatBoots>());
                recipe.AddIngredient(ItemID.ChainKnife, 1);
                recipe.AddIngredient(ItemID.DepthMeter, 1);
                recipe.AddIngredient(ItemID.BatBat, 1);
                recipe.AddTile(TileID.DemonAltar);
                recipe.Register();
            }
        }
    }
}
