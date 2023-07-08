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
    [AutoloadEquip(EquipType.Head)]
    public class ProcellariteMask : ModItem
    {
        public override void SetStaticDefaults()
        {
                /* Tooltip.SetDefault("Increases summoning damage by 50% and minion max by 4"
                    +"\nThis mask appears to be inspired by an endemic animal, but you're not entirely sure what lies up there..."); */
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 32;
            Item.value = 500000;
            Item.rare = 11;
            Item.defense = 10; 
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == Mod.Find<ModItem>("ProcellariteChestplate").Type && legs.type == Mod.Find<ModItem>("ProcellariteLeggings").Type;
        }
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Sentry max increased by 2 and minion max increased by 5";
            player.maxTurrets += 2;
            player.maxMinions += 5;
        }
        public override void UpdateEquip(Player player)
        {
            player.GetDamage(DamageClass.Summon) += 0.5f;
            player.maxMinions += 4;
        }


        public override void AddRecipes()
        {
            Recipe r = CreateRecipe();
            r.AddIngredient(ModContent.ItemType<ProcellariteBar>(), 12);
            r.AddTile(TileID.LunarCraftingStation);
            r.Register();
        }
    }
}