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
    public class ProcellariteCap : ModItem
    {
        public override void SetStaticDefaults()
        {
                Tooltip.SetDefault("Increases throwing damage and critical strike chance by 30%");
        }

        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 32;
            item.value = 500000;
            item.rare = 11;
            item.defense = 18; 
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == mod.ItemType("ProcellariteChestplate") && legs.type == mod.ItemType("ProcellariteLeggings");
        }
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Mana increased by 100 and throwing speed increased by 25%";
            var modPlayer = player.GetModPlayer<NimblesPlayer>();
            modPlayer.thrownSpeed += 0.25f;
            player.statManaMax2 += 100;
        }
        public override void UpdateEquip(Player player)
        {
            player.thrownDamage += 0.3f;
            player.thrownCrit += 30;
        }


        public override void AddRecipes()
        {
            ModRecipe r = new ModRecipe(mod);
            r.AddIngredient(ModContent.ItemType<ProcellariteBar>(), 12);
            r.AddTile(TileID.LunarCraftingStation);
            r.SetResult(this);
            r.AddRecipe();
        }
    }
}