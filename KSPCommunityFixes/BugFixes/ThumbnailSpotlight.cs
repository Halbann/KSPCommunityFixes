﻿using System;
using System.Collections.Generic;
using HarmonyLib;

namespace KSPCommunityFixes.BugFixes
{
    class ThumbnailSpotlight : BasePatch
    {
        protected override Version VersionMin => new Version(1, 12, 0);

        protected override void ApplyPatches()
        {
            AddPatch(PatchType.Postfix, typeof(CraftThumbnail), nameof(CraftThumbnail.TakePartSnapshot));
        }

        private static void CraftThumbnail_TakePartSnapshot_Postfix()
        {
            if (CraftThumbnail.snapshotCamera.IsNotNullOrDestroyed())
            {
                UnityEngine.Object.Destroy(CraftThumbnail.snapshotCamera.gameObject);
            }
        }
    }
}
