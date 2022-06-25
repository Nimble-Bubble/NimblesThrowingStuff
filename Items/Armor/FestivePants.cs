using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using NimblesThrowingStuff.Items.Materials;

namespace NimblesThrowingStuff.Items.Armor
{
    [AutoloadEquip(EquipType.Legs)]
    public class FestivePants : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Festive Boots");
                Tooltip.SetDefault("Increases movement speed by 25% and throwing damage by 30%");
        }

        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 32;
            Item.value = 750000;
            Item.rare = 8;
            Item.defense = 16; // The Defence value for this piece of armour.
        }
        public override void UpdateEquip(Player player)
        {
            player.moveSpeed += 0.25f;
            player.GetDamage(DamageClass.Throwing) += 0.3f;
        }


        public override void AddRecipes()
        {
            Recipe r = CreateRecipe();
            r.AddIngredient(ModContent.ItemType<FestiveCloth>(), 18);
            r.AddTile(134);
            r.Register();
        }
    }
}