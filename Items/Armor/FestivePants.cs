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
    public class FestivePants : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            // DisplayName.SetDefault("Festive Boots");
                // Tooltip.SetDefault("Increases movement speed by 25% and throwing damage by 30%");
        }

        public override void SetDefaults()
        {
            Item.width = 22;
            Item.height = 16;
            Item.value = 750000;
            Item.rare = ItemRarityID.Yellow;
            Item.defense = 16; // The Defence value for this piece of armour.
        }
        public override void UpdateEquip(Player player)
        {
            player.moveSpeed += 0.25f;
            player.GetDamage(DamageClass.Throwing) += 0.3f;
        }


        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<FestiveCloth>(), 18);
            recipe.AddTile(134);
            recipe.Register();
        }
    }
}