using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using NimblesThrowingStuff.Items.Armor;
using NimblesThrowingStuff.Items.Materials;
using Terraria.GameContent.Creative;

namespace NimblesThrowingStuff.Items.Armor
{
    [AutoloadEquip(EquipType.Legs)]
    public class BatBoots : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            Tooltip.SetDefault("Increases thrown critical strike chance by 6%");
        }

        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 32;
            Item.value = 20000;
            Item.rare = 1;
            Item.defense = 3; // The Defence value for this piece of armour.
        }
        public override void UpdateEquip(Player player)
        {
            player.GetCritChance(DamageClass.Throwing) += 6;
        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<BatMail>() && head.type == ModContent.ItemType<BatMask>();
        }
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Fall damage is negated";
            player.noFallDmg = true;
        }
        public override void AddRecipes()
        {
            Recipe r = CreateRecipe();
            r.AddIngredient(19, 12);
            r.AddIngredient(ModContent.ItemType<BatFlesh>(), 9);
            r.AddTile(16);
            r.Register();
            r = CreateRecipe();
            r.AddIngredient(706, 12);
            r.AddIngredient(ModContent.ItemType<BatFlesh>(), 9);
            r.AddTile(16);
            r.Register();
        }
    }
}