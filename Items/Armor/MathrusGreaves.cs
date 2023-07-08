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

namespace NimblesThrowingStuff.Items.Armor
{
    [AutoloadEquip(EquipType.Legs)]
    public class MathrusGreaves : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            // DisplayName.SetDefault("Draconic Greaves");
                // Tooltip.SetDefault("Increases movement speed and throwing damage by 40%");
        }

        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 32;
            Item.value = 525000;
            Item.rare = 10;
            Item.defense = 20; // The Defence value for this piece of armour.
        }
        public override void UpdateEquip(Player player)
        {
            player.moveSpeed += 0.4f;
            player.GetDamage(DamageClass.Throwing) += 0.4f;
        }


        public override void AddRecipes()
        {
            Recipe r = CreateRecipe();
            r.AddIngredient(ModContent.ItemType<DoradoFragment>(), 16);
            r.AddIngredient(3467, 12);
            r.AddTile(TileID.LunarCraftingStation);
            r.Register();
        }
    }
}