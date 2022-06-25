using NimblesThrowingStuff.Items.Placeables.Blocks;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace NimblesThrowingStuff.Tiles.Blocks
{
    public class ProcellariteOreTile : ModTile
    {
        public override void SetStaticDefaults()
        {
            TileID.Sets.Ore[Type] = true;
            Main.tileShine2[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileOreFinderPriority[Type] = 825;
            Main.tileShine[Type] = 975;
            Main.tileSolid[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileMergeDirt[Type] = true;

            ItemDrop = ModContent.ItemType<ProcellariteOre>();
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Procellarite Ore");
            AddMapEntry(new Color(0, 200, 185), name);
            MineResist = 8f;
            MinPick = 225;
            DustType = 43;
            HitSound = SoundID.Dig;
            Main.tileSpelunker[Type] = true;
        }
        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            r = 0f; 
            g = 0.4f;
            b = 0.375f;
        }
        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }
        public override bool CanExplode(int i, int j)
        {
            return NPC.downedMoonlord;
        }
    }
}
