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
    public class HallowedCap : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hallowed Cap");
                Tooltip.SetDefault("Increases thrown damage by 23% and thrown critical strike chance by 10%");
        }

        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 32;
            item.value = 250000;
            item.rare = 5;
            item.defense = 12; // The Defence value for this piece of armour.
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == 551 && legs.type == 552;
        }
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Throwing speed increased by 12%";
            var modPlayer = player.GetModPlayer<NimblesPlayer>();
            modPlayer.thrownSpeed += 0.15f;
        }
        public override void UpdateEquip(Player player)
        {
            player.thrownDamage += 0.23f;
            player.thrownCrit += 10;
        }


        public override void AddRecipes()
        {
            ModRecipe r = new ModRecipe(mod);
            r.AddIngredient(1225, 12);
            r.AddTile(134);
            r.SetResult(this);
            r.AddRecipe();
        }
    }
}