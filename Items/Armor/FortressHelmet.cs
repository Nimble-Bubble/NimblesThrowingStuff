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
    public class FortressHelmet : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            // Tooltip.SetDefault("Increases throwing damage and critical strike chance by 10%");
        }

        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 32;
            Item.value = 37500;
            Item.rare = 3;
            Item.defense = 6; // The Defence value for this piece of armour.
        }
        public override void UpdateEquip(Player player)
        {
            player.GetDamage(DamageClass.Throwing) += 0.1f;
            player.GetCritChance(DamageClass.Throwing) += 10;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Bone, 8);
            recipe.AddIngredient(ItemID.BlueBrick, 15);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
            recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Bone, 8);
            recipe.AddIngredient(ItemID.GreenBrick, 15);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
            recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Bone, 8);
            recipe.AddIngredient(ItemID.PinkBrick, 15);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}