﻿using Verse;
using rjw;
using RimWorld;

namespace RJW_Genes
{
    public class Gene_NoPenis : RJW_Gene
    {

        internal Hediff removed_penis;

        // TODO: This gene only works if another Gene was set specifying the genitalia. 
        // If it is added later, it still works, but on creation it needs a different 
        // TODO: If all Genitalia are removed by genes, RJW adds some to the pawns at spawn
        public override void PostMake()
        {
            base.PostMake();

            // Penis are only removed for male pawns!
            if (GenderUtility.IsMale(pawn) && removed_penis == null)
            {
                RemoveButStorePenis();
            }
        }
        
        public override void PostAdd()
        {
            base.PostAdd();

            // Penis are only removed for male pawns!
            if (GenderUtility.IsMale(pawn) && removed_penis == null)
            {
                RemoveButStorePenis();
            }
        }

        public override void PostRemove()
        {
            base.PostRemove();
            if(removed_penis != null)    
                pawn.health.AddHediff(removed_penis);
        }

        internal void RemoveButStorePenis()
        {
            var partBPR = Genital_Helper.get_genitalsBPR(pawn);
            Hediff penisToRemove = Genital_Helper.get_AllPartsHediffList(pawn).FindLast(x => Genital_Helper.is_penis(x));

            if(penisToRemove != null)
            {
                removed_penis = penisToRemove;
                pawn.health.RemoveHediff(penisToRemove);
            }
        }

    }
}
