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
    public class FortressPlate : ModItem
    {
        public override void SetStaticDefaults()
        {
                Tooltip.SetDefault("Increases throwing velocity and damage by 15%");
        }

        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 32;
            Item.value = 62500;
            Item.rare = 3;
            Item.defense = 8; 
        }
        public override void UpdateEquip(Player player)
        {
            player.ThrownVelocity += 0.15f;
            player.GetDamage(DamageClass.Throwing) += 0.15f;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Bone, 16);
            recipe.AddIngredient(ItemID.BlueBrick, 30);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
            recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Bone, 16);
            recipe.AddIngredient(ItemID.GreenBrick, 30);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
            recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Bone, 16);
            recipe.AddIngredient(ItemID.PinkBrick, 30);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}