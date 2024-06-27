using NimblesThrowingStuff.Items.Placeables.Blocks;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
namespace NimblesThrowingStuff.Tiles.Blocks
{
    public class DecussateShellstoneTile : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileMergeDirt[Type] = true;
            Main.tileSolid[Type] = true;
            Main.tileLavaDeath[Type] = false;
            Main.tileBlockLight[Type] = true;
            Main.tileMergeDirt[Type] = true;

            RegisterItemDrop(ModContent.ItemType<DecussateShellstone>());
            LocalizedText name = CreateMapEntryName();
            // name.SetDefault("Decussate Shellstone");
            AddMapEntry(new Color(8, 72, 107), name);
            MineResist = 5.5f;
            MinPick = 180;
            DustType = 42;
            HitSound = SoundID.Dig;
        }
        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            r = 0f; 
            g = 0f;
            b = 0.25f;
        }
        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }
        public override bool CanExplode(int i, int j)
        {
            return NPC.downedMechBossAny; //
        }
    }
}
