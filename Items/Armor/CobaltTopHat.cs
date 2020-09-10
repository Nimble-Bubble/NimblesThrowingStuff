using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace NimblesThrowingStuff.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class CobaltTopHat : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cobalt Top Hat");
                Tooltip.SetDefault("Increases thrown critical strike chance and damage by 10%");
        }

        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 32;
            item.value = 75000;
            item.rare = 4;
            item.defense = 3; // The Defence value for this piece of armour.
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemID.CobaltBreastplate && legs.type == ItemID.CobaltLeggings;
        }
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Throwing speed increased by 12%";
            var modPlayer = player.GetModPlayer<NimblesPlayer>();
            modPlayer.thrownSpeed += 0.12f;
        }
        public override void UpdateEquip(Player player)
        {
            player.thrownCrit += 10;
            player.thrownDamage += 0.1f;
        }


        public override void AddRecipes()
        {
            ModRecipe r = new ModRecipe(mod);
            r.AddIngredient(381, 10);
            r.AddTile(16);
            r.SetResult(this);
            r.AddRecipe();
        }
    }
}