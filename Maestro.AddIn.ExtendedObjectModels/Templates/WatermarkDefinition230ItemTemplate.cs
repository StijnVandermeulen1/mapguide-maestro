﻿#region Disclaimer / License

// Copyright (C) 2010, Jackie Ng
// http://trac.osgeo.org/mapguide/wiki/maestro, jumpinjackie@gmail.com
//
// This library is free software; you can redistribute it and/or
// modify it under the terms of the GNU Lesser General Public
// License as published by the Free Software Foundation; either
// version 2.1 of the License, or (at your option) any later version.
//
// This library is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
// Lesser General Public License for more details.
//
// You should have received a copy of the GNU Lesser General Public
// License along with this library; if not, write to the Free Software
// Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301  USA
//

#endregion Disclaimer / License

using Maestro.Base.Templates;
using OSGeo.MapGuide.MaestroAPI;
using OSGeo.MapGuide.ObjectModels;
using OSGeo.MapGuide.ObjectModels.SymbolDefinition;
using System;
using Res = Maestro.AddIn.ExtendedObjectModels.Properties.Resources;

namespace Maestro.AddIn.ExtendedObjectModels.Templates
{
    internal class WatermarkDefinitionSimple230ItemTemplate : ItemTemplate
    {
        public WatermarkDefinitionSimple230ItemTemplate()
        {
            Category = Strings.TPL_CATEGORY_MGOS23;
            Icon = Res.water;
            Description = Strings.TPL_WDFS_230_DESC;
            Name = Strings.TPL_WDFS_230_NAME;
            ResourceType = ResourceTypes.LayerDefinition.ToString();
        }

        public override Version MinimumSiteVersion
        {
            get
            {
                return new Version(2, 3);
            }
        }

        public override IResource CreateItem(string startPoint, OSGeo.MapGuide.MaestroAPI.IServerConnection conn)
        {
            return ObjectFactory.CreateWatermark(SymbolDefinitionType.Simple, new Version(2, 3, 0));
        }
    }

    internal class WatermarkDefinitionCompound230ItemTemplate : ItemTemplate
    {
        public WatermarkDefinitionCompound230ItemTemplate()
        {
            Category = Strings.TPL_CATEGORY_MGOS23;
            Icon = Res.water;
            Description = Strings.TPL_WDFC_230_DESC;
            Name = Strings.TPL_WDFC_230_NAME;
            ResourceType = ResourceTypes.LayerDefinition.ToString();
        }

        public override Version MinimumSiteVersion
        {
            get
            {
                return new Version(2, 3);
            }
        }

        public override IResource CreateItem(string startPoint, OSGeo.MapGuide.MaestroAPI.IServerConnection conn)
        {
            return ObjectFactory.CreateWatermark(SymbolDefinitionType.Compound, new Version(2, 3, 0));
        }
    }
}