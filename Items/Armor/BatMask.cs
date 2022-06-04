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
    [AutoloadEquip(EquipType.Head)]
    public class BatMask : ModItem
    {
        public override void SetStaticDefaults()
        {
                Tooltip.SetDefault("Increases minion damage by 5%");
        }

        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 32;
            Item.value = 15000;
            Item.rare = 1;
            Item.defense = 3; // The Defence value for this piece of armour.
        }
        public override void UpdateEquip(Player player)
        {
            player.minionDamage += 0.05f;
        }
        public override void AddRecipes()
        {
            ModRecipe r = new ModRecipe(Mod);
            r.AddIngredient(19, 8);
            r.AddIngredient(ModContent.ItemType<BatFlesh>(), 6);
            r.AddTile(16);
            r.SetResult(this);
            r.AddRecipe();
            r = new ModRecipe(Mod);
            r.AddIngredient(706, 8);
            r.AddIngredient(ModContent.ItemType<BatFlesh>(), 6);
            r.AddTile(16);
            r.SetResult(this);
            r.AddRecipe();
        }
    }
}