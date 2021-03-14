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
    [AutoloadEquip(EquipType.Body)]
    public class BatMail : ModItem
    {
        public override void SetStaticDefaults()
        {
                Tooltip.SetDefault("Increases the amount of minions and sentries that can be summoned");
        }

        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 32;
            item.value = 25000;
            item.rare = 1;
            item.defense = 4; // The Defence value for this piece of armour.
        }
        public override void UpdateEquip(Player player)
        {
            player.maxMinions += 1;
            player.maxTurrets += 1;
        }
        public override void AddRecipes()
        {
            ModRecipe r = new ModRecipe(mod);
            r.AddIngredient(19, 16);
            r.AddIngredient(ModContent.ItemType<BatFlesh>(), 12);
            r.AddTile(16);
            r.SetResult(this);
            r.AddRecipe();
            r = new ModRecipe(mod);
            r.AddIngredient(706, 16);
            r.AddIngredient(ModContent.ItemType<BatFlesh>(), 12);
            r.AddTile(16);
            r.SetResult(this);
            r.AddRecipe();
        }
    }
}